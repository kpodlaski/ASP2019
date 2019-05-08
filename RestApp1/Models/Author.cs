using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp1.Models
{
    public class Author
    {
        public Author() { }
        public Author(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        public int Id { get;  set; }
        public String Name { get;  set; }
        public String Surname { get;  set; }
    }
}