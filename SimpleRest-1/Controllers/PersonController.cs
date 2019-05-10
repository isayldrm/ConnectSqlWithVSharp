using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleRest_1.Models;

namespace SimpleRest_1.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<string> Get()
        {
            return new string[] { "Person1", "Person2" };
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            Person person = new Person();
            person.ID = id;
            person.LastName = "yildirim";
            person.FirstName = "isa";
            person.PayRate = 45.54;
            person.StartDate = DateTime.Parse("5/5/1996");
            person.EndDate = DateTime.Parse("5/7/2003");
            return person;
        }

        // POST: api/Person
            
        public HttpResponseMessage Post([FromBody] Person value)
        {
            PersonPer pp = new PersonPer();
            long id;
            id = pp.SavePerson(value);
            value.ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri,String.Format("person/{0}",id));
            return response;    
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
