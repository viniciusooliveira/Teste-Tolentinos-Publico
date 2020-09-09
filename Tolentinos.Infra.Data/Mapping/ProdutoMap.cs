using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Tamanho)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Cor)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.DescricaoNoHtml)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.IdCategoria);

            builder.HasOne(p => p.Marca)
                .WithMany(m => m.Produtos)
                .HasForeignKey(p => p.IdMarca);

            builder.HasMany(p => p.Imagens)
                .WithOne(i => i.Produto)
                .HasForeignKey(i => i.IdProduto);

            builder.HasMany(p => p.ItensCarrinho)
                .WithOne(i => i.Produto)
                .HasForeignKey(i => i.IdProduto);

            builder.HasData(
                new Produto() { 
                    Id = 1,
                    Nome = "Unifi Pro 5G",
                    IdCategoria = 2,
                    Cor = "Branco",
                    Tamanho = "Único",
                    Valor = 769.90m,
                    QuantidadeDisponivel = 10,
                    IdMarca = 1,
                    Descricao = @"Funções: Access point indoor<br>
Tipo de conexão: Sem fio<br>
Velocidade wireless: 1167 Mbps<br>
Frequências: 2.4 GHz,5 GHz<br>
Tipo de freqüência: Banda dupla<br>
Quantidade total de ports: 1<br>
Padrões wireless: IEEE 802.11a / b / g / n / r / k / v / ac<br>
Peso: 170 g<br>
Altura x Largura x Profundidade: 160 mm x 160 mm x 31.45 mm<br>",
                    DescricaoNoHtml = @"Funções: Access point indoor
Tipo de conexão: Sem fio
Velocidade wireless: 1167 Mbps
Frequências: 2.4 GHz,
                    5 GHz
Tipo de freqüência: Banda dupla
Quantidade total de ports: 1
Padrões wireless: IEEE 802.11a / b / g / n / r / k / v / ac
Peso: 170 g
Altura x Largura x Profundidade: 160 mm x 160 mm x 31.45 mm"
                });
        }
    }
}
