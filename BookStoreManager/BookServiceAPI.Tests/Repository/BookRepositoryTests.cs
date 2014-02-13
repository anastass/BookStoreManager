using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookServiceAPIClient.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Test persistent storage
namespace BookServiceAPIClient.Repository.Tests
{
    [TestClass()]
    public class BookRepositoryTests
    {
        protected static BookRepository repo;
        protected static List<Book> testBooks;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            repo = new BookRepository();
            testBooks = GetTestBooks();  
        }

        [TestMethod()]
        public void GetAllBookTest()
        {
            var result = repo.GetBooks() as List<Book>;
            Assert.AreEqual(testBooks.Count, result.Count);
        }

        [TestMethod()]
        public void GetBook()
        {
            var repo = new BookRepository();

            var result = repo.GetBook(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(testBooks[0].Title, result.Title);
        }

        [TestMethod()]
        public void InsertBookTest()
        {
            var book = new Book
            {
                Id = 10,
                Title = "Crashkurs Charttechnik",
                Author = "Markus Horntrich",
                Price = 13.99M
            };

            var inserted_book = repo.InsertBook(book);
            Assert.AreEqual(inserted_book.Title, book.Title);
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            var book = new Book
            {
                Id = 10,
                Title = "Die Sturmkönige",
                Author = "Kai Meyer",
                Price = 8.49M
            };
            Assert.IsTrue(repo.UpdateBook(book));

            var updated_book = repo.GetBook(book.Id);
            Assert.AreEqual(updated_book.Title, book.Title);
        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            Assert.IsTrue(repo.DeleteBook(10));
            Assert.IsNull(repo.GetBook(10));
        }

        protected static List<Book> GetTestBooks()
        {
            var testBooks = new List<Book>() {
                new Book { Id = 1, Title = "JavaScript: The Good Parts: The Good Parts", Author = "Douglas Crockford", Price = 12.65M},
                new Book { Id = 2, Title = "jQuery: A Beginner's Guide", Author = "John Pollock", Price = 21.23M},
                new Book { Id = 3, Title = "Die Erbin", Author = "John Grisham", Price = 24.99M},
            };
            return testBooks;
        }
    }
}
