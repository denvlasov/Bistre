using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHomeSystem.WebAPI.Controllers
{
    public class HubController : ApiController
    {
        // GET: api/Hub
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Hub/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hub
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Hub/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hub/5
        public void Delete(int id)
        {
        }
    }
}
