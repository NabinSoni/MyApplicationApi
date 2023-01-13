using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Data
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly BookStoreDBContext bookStoreDBContext;
        public SQLBookRepository(BookStoreDBContext bookStoreDBContext)
        {
            this.bookStoreDBContext = bookStoreDBContext;
        }

        public Book Create(Book entity)
        {
            bookStoreDBContext.Add(entity);
            bookStoreDBContext.SaveChanges();
            return entity;
        }

        public Book Delete(Book entity)
        {
            bookStoreDBContext.Remove(entity);
            bookStoreDBContext.SaveChanges();

            return entity;
        }

        public IList<Book> GetAll()
        {
            return bookStoreDBContext.Books.ToList();
        }       

        public Book GetById(int id)
        {
            return bookStoreDBContext.Books.Find(id);
        }

        public Book Update(Book entity)
        {
            bookStoreDBContext.Update(entity);
            bookStoreDBContext.SaveChanges();

            return entity;
        }

        public Book GetBook(int authorId, int bookId)
        {
            return bookStoreDBContext.Books.Where(x => x.AuthorId == authorId && x.BookId == bookId).FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return bookStoreDBContext.Books.Where(b => b.AuthorId == authorId).OrderBy(b => b.Title).ToList();
        }

        public Book AddBook(int authorId, Book book)
        {
            if(authorId <= 0)
            {
                throw new ArgumentException(nameof(authorId));
            }
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.AuthorId = authorId;
            bookStoreDBContext.Books.Add(book);
            bookStoreDBContext.SaveChanges();

            return book;
        }
    }
}
