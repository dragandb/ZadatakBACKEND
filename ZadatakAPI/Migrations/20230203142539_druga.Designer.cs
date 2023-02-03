﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ZadatakAPI.Data;

#nullable disable

namespace ZadatakAPI.Migrations
{
    [DbContext(typeof(ZadatakAPIDBContext))]
    [Migration("20230203142539_druga")]
    partial class druga
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ZadatakAPI.Models.Kupac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Mjesto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Sifra")
                        .IsUnique();

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("ZadatakAPI.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("numeric");

                    b.Property<string>("Jedinica_mjere")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Stanje")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("Sifra")
                        .IsUnique();

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("ZadatakAPI.Models.Stavke_racuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Iznos_popusta")
                        .HasColumnType("numeric");

                    b.Property<int>("Kolicina")
                        .HasColumnType("integer");

                    b.Property<decimal>("Popust")
                        .HasColumnType("numeric");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("integer");

                    b.Property<int>("RacunID")
                        .HasColumnType("integer");

                    b.Property<decimal>("Vrijednost")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodID");

                    b.HasIndex("RacunID");

                    b.ToTable("Stavke_Racuna");
                });

            modelBuilder.Entity("ZadatakAPI.Models.Zaglavlje_racuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Broj")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("KupacID")
                        .HasColumnType("integer");

                    b.Property<string>("Napomena")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("Broj")
                        .IsUnique();

                    b.HasIndex("KupacID");

                    b.ToTable("Zaglavlje_Racuna");
                });

            modelBuilder.Entity("ZadatakAPI.Models.Stavke_racuna", b =>
                {
                    b.HasOne("ZadatakAPI.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZadatakAPI.Models.Zaglavlje_racuna", "Zaglavlje_racuna")
                        .WithMany()
                        .HasForeignKey("RacunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proizvod");

                    b.Navigation("Zaglavlje_racuna");
                });

            modelBuilder.Entity("ZadatakAPI.Models.Zaglavlje_racuna", b =>
                {
                    b.HasOne("ZadatakAPI.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupac");
                });
#pragma warning restore 612, 618
        }
    }
}
