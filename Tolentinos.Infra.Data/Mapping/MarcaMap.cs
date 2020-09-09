using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Infra.Data.Mapping
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marca");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(new Marca() { 
                Id = 1,
                Nome = "Ubiquiti"
            });
        }
    }
}
