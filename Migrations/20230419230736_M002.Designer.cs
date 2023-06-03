﻿// <auto-generated />
using Commpay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Commpay.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230419230736_M002")]
    partial class M002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Commpay.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Commpay.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cargo")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);

                    b.HasDiscriminator<int>("Cargo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Commpay.Models.Expedidor", b =>
                {
                    b.HasBaseType("Commpay.Models.Usuario");

                    b.ToTable("Usuario");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Commpay.Models.Financeiro", b =>
                {
                    b.HasBaseType("Commpay.Models.Usuario");

                    b.ToTable("Usuario");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("Commpay.Models.Vendedor", b =>
                {
                    b.HasBaseType("Commpay.Models.Usuario");

                    b.ToTable("Usuario");

                    b.HasDiscriminator().HasValue(2);
                });
#pragma warning restore 612, 618
        }
    }
}