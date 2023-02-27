﻿// <auto-generated />
using System;
using Livraria.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Livraria.Repository.Migrations
{
    [DbContext(typeof(LivrariaContext))]
    [Migration("20230226230749_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Livraria.Model.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Livraria.Model.AutorLivro", b =>
                {
                    b.Property<int>("AutorId")
                        .HasColumnType("integer");

                    b.Property<int>("LivroId")
                        .HasColumnType("integer");

                    b.HasKey("AutorId", "LivroId");

                    b.HasIndex("LivroId");

                    b.ToTable("AutoresLivros");
                });

            modelBuilder.Entity("Livraria.Model.Editora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("Livraria.Model.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Edicao")
                        .HasColumnType("integer");

                    b.Property<int?>("EditoraId")
                        .HasColumnType("integer");

                    b.Property<int>("QtdPaginas")
                        .HasColumnType("integer");

                    b.Property<string>("Resumo")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Subtitulo")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("EditoraId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Livraria.Model.AutorLivro", b =>
                {
                    b.HasOne("Livraria.Model.Autor", "Autor")
                        .WithMany("AutoresLivros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livraria.Model.Livro", "Livro")
                        .WithMany("AutoresLivros")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Livraria.Model.Livro", b =>
                {
                    b.HasOne("Livraria.Model.Editora", "Editora")
                        .WithMany("Livros")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("Livraria.Model.Autor", b =>
                {
                    b.Navigation("AutoresLivros");
                });

            modelBuilder.Entity("Livraria.Model.Editora", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Livraria.Model.Livro", b =>
                {
                    b.Navigation("AutoresLivros");
                });
#pragma warning restore 612, 618
        }
    }
}
