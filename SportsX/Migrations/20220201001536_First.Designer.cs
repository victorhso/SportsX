﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsX.Data;

namespace SportsX.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220201001536_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsX.Entities.Telefone", b =>
                {
                    b.Property<int>("ID_TELEFONE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("NR_TELEFONE")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID_TELEFONE");

                    b.HasIndex("ID");

                    b.ToTable("TELEFONE");
                });

            modelBuilder.Entity("SportsX.Entity.Endereco", b =>
                {
                    b.Property<int>("ID_ENDERECO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("NR_CEP")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_ENDERECO");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.ToTable("ENDERECO");
                });

            modelBuilder.Entity("SportsX.Entity.PFisica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DS_CLASSIFICACAO")
                        .HasColumnType("BIT");

                    b.Property<string>("DS_EMAIL")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("DS_NOME")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("ID");

                    b.ToTable("PFISICA");
                });

            modelBuilder.Entity("SportsX.Entity.PJuridica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DS_CLASSIFICACAO")
                        .HasColumnType("BIT");

                    b.Property<string>("DS_EMAIL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DS_RAZAO_SOCIAL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("PJURIDICA");
                });

            modelBuilder.Entity("SportsX.Entities.Telefone", b =>
                {
                    b.HasOne("SportsX.Entity.PFisica", "PFisica")
                        .WithMany("Telefones")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsX.Entity.PJuridica", "PJuridica")
                        .WithMany("Telefones")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PFisica");

                    b.Navigation("PJuridica");
                });

            modelBuilder.Entity("SportsX.Entity.Endereco", b =>
                {
                    b.HasOne("SportsX.Entity.PFisica", "PFisica")
                        .WithOne("Endereco")
                        .HasForeignKey("SportsX.Entity.Endereco", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsX.Entity.PJuridica", "PJuridica")
                        .WithOne("Endereco")
                        .HasForeignKey("SportsX.Entity.Endereco", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PFisica");

                    b.Navigation("PJuridica");
                });

            modelBuilder.Entity("SportsX.Entity.PFisica", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("SportsX.Entity.PJuridica", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
