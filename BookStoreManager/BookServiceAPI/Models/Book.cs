using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookServiceAPI
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Decimal Price { get; set; }
    }
}