﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApplicationApi.Data;

namespace MyApplicationApi.Migrations
{
    [DbContext(typeof(BookStoreDBContext))]
    [Migration("20230109103714_addedvalidation")]
    partial class addedvalidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyApplicationApi.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            DOB = new DateTime(1995, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sam",
                            LastName = "Lary"
                        },
                        new
                        {
                            AuthorId = 2,
                            DOB = new DateTime(1985, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Malcom",
                            LastName = "D"
                        });
                });

            modelBuilder.Entity("MyApplicationApi.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            Description = "Book on Sql Server 2019",
                            Price = 800.0,
                            Title = "Sql Server 2019"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            Description = "Book on Azure Fundamentals 2019",
                            Price = 980.0,
                            Title = "Azure Fundamentals"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 1,
                            Description = "Book on JAVA Fundamentals 2022",
                            Price = 750.0,
                            Title = "Java For Beginners"
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 2,
                            Description = "Book on Python Fundamentals 2022",
                            Price = 510.0,
                            Title = "Python"
                        });
                });

            modelBuilder.Entity("MyApplicationApi.Models.Book", b =>
                {
                    b.HasOne("MyApplicationApi.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
