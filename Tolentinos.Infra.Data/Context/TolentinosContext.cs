using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Infra.Data.Mapping;

namespace Tolentinos.Infra.Data.Context
{
    public class TolentinosContext : DbContext
    {

        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<ImagemProduto> ImagemProduto { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinho { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public TolentinosContext(DbContextOptions<TolentinosContext> options): base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=tolentinos;Uid=root;Pwd=tolentinos123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carrinho>(new CarrinhoMap().Configure);
            modelBuilder.Entity<Categoria>(new CategoriaMap().Configure);
            modelBuilder.Entity<ImagemProduto>(new ImagemProdutoMap().Configure);
            modelBuilder.Entity<ItemCarrinho>(new ItemCarrinhoMap().Configure);
            modelBuilder.Entity<Marca>(new MarcaMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }

    }
}
