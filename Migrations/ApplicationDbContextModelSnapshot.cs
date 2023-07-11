﻿// <auto-generated />
using System;
using ArtFusion.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtFusion.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtFusion.Models.ProductMetadataModel", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MetaDataKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MetaDataValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId", "MetaDataKey");

                    b.ToTable("ProductMetadata");
                });

            modelBuilder.Entity("ArtFusion.Models.ShoppingCartItemModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("ProductId", "UserId");

                    b.ToTable("ShoppingCartItem");
                });

            modelBuilder.Entity("Artfusion.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Artfusion.Models.FollowsModel", b =>
                {
                    b.Property<string>("FollowingUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FollowedUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FollowingUserId", "FollowedUserId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Artfusion.Models.LikesModel", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId", "UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Artfusion.Models.OrderDetailsModel", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DelivaryAddressId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Artfusion.Models.PaymentsModel", b =>
                {
                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Artfusion.Models.ProductsModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Artfusion.Models.UserAddressModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressLane1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLane2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("Artfusion.Models.UserModel", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPicURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
