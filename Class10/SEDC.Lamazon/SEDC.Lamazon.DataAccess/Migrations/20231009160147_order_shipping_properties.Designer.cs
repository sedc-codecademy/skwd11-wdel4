﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.Lamazon.DataAccess;

#nullable disable

namespace SEDC.Lamazon.DataAccess.Migrations
{
    [DbContext(typeof(LamazonDbContext))]
    [Migration("20231009160147_order_shipping_properties")]
    partial class order_shipping_properties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Meatball Marinara is iconic to the Subway® brand and this favourite comes with tender beef meatballs smothered in a rich marinara sauce.",
                            ImageUrl = "https://www.subway.com/ns/images/menu/UKM/ENG/036_SubMeatball_WD.jpg",
                            Name = "Meatball Marinara",
                            Price = 10m,
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton in Atlanta, Georgia.",
                            ImageUrl = "https://th.bing.com/th/id/R.f7c80ce3bc654933f2fb4a3ffbaff719?rik=kZZnQCt3Fqm0aw&pid=ImgRaw&r=0",
                            Name = "Coca Cola",
                            Price = 1.35m,
                            ProductCategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "The Pragmatic Programmer: From Journeyman to Master is a book about computer programming and software engineering, written by Andrew Hunt and David Thomas and published in October 1999.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/8f/The_pragmatic_programmer.jpg/220px-The_pragmatic_programmer.jpg",
                            Name = "The Pragmatic Programmer",
                            Price = 39.99m,
                            ProductCategoryId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Design Patterns: Elements of Reusable Object-Oriented Software (1994) is a software engineering book describing software design patterns. The book was written by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides, with a foreword by Grady Booch. The book is divided into two parts, with the first two chapters exploring the capabilities and pitfalls of object-oriented programming, and the remaining chapters describing 23 classic software design patterns.",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51szD9HC9pL._SX395_BO1,204,203,200_.jpg",
                            Name = "Design Patterns: Elements of Reusable Object-Oriented Software",
                            Price = 53.79m,
                            ProductCategoryId = 3
                        });
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Books"
                        });
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "admin",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Key = "user",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "City1",
                            Email = "admin@gmail.com",
                            FullName = "Admin Test",
                            Password = "AQAAAAEAACcQAAAAELajFm20bokfUbr7ksEAke4Q6n9TCJfDpPqcOMesQu85WftOXx/9zAJJbAhKp2HG2g==",
                            PhoneNumber = "123456789",
                            PostalCode = "10001",
                            RoleId = 1,
                            State = "State1",
                            StreetAddress = "Random Street 1"
                        },
                        new
                        {
                            Id = 2,
                            City = "City2",
                            Email = "user@gmail.com",
                            FullName = "User Test",
                            Password = "AQAAAAEAACcQAAAAEOO3c3ft1gdMBvZnBkkSoicAdjjCiFlRsivxfCaRWxI72ZEBoWw9ITcSv/xISxcc4Q==",
                            PhoneNumber = "987654321",
                            PostalCode = "10002",
                            RoleId = 2,
                            State = "State2",
                            StreetAddress = "Random Street 2"
                        });
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Order", b =>
                {
                    b.HasOne("SEDC.Lamazon.Domain.Enitites.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.OrderItem", b =>
                {
                    b.HasOne("SEDC.Lamazon.Domain.Enitites.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.Lamazon.Domain.Enitites.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Product", b =>
                {
                    b.HasOne("SEDC.Lamazon.Domain.Enitites.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.User", b =>
                {
                    b.HasOne("SEDC.Lamazon.Domain.Enitites.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Product", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SEDC.Lamazon.Domain.Enitites.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
