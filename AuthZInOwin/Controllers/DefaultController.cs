using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthZInOwin.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
