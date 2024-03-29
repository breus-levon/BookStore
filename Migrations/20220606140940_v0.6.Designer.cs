﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BookStore.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookStore.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20220606140940_v0.6")]
    partial class v06
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BookStore.Database.Entities.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<List<Guid>>("BookIds")
                        .HasColumnType("uuid[]");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("AuthorId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookStore.Database.Entities.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("AuthorId");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("Price");

                    b.Property<string>("Publisher")
                        .HasColumnType("text")
                        .HasColumnName("Publisher");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("Title");

                    b.Property<int>("YearOfPublication")
                        .HasColumnType("int4")
                        .HasColumnName("YearOfPublication");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Title");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStore.Database.Entities.Book", b =>
                {
                    b.HasOne("BookStore.Database.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookStore.Database.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
