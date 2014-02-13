using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookServiceAPIClient.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace BookServiceAPIClient.Controllers.Tests
{
    [TestClass()]
    public class BooksControllerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var testBooks = GetTestBooks();
            BooksController controller = new BooksController();

            var result = controller.Get() as List<Book>;
            Assert.AreEqual(testBooks.Count, result.Count);
        }

        [TestMethod()]
        public void GetTest()
        {
            var testBooks = GetTestBooks();
            var controller = new BooksController();

            var result = controller.Get(1) as Book;
            Assert.IsNotNull(result);
            Assert.AreEqual(testBooks[0].Title, result.Title);
        }

        [TestMethod()]
        public void PostTest()
        {
            var controller = new BooksController();
            var book = new Book
            {
                Id = 10,
                Title = "Crashkurs Charttechnik",
                Author = "Markus Horntrich",
                Price = 13.99M
            };
            var result = controller.Post(book);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.Created);

            var newBook = controller.Get(10) as Book;
            Assert.AreEqual(newBook.Title, book.Title);
        }

        [TestMethod()]
        public void PutTest()
        {
            var controller = new BooksController();
            var book = new Book
            {
                Id = 1,
                Title = "Die Sturmkönige",
                Author = "Kai Meyer",
                Price = 8.49M
            };
            var result = controller.Put(1, book);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            var newBook = controller.Get(1) as Book;
            Assert.AreEqual(newBook.Title, book.Title);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var controller = new BooksController();
            var result = controller.Delete(1);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            try
            {
                var book = controller.Get(1) as Book;
                Assert.Fail();
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.ReasonPhrase, "Not Found");
            }
        }

        private List<Book> GetTestBooks()
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
