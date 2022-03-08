﻿// <auto-generated />
using System;
using Asp_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asp_project.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211228132320_addLoja")]
    partial class addLoja
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asp_project.Models.AvaliacaoLoja", b =>
                {
                    b.Property<int>("id_avaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Lid_loja")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nota")
                        .HasColumnType("int");

                    b.HasKey("id_avaliacao");

                    b.HasIndex("Lid_loja");

                    b.ToTable("AvaliacaoLoja");
                });

            modelBuilder.Entity("Asp_project.Models.AvaliacaoProduto", b =>
                {
                    b.Property<int>("id_avaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Pid_produto")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nota")
                        .HasColumnType("int");

                    b.HasKey("id_avaliacao");

                    b.HasIndex("Pid_produto");

                    b.ToTable("AvaliacaoProduto");
                });

            modelBuilder.Entity("Asp_project.Models.Categoria", b =>
                {
                    b.Property<int>("id_categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_categoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Asp_project.Models.Endereco", b =>
                {
                    b.Property<int>("id_endereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Lid_loja")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Uid_usuario")
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_endereco");

                    b.HasIndex("Lid_loja")
                        .IsUnique()
                        .HasFilter("[Lid_loja] IS NOT NULL");

                    b.HasIndex("Uid_usuario")
                        .IsUnique()
                        .HasFilter("[Uid_usuario] IS NOT NULL");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Asp_project.Models.ItemPedido", b =>
                {
                    b.Property<int>("id_item_pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Peid_pedido")
                        .HasColumnType("int");

                    b.Property<int>("Proid_produto")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id_item_pedido");

                    b.HasIndex("Peid_pedido");

                    b.HasIndex("Proid_produto");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("Asp_project.Models.Loja", b =>
                {
                    b.Property<int>("id_loja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Uid_usuario")
                        .HasColumnType("int");

                    b.Property<string>("celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf_cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dias_e_horas_de_funcionamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fotoLoja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome_loja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_loja");

                    b.HasIndex("Uid_usuario")
                        .IsUnique();

                    b.ToTable("Loja");
                });

            modelBuilder.Entity("Asp_project.Models.Pedido", b =>
                {
                    b.Property<int>("id_pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Lid_loja")
                        .HasColumnType("int");

                    b.Property<int>("Uid_usuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_final")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_pedido")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id_pedido");

                    b.HasIndex("Lid_loja");

                    b.HasIndex("Uid_usuario");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Asp_project.Models.Produto", b =>
                {
                    b.Property<int>("id_produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cid_categoria")
                        .HasColumnType("int");

                    b.Property<int>("Lid_loja")
                        .HasColumnType("int");

                    b.Property<string>("descricao_produto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome_produto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id_produto");

                    b.HasIndex("Cid_categoria")
                        .IsUnique();

                    b.HasIndex("Lid_loja");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Asp_project.Models.Usuario", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_usuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Asp_project.Models.AvaliacaoLoja", b =>
                {
                    b.HasOne("Asp_project.Models.Loja", "L")
                        .WithMany()
                        .HasForeignKey("Lid_loja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp_project.Models.AvaliacaoProduto", b =>
                {
                    b.HasOne("Asp_project.Models.Produto", "P")
                        .WithMany()
                        .HasForeignKey("Pid_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp_project.Models.Endereco", b =>
                {
                    b.HasOne("Asp_project.Models.Loja", "L")
                        .WithOne("Endereco")
                        .HasForeignKey("Asp_project.Models.Endereco", "Lid_loja");

                    b.HasOne("Asp_project.Models.Usuario", "U")
                        .WithOne("Endereco")
                        .HasForeignKey("Asp_project.Models.Endereco", "Uid_usuario");
                });

            modelBuilder.Entity("Asp_project.Models.ItemPedido", b =>
                {
                    b.HasOne("Asp_project.Models.Pedido", "Pe")
                        .WithMany()
                        .HasForeignKey("Peid_pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp_project.Models.Produto", "Pro")
                        .WithMany()
                        .HasForeignKey("Proid_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp_project.Models.Loja", b =>
                {
                    b.HasOne("Asp_project.Models.Usuario", "U")
                        .WithOne("Loja")
                        .HasForeignKey("Asp_project.Models.Loja", "Uid_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp_project.Models.Pedido", b =>
                {
                    b.HasOne("Asp_project.Models.Loja", "L")
                        .WithMany()
                        .HasForeignKey("Lid_loja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp_project.Models.Usuario", "U")
                        .WithMany()
                        .HasForeignKey("Uid_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp_project.Models.Produto", b =>
                {
                    b.HasOne("Asp_project.Models.Categoria", "C")
                        .WithOne("Produto")
                        .HasForeignKey("Asp_project.Models.Produto", "Cid_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp_project.Models.Loja", "L")
                        .WithMany()
                        .HasForeignKey("Lid_loja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
