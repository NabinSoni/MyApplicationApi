using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Data
{
    public class MockBookRepository 
    {
        private static List<Book> list;

        //public MockBookRepository()
        //{
        //    list = new List<Book>
        //    {
        //        new Book
        //        {
        //            BookId = 1,
        //            Title = "Sql Server 2019",
        //            Price = 100.00,
        //            Author = "James"
        //        },
        //        new Book
        //        {
        //            BookId = 2,
        //            Title = "Azure",
        //            Price = 200.00,
        //            Author = "Nabin"
        //        }
        //    };
        //}

        public Book AddBook(Book book)
        {
            book.BookId = list.Max(x => x.BookId) + 1;
            list.Add(book);
            return book;
        }

        public Book GetBook(int id)
        {
            return list.Find(x => x.BookId == id);
        }

        public List<Book> GetBooks()
        {
            return list;
        }
    }
}
