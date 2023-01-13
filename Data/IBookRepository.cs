using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Data
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetBooksByAuthor(int authorId);
        Book GetBook(int authorId, int bookId);

        Book AddBook(int authorId, Book book);

    }

    public interface IAuthorRepository : IBaseRepository<Author>
    {

    }
}
