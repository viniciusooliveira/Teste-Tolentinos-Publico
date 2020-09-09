using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Infra.Data.Mapping
{
    public class ImagemProdutoMap : IEntityTypeConfiguration<ImagemProduto>
    {
        public void Configure(EntityTypeBuilder<ImagemProduto> builder)
        {
            builder.ToTable("ImagemProduto");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Url)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(i => i.Produto)
                .WithMany(p => p.Imagens)
                .HasForeignKey(i => i.IdProduto);

            builder.HasData(
                new ImagemProduto() 
                { 
                    Id = 1,
                    IdProduto = 1,
                    Url = "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-1.png"
                },
                new ImagemProduto()
                {
                    Id = 2,
                    IdProduto = 1,
                    Url = "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-2.png"
                },
                new ImagemProduto()
                {
                    Id = 3,
                    IdProduto = 1,
                    Url = "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-3.png"
                });

        }
    }
}
