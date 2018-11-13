﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rbyte.Persistance;

namespace Rbyte.Persistance.Migrations
{
    [DbContext(typeof(RbyteContext))]
    [Migration("20181113194922_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Rbyte.Domain.Entities.DbCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int?>("ParentCategoryId");

                    b.Property<string>("Parents");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbCategoryProduct", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryProducts");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbDiscount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Value");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbProducer", b =>
                {
                    b.Property<int>("ProducerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ProducerId");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Barcode");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProducerId");

                    b.Property<decimal>("StandardPrice");

                    b.HasKey("ProductId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbProductDiscount", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("DiscountId");

                    b.HasKey("ProductId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("ProductDiscounts");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbStore", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbStoreProduct", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("StoreId");

                    b.Property<int>("Count");

                    b.Property<int>("StoreProductId");

                    b.HasKey("ProductId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbCategory", b =>
                {
                    b.HasOne("Rbyte.Domain.Entities.DbCategory", "ParentCategory")
                        .WithMany("ChildernCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbCategoryProduct", b =>
                {
                    b.HasOne("Rbyte.Domain.Entities.DbCategory", "Category")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rbyte.Domain.Entities.DbProduct", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbProduct", b =>
                {
                    b.HasOne("Rbyte.Domain.Entities.DbProducer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerId");
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbProductDiscount", b =>
                {
                    b.HasOne("Rbyte.Domain.Entities.DbDiscount", "Discount")
                        .WithMany("DiscountProducts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rbyte.Domain.Entities.DbProduct", "Product")
                        .WithMany("ProductDiscounts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rbyte.Domain.Entities.DbStoreProduct", b =>
                {
                    b.HasOne("Rbyte.Domain.Entities.DbProduct", "Product")
                        .WithMany("ProductStores")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rbyte.Domain.Entities.DbStore", "Store")
                        .WithMany("StoreProducts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
