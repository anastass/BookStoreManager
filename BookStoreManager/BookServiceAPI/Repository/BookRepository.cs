using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookServiceAPI.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBook(int Id);
        bool UpdateBook(Book book);
        Book InsertBook(Book book);
        bool DeleteBook(int Id);
    }

    public class BookRepository : IBookRepository
    {
        static List<Book> _Books = new List<Book>
            {
                new Book { Id = 1, Title = "JavaScript: The Good Parts: The Good Parts", Author = "Douglas Crockford", Price = 12.65M},
                new Book { Id = 2, Title = "jQuery: A Beginner's Guide", Author = "John Pollock", Price = 21.23M},
                new Book { Id = 3, Title = "Die Erbin", Author = "John Grisham", Price = 24.99M},
            };

        public List<Book> GetBooks()
        {
            return _Books;
        }

        public Book GetBook(int Id)
        {
            return _Books.Where(b => b.Id == Id).SingleOrDefault();
        }

        public Book InsertBook(Book book)
        {
            if (!_Books.Any(b => b.Id == book.Id))
            {
                _Books.Add(book);
                return book;
            }
            return null;
        }

        public bool UpdateBook(Book book)
        {
            var targetbook = _Books.Where(b => b.Id == book.Id).SingleOrDefault();
            if (targetbook != null)
            {
                _Books.Remove(targetbook);
                _Books.Add(book);
                return true;
            }
            return false;
        }

        public bool DeleteBook(int Id)
        {
            var book = _Books.Where(b => b.Id == Id).SingleOrDefault();
            if (book != null)
            {
                _Books.Remove(book);
                return true;
            }
            return false;
        }
    }

}