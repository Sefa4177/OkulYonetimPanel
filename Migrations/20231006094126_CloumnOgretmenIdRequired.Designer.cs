﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OkulYonetimPaneli.Data;

#nullable disable

namespace OkulYonetimPaneli.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231006094126_CloumnOgretmenIdRequired")]
    partial class CloumnOgretmenIdRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("OkulYonetimPaneli.Data.Ders", b =>
                {
                    b.Property<int>("DersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int>("OgretmenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DersId");

                    b.HasIndex("OgretmenId");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.DersKayit", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DersId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("DersId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("DersKayitlari");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OgrenciAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciEposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciSoyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciTelefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgretmenId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.Ders", b =>
                {
                    b.HasOne("OkulYonetimPaneli.Data.Ogretmen", "Ogretmen")
                        .WithMany("Dersler")
                        .HasForeignKey("OgretmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.DersKayit", b =>
                {
                    b.HasOne("OkulYonetimPaneli.Data.Ders", "Ders")
                        .WithMany("DersKayitlari")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OkulYonetimPaneli.Data.Ogrenci", "Ogrenci")
                        .WithMany("DersKayitlari")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.Ders", b =>
                {
                    b.Navigation("DersKayitlari");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.Ogrenci", b =>
                {
                    b.Navigation("DersKayitlari");
                });

            modelBuilder.Entity("OkulYonetimPaneli.Data.Ogretmen", b =>
                {
                    b.Navigation("Dersler");
                });
#pragma warning restore 612, 618
        }
    }
}
