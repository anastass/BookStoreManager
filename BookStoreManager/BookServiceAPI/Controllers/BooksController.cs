using BookServiceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookServiceAPI.Controllers
{
    public class BooksController : ApiController
    {
        IBookRepository _Repository;

        public BooksController()
        {
            _Repository = new BookRepository();
        }

        // GET api/books
        public IEnumerable<Book> Get()
        {
            var books = _Repository.GetBooks();
            if (books == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return books;
            //Call if method return type is HttpResponseMessage
            //else
            //{
            //    return Request.CreateResponse<IEnumerable<Book>>(HttpStatusCode.OK, book);
            //}
        }

        // GET api/books/5
        public Book Get(int id)
        {
            var book = _Repository.GetBook(id);
            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return book;
            //Call if method return type is HttpResponseMessage
            //else
            //{
            //    return Request.CreateResponse<Book>(HttpStatusCode.OK, book);
            //}
        }

        // POST api/books
        public HttpResponseMessage Post([FromBody]Book book)
        {
            var newBook = _Repository.InsertBook(book);
            if (newBook != null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + newBook.Id.ToString());
                return msg;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

        // PUT api/books/5
        public HttpResponseMessage Put(int id, [FromBody]Book book)
        {
            var status = _Repository.UpdateBook(book);
            if (status)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/books/5
        public HttpResponseMessage Delete(int id)
        {
            var status = _Repository.DeleteBook(id);
            if (status)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}