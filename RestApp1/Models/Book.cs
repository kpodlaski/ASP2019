using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public List<Author> Authors { get; set; }
    }
}