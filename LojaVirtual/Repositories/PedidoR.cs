using Correios.NET;
using LojaVirtual.Data;
using LojaVirtual.Models.Venda;
using LojaVirtual.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PagarMe;
using System;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class PedidoR
    {
        private readonly DatabaseContext _banco;
        private readonly IConfiguration _configuration;

        public PedidoR(DatabaseContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _configuration = configuration;
        }

        //métodos agendados
        public void AtualizarPedidos()
        {
            PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");

            //pedidos aguardando pagamento e em processamento
            var pedidos = _banco.Pedido.Include(p => p.Produto)
                .Where(p => p.Situacao == (byte)Global.Pedido.Aguardando || p.Situacao == (byte)Global.Pedido.Processando)
                .OrderBy(p => p.DataCriacao).ToList();

            foreach (var item in pedidos)
            {
                var transacao = PagarMeService.GetDefaultService().Transactions.Find(item.IdTransacao.ToString());

                if (transacao.Status == TransactionStatus.Paid)
                {
                    //pedido aprovado
                    item.Situacao = (byte)Global.Pedido.Aprovado;
                    item.DataAtualizacao = Convert.ToDateTime(transacao.DateUpdated);

                    _banco.Pedido.Update(item);

                    foreach (var produtoPedido in item.Produto)
                    {
                        var produto = _banco.Produto.Find(produtoPedido.IdProduto);

                        if (produto.Estoque >= produtoPedido.Quantidade)
                        {
                            produto.Estoque -= produtoPedido.Quantidade;
                            produtoPedido.Situacao = (byte)Global.Produto.Aprovado;

                            _banco.Produto.Update(produto);
                        }
                        else
                            produtoPedido.Situacao = (byte)Global.Produto.Cancelado;

                        produtoPedido.DataAtualizacao = DateTime.Now;
                        _banco.ProdutoHistorico.Update(produtoPedido);
                    }
                }
                else if (transacao.Status == TransactionStatus.Refunded)
                {
                    //pedido estornado
                    item.Situacao = (byte)Global.Pedido.Estornado;
                    item.DataAtualizacao = Convert.ToDateTime(transacao.DateUpdated);

                    _banco.Pedido.Update(item);

                    foreach (var produtoPedido in item.Produto)
                    {
                        produtoPedido.Situacao = (byte)Global.Produto.Cancelado;
                        produtoPedido.DataAtualizacao = DateTime.Now;

                        _banco.ProdutoHistorico.Update(produtoPedido);
                    }
                }
                else if (transacao.Status == TransactionStatus.Refused)
                {
                    //pedido recusado
                    item.Situacao = (byte)Global.Pedido.Recusado;
                    item.DataAtualizacao = Convert.ToDateTime(transacao.DateUpdated);

                    _banco.Pedido.Update(item);

                    foreach (var produtoPedido in item.Produto)
                    {
                        produtoPedido.Situacao = (byte)Global.Produto.Cancelado;
                        produtoPedido.DataAtualizacao = DateTime.Now;

                        _banco.ProdutoHistorico.Update(produtoPedido);
                    }
                }

                _banco.SaveChanges();
            }
        }

        public void AtualizarProdutoPedido()
        {
            var lista = _banco.Pedido.Where(p => p.Situacao == (byte)Global.Pedido.Aprovado).ToList();

            foreach (var pedido in lista)
            {
                foreach (var produto in pedido.Produto.Where(p => p.Situacao == (byte)Global.Produto.Enviado))
                {
                    var rastreamento = new Services().GetPackageTracking(produto.CodRastreamento);

                    if (rastreamento.IsDelivered)
                    {
                        produto.Situacao = (byte)Global.Produto.Entregue;
                        produto.DataAtualizacao = DateTime.Now;

                        _banco.ProdutoHistorico.Update(produto);
                        _banco.SaveChanges();
                    }
                }
            }
        }

        public void EnviarProdutosPedido()
        {
            var lista = _banco.Pedido.Include(p => p.Frete).Include(p => p.Produto)
                .Where(p => p.Situacao == (byte)Global.Pedido.Aprovado).ToList();

            foreach (var pedido in lista)
            {
                foreach (var produto in pedido.Produto.Where(p => p.Situacao == (byte)Global.Produto.Aprovado))
                {
                    produto.Situacao = (byte)Global.Produto.Enviado;
                    produto.CodRastreamento = "";
                    produto.PrazoEntrega = DateTime.Now.AddDays(pedido.Frete.DiasEntrega);
                    produto.DataAtualizacao = DateTime.Now;

                    _banco.ProdutoHistorico.Update(produto);
                }
            }

            _banco.SaveChanges();
        }

        public void FinalizarPedido()
        {
            //lista de pedidos aprovados
            var lista = _banco.Pedido.Where(p => p.Situacao == (byte)Global.Pedido.Aprovado).ToList();

            foreach (var pedido in lista)
            {
                //número de produtos finalizados de cada pedido aprovado
                var finalizados = pedido.Produto.Where(p => p.Situacao == (byte)Global.Produto.Entregue ||
                p.Situacao == (byte)Global.Produto.Cancelado).Count();

                if (finalizados == pedido.Produto.Count())
                {
                    pedido.Situacao = (byte)Global.Pedido.Finalizado;
                    pedido.DataAtualizacao = DateTime.Now;

                    _banco.Pedido.Update(pedido);
                }
            }

            _banco.SaveChanges();
        }


        public int Atualizar(Pedido pedido)
        {
            _banco.Pedido.Update(pedido);
            return _banco.SaveChanges();
        }

        public int AtualizarProdutoPedido(ProdutoHistorico produto)
        {
            _banco.ProdutoHistorico.Update(produto);
            return _banco.SaveChanges();
        }

        public Pedido Buscar(uint idTransacao)
        {
            return _banco.Pedido.Include(p => p.Frete).Include(p => p.Parcelamento)
                   .Include(p => p.Boleto).Include(p => p.Endereco).Include(p => p.Produto)
                   .FirstOrDefault(p => p.IdTransacao == idTransacao);
        }

        public ProdutoHistorico BuscarProdutoPedido(uint idProdutoHistorico)
        {
            return _banco.ProdutoHistorico.Include(p => p.Pedido.Cliente.Contato).Include(p => p.Pedido.Frete)
                   .Include(p => p.Pedido.Endereco).Include(p => p.Pedido.Parcelamento)
                   .FirstOrDefault(p => p.IdProdutoHistorico == idProdutoHistorico);
        }

        public IPagedList<Pedido> ListarPedidos(uint idCliente)
        {
            return _banco.Pedido.Where(p => p.IdCliente == idCliente).Include(p => p.Boleto)
                    .OrderByDescending(p => p.DataCriacao).ToPagedList(1, 10);
        }

        public IPagedList<ProdutoHistorico> ListarProdutoPedido(uint idUsuario)
        {
            return _banco.ProdutoHistorico.Include(p => p.Pedido).Where(p => p.IdUsuario == idUsuario)
                .OrderByDescending(p => p.Pedido.DataCriacao).ToPagedList(1, 10);
        }

        public int Registrar(Pedido pedido)
        {
            _banco.Add(pedido);
            return _banco.SaveChanges();
        }
    }
}