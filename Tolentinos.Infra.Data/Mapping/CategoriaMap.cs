using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Infra.Data.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(c => c.Pai)
                .WithMany(p => p.Filhos)
                .HasForeignKey(c => c.IdPai);

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.IdCategoria);

            builder.HasData(
                new Categoria() { 
                    Nome="Informática",
                    Ordem = 0,
                    Id = 1
                },
                new Categoria() { 
                    Nome = "Equipamentos de Rede",
                    Ordem = 0,
                    IdPai = 1,
                    Id = 2
                });
        }
    }
}
