using Correios.NET;
using LojaVirtual.Data;
using LojaVirtual.Models.Venda;
using LojaVirtual.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PagarMe;
using System;
using System.Collections.Generic;
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

        public void AtualizarPedidos()
        {
            PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");

            //pedidos aguardando pagamento e em processamento
            var pedidos = _banco.Pedido.Include(p => p.Produto)
                .Where(p => p.Situacao == Global.Pedido.Aguardando || p.Situacao == Global.Pedido.Processando)
                .OrderBy(p => p.DataCriacao).ToList();

            foreach (var item in pedidos)
            {
                var transacao = PagarMeService.GetDefaultService().Transactions.Find(item.IdTransacao.ToString());

                if (transacao.Status == TransactionStatus.Paid)
                {
                    //pedido aprovado
                    item.Situacao = Global.Pedido.Aprovado;
                    item.DataAtualizaco = Convert.ToDateTime(transacao.DateUpdated);

                    _banco.Pedido.Update(item);

                    foreach (var produtoPedido in item.Produto)
                    {
                        var produto = _banco.Produto.Find(produtoPedido.IdProduto);
                        
                        if (produto.Estoque >= produtoPedido.Quantidade)
                        {
                            produto.Estoque -= produtoPedido.Quantidade;
                            produtoPedido.Situacao = Global.Produto.Reservado;

                            _banco.Produto.Update(produto);
                        }
                        else
                            produtoPedido.Situacao = Global.Produto.Cancelado;

                        produtoPedido.DataAtualizacao = DateTime.Now;
                        _banco.ProdutoHistorico.Update(produtoPedido);
                    }
                }
                else if (transacao.Status == TransactionStatus.Chargedback)
                {
                    //pedido extornado
                    item.Situacao = Global.Pedido.Extornado;
                    item.DataAtualizaco = Convert.ToDateTime(transacao.DateUpdated);

                    _banco.Pedido.Update(item);

                    foreach (var produtoPedido in item.Produto)
                    {
                        if (produtoPedido.Situacao == Global.Produto.Reservado)
                        {
                            var produto = _banco.Produto.Find(produtoPedido.IdProduto);
                            produto.Estoque += produtoPedido.Quantidade;

                            _banco.Produto.Update(produto);
                        }

                        produtoPedido.Situacao = Global.Produto.Cancelado;
                        produtoPedido.DataAtualizacao = DateTime.Now;

                        _banco.ProdutoHistorico.Update(produtoPedido);
                    }
                }
                else if (transacao.Status == TransactionStatus.Refused)
                {
                    //pedido recusado
                    item.Situacao = Global.Pedido.Recusado;
                    item.DataAtualizaco = Convert.ToDateTime(transacao.DateUpdated);

                    _banco.Pedido.Update(item);

                    foreach (var produtoPedido in item.Produto)
                    {
                        produtoPedido.Situacao = Global.Produto.Cancelado;
                        produtoPedido.DataAtualizacao = DateTime.Now;

                        _banco.ProdutoHistorico.Update(produtoPedido);
                    }
                }

                _banco.SaveChanges();
            }
        }

        public void AtualizarProdutoPedido()
        {
            var lista = _banco.Pedido.Where(p => p.Situacao == Global.Pedido.Aprovado).ToList();

            foreach (var pedido in lista)
            {
                foreach (var produto in pedido.Produto.Where(p => p.Situacao == Global.Produto.Enviado))
                {
                    var rastreamento = new Services().GetPackageTracking(produto.CodRastreamento);

                    if (rastreamento.IsDelivered)
                    {
                        produto.Situacao = Global.Produto.Entregue;
                        produto.DataAtualizacao = DateTime.Now;

                        _banco.ProdutoHistorico.Update(produto);
                        _banco.SaveChanges();
                    }
                }
            }
        }

        public Pedido Buscar(uint idTransacao)
        {
            try
            {
                return _banco.Pedido
                    .Include(p => p.Frete).Include(p => p.Parcelamento)
                    .Include(p => p.Boleto).Include(p => p.Endereco)
                    .Include(p => p.Produto).FirstOrDefault(p => p.IdTransacao == idTransacao);
            }
            catch (Exception erro) 
            {
                Console.WriteLine(erro);
                return new Pedido();
            }
        }

        public ProdutoHistorico BuscarProdutoPedido(uint idProdutoHistorico)
        {
            try
            {
                return _banco.ProdutoHistorico.FirstOrDefault(p => 
                p.IdProdutoHistorico == idProdutoHistorico);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new ProdutoHistorico();
            }
        }

        public IPagedList<Pedido> ListarPedidos(uint idCliente)
        {
            try
            {
                return _banco.Pedido.Where(p => p.IdCliente == idCliente).Include(p => p.Boleto)
                    .OrderByDescending(p => p.DataCriacao).ToPagedList(1, 10);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);

                var lista = new List<Pedido>();
                return lista.ToPagedList();
            }
        }

        public IPagedList<ProdutoHistorico> ListarProdutoPedido(uint idUsuario)
        {
            try
            {
                return _banco.ProdutoHistorico.Include(p => p.Pedido)
                    .Where(p => p.Situacao != Global.Produto.Aguardando && p.Situacao != Global.Produto.Cancelado
                    && p.IdUsuario == idUsuario).OrderByDescending(p => p.Pedido.DataCriacao).ToPagedList(1, 10);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);

                var lista = new List<ProdutoHistorico>();
                return lista.ToPagedList();
            }
        }

        public int Registrar(Pedido pedido)
        {
            try
            {
                _banco.Add(pedido);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }
    }
}
