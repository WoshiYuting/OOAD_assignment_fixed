﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mywebapi.Data.AddDbcontext;

#nullable disable

namespace Mywebapi.Migrations
{
    [DbContext(typeof(AddDbcontext))]
    [Migration("20231210100156_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Mywebapi.Models.Book", b =>
                {
                    b.Property<int>("IBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IBook");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Mywebapi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Mywebapi.Models.Librarian", b =>
                {
                    b.Property<int>("Lid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Lid");

                    b.ToTable("Librarians");
                });

            modelBuilder.Entity("Mywebapi.Models.Reader", b =>
                {
                    b.Property<int>("Rid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RContact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Rid");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("Mywebapi.Models.Book", b =>
                {
                    b.HasOne("Mywebapi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
