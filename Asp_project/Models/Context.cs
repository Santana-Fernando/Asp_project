using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class Context:DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<AvaliacaoLoja> AvaliacaoLoja { get; set; }
        public DbSet<ImagensProdutos> ImagensProdutos { get; set; }
        public DbSet<AvaliacaoProduto> AvaliacaoProduto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-F9M2LAN\SQLEXPRESS;Initial Catalog=Emporio_traine;User ID=sa;Password=Fern@nd01331;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
