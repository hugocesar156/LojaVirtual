using LojaVirtual.Models.Acesso;
using LojaVirtual.Models.Cliente;
using LojaVirtual.Models.Log;
using LojaVirtual.Models.Pagamento;
using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<EnderecoCliente> Endereco { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Parcelamento> Parcelamento { get; set; }
        public DbSet<Frete> Frete { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ProdutoHistorico> ProdutoHistorico { get; set; }
        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<ContatoCliente> Contato { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
