﻿// <auto-generated />
using System;
using Challenge.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge.Entities.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Challenge.Entities.Entities.Categories", b =>
                {
                    b.Property<int>("id_categories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_categories"), 1L, 1);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_date")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("id_categories");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("Challenge.Entities.Entities.Content", b =>
                {
                    b.Property<int>("id_content")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_content"), 1L, 1);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("date_create")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_delete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_update")
                        .HasColumnType("datetime2");

                    b.Property<bool>("delete")
                        .HasColumnType("bit");

                    b.Property<int>("display")
                        .HasColumnType("int");

                    b.Property<int>("id_category")
                        .HasColumnType("int");

                    b.Property<int>("id_interior_subcategory")
                        .HasColumnType("int");

                    b.Property<int>("id_subcategory")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("unLocked")
                        .HasColumnType("bit");

                    b.HasKey("id_content");

                    b.ToTable("content", (string)null);
                });

            modelBuilder.Entity("Challenge.Entities.Entities.ImageUpload", b =>
                {
                    b.Property<int>("id_image_Upload")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_image_Upload"), 1L, 1);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("idCategories")
                        .HasColumnType("int");

                    b.Property<int?>("idInteriorSubcategories")
                        .HasColumnType("int");

                    b.Property<int?>("idSubcategories")
                        .HasColumnType("int");

                    b.Property<byte[]>("image_Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("id_image_Upload");

                    b.ToTable("imageUpload", (string)null);
                });

            modelBuilder.Entity("Challenge.Entities.Entities.InteriorSubcategoriesCategories", b =>
                {
                    b.Property<int>("id_interior_subcategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_interior_subcategory"), 1L, 1);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_catgeory")
                        .HasColumnType("int");

                    b.Property<int>("id_subcategory")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("url_interior_Subcategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_interior_subcategory");

                    b.ToTable("interiorSubCategory", (string)null);
                });

            modelBuilder.Entity("Challenge.Entities.Entities.SubCategories", b =>
                {
                    b.Property<int>("id_subcategories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_subcategories"), 1L, 1);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_categories")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("urlSubcategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_subcategories");

                    b.HasIndex("id_categories");

                    b.ToTable("subCategory", (string)null);
                });

            modelBuilder.Entity("Challenge.Entities.Entities.SubCategories", b =>
                {
                    b.HasOne("Challenge.Entities.Entities.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("id_categories")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
