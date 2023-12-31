﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.inlock.tarde.Contexts;

#nullable disable

namespace webapi.inlock.tarde.Migrations
{
    [DbContext(typeof(InLockContext))]
    [Migration("20230915192312_bd")]
    partial class bd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.inlock.tarde.Domains.Estudio", b =>
                {
                    b.Property<Guid>("IdEstudio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdEstudio")
                        .HasName("PK__Estudio__0C3B4355AE1D8B5E");

                    b.ToTable("Estudio", (string)null);
                });

            modelBuilder.Entity("webapi.inlock.tarde.Domains.Jogo", b =>
                {
                    b.Property<Guid>("IdJogo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("IdEstudio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("smallmoney");

                    b.HasKey("IdJogo")
                        .HasName("PK__Jogo__69E085139B9AEA60");

                    b.HasIndex("IdEstudio");

                    b.ToTable("Jogo", (string)null);
                });

            modelBuilder.Entity("webapi.inlock.tarde.Domains.TiposUsuario", b =>
                {
                    b.Property<Guid>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdTipoUsuario")
                        .HasName("PK__TiposUsu__CA04062BB351F5DF");

                    b.ToTable("TiposUsuario", (string)null);
                });

            modelBuilder.Entity("webapi.inlock.tarde.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__5B65BF977254B54D");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("webapi.inlock.tarde.Domains.Jogo", b =>
                {
                    b.HasOne("webapi.inlock.tarde.Domains.Estudio", "IdEstudioNavigation")
                        .WithMany("Jogos")
                        .HasForeignKey("IdEstudio")
                        .HasConstraintName("FK__Jogo__IdEstudio__4BAC3F29");

                    b.Navigation("IdEstudioNavigation");
                });

            modelBuilder.Entity("webapi.inlock.tarde.Domains.Usuario", b =>
                {
                    b.HasOne("webapi.inlock.tarde.Domains.TiposUsuario", "IdTipoUsuarioNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdTipoUsuario")
                        .HasConstraintName("FK__Usuario__IdTipoU__5070F446");

                    b.Navigation("IdTipoUsuarioNavigation");
                });

            modelBuilder.Entity("webapi.inlock.tarde.Domains.Estudio", b =>
                {
                    b.Navigation("Jogos");
                });

            modelBuilder.Entity("webapi.inlock.tarde.Domains.TiposUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
