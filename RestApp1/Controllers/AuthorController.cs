using RestApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApp1.Controllers
{
    public class AuthorController : ApiController
    {
        public static List<Author> author = new List<Author>();
        // GET: api/Author
        public IEnumerable<Author> Get()
        {     
            author.Add(new Author(author.Count, "Tomasz", "Kowalski"));
            author.Add(new Author(author.Count, "Eliza", "Orzeszkowa"));
            return author;
        }

        // GET: api/Author/5
        public Author Get(int id)
        {
            Author a = null;
            a = author.FirstOrDefault(x => x.Id == id);

            return a;
        }

        // POST: api/Author //Insert Create
        public Author Post([FromBody]Author a)
        {
            a.Id = author.Count;
            author.Add(a);
            return a;
        }

        // PUT: api/Author/5  //Update
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Author/5
        public void Delete(int id)
        {
        }
    }
}
