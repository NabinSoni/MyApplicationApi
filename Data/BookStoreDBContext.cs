using Microsoft.EntityFrameworkCore;
using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Data
{
    public class BookStoreDBContext: DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
            :base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData
                (
                    new Author
                    {
                        AuthorId = 1,
                        FirstName = "Sam",
                        LastName = "Lary",
                        DOB = Convert.ToDateTime("11/16/1995")
                    },
                    new Author
                    {
                        AuthorId = 2,
                        FirstName = "Malcom",
                        LastName = "D",
                        DOB = Convert.ToDateTime("12/01/1985")
                    }
                );

            modelBuilder.Entity<Book>().HasData(
                    new Book 
                    {
                        BookId = 1,
                        Title = "Sql Server 2019",
                        Description = "Book on Sql Server 2019",
                        Price = 800.00,
                        AuthorId = 1
                    },
                    new Book
                    {
                        BookId = 2,
                        Title = "Azure Fundamentals",
                        Description = "Book on Azure Fundamentals 2019",
                        Price = 980.00,
                        AuthorId = 2
                    },
                    new Book
                    {
                        BookId = 3,
                        Title = "Java For Beginners",
                        Description = "Book on JAVA Fundamentals 2022",
                        Price = 750.00,
                        AuthorId = 1
                    },
                    new Book
                    {
                        BookId = 4,
                        Title = "Python",
                        Description = "Book on Python Fundamentals 2022",
                        Price = 510.00,
                        AuthorId = 2
                    }
                );
        }
    }
}
