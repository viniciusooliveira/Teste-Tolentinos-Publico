﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tolentinos.Infra.Data.Context;

namespace Tolentinos.Infra.Data.Migrations
{
    [DbContext(typeof(TolentinosContext))]
    partial class TolentinosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Tolentinos.Domain.Entities.Carrinho", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("IdUsuario")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("IdPai")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPai");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Nome = "Informática",
                            Ordem = 0
                        },
                        new
                        {
                            Id = 2L,
                            IdPai = 1L,
                            Nome = "Equipamentos de Rede",
                            Ordem = 0
                        });
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.ImagemProduto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("IdProduto")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("ImagemProduto");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IdProduto = 1L,
                            Url = "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-1.png"
                        },
                        new
                        {
                            Id = 2L,
                            IdProduto = 1L,
                            Url = "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-2.png"
                        },
                        new
                        {
                            Id = 3L,
                            IdProduto = 1L,
                            Url = "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-3.png"
                        });
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.ItemCarrinho", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("IdCarrinho")
                        .HasColumnType("bigint");

                    b.Property<long>("IdProduto")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCarrinho");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItemCarrinho");
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.Marca", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Marca");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Nome = "Ubiquiti"
                        });
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000) CHARACTER SET utf8mb4")
                        .HasMaxLength(1000);

                    b.Property<string>("DescricaoNoHtml")
                        .IsRequired()
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<long>("IdCategoria")
                        .HasColumnType("bigint");

                    b.Property<long>("IdMarca")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<long>("QuantidadeDisponivel")
                        .HasColumnType("bigint");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdMarca");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Cor = "Branco",
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
Altura x Largura x Profundidade: 160 mm x 160 mm x 31.45 mm",
                            IdCategoria = 2L,
                            IdMarca = 1L,
                            Nome = "Unifi Pro 5G",
                            QuantidadeDisponivel = 10L,
                            Tamanho = "Único",
                            Valor = 769.90m
                        });
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.Categoria", b =>
                {
                    b.HasOne("Tolentinos.Domain.Entities.Categoria", "Pai")
                        .WithMany("Filhos")
                        .HasForeignKey("IdPai");
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.ImagemProduto", b =>
                {
                    b.HasOne("Tolentinos.Domain.Entities.Produto", "Produto")
                        .WithMany("Imagens")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.ItemCarrinho", b =>
                {
                    b.HasOne("Tolentinos.Domain.Entities.Carrinho", "Carrinho")
                        .WithMany("Itens")
                        .HasForeignKey("IdCarrinho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tolentinos.Domain.Entities.Produto", "Produto")
                        .WithMany("ItensCarrinho")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tolentinos.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Tolentinos.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tolentinos.Domain.Entities.Marca", "Marca")
                        .WithMany("Produtos")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
