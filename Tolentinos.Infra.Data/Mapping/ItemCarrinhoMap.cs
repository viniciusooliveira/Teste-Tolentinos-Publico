using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Infra.Data.Mapping
{
    public class ItemCarrinhoMap : IEntityTypeConfiguration<ItemCarrinho>

    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.ToTable("ItemCarrinho");

            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Produto)
                .WithMany(p => p.ItensCarrinho)
                .HasForeignKey(i => i.IdProduto);

            builder.HasOne(i => i.Carrinho)
                .WithMany(c => c.Itens)
                .HasForeignKey(i => i.IdCarrinho);
        }
    }
}
