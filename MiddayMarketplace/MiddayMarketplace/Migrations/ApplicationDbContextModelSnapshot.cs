﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiddayMarketplace.Data;

#nullable disable

namespace MiddayMarketplace.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MiddayMarketplace.Models.AppUser", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AppUserId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MiddayMarketplace.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("MiddayMarketplace.Models.MarketItem", b =>
                {
                    b.Property<int>("MarketItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateListed")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ItemLocationLocationId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ListerAppUserId")
                        .HasColumnType("int");

                    b.HasKey("MarketItemId");

                    b.HasIndex("ItemLocationLocationId");

                    b.HasIndex("ListerAppUserId");

                    b.ToTable("MarketItems");
                });

            modelBuilder.Entity("MiddayMarketplace.Models.MarketItem", b =>
                {
                    b.HasOne("MiddayMarketplace.Models.Location", "ItemLocation")
                        .WithMany()
                        .HasForeignKey("ItemLocationLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiddayMarketplace.Models.AppUser", "Lister")
                        .WithMany()
                        .HasForeignKey("ListerAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemLocation");

                    b.Navigation("Lister");
                });
#pragma warning restore 612, 618
        }
    }
}
