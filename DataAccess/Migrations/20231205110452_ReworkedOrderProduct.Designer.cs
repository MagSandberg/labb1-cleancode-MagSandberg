﻿// <auto-generated />
using System;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SOLIDDEMO.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20231205110452_ReworkedOrderProduct")]
    partial class ReworkedOrderProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.CustomerModel", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId")
                        .HasName("PK_Customers");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataAccess.Models.OrderModel", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerModelCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId")
                        .HasName("PK_Orders");

                    b.HasIndex("CustomerModelCustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataAccess.Models.OrderProductModel", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderModelOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductModelProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId")
                        .HasName("PK_OrderProducts");

                    b.HasIndex("OrderModelOrderId");

                    b.HasIndex("ProductModelProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("DataAccess.Models.ProductModel", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId")
                        .HasName("PK_Products");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataAccess.Models.OrderModel", b =>
                {
                    b.HasOne("DataAccess.Models.CustomerModel", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerModelCustomerId");
                });

            modelBuilder.Entity("DataAccess.Models.OrderProductModel", b =>
                {
                    b.HasOne("DataAccess.Models.OrderModel", null)
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderModelOrderId");

                    b.HasOne("DataAccess.Models.ProductModel", null)
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductModelProductId");
                });

            modelBuilder.Entity("DataAccess.Models.CustomerModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DataAccess.Models.OrderModel", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("DataAccess.Models.ProductModel", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
