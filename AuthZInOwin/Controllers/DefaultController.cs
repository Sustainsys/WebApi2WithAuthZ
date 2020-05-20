using AuthZInOwin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Markup;

namespace AuthZInOwin.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly ValueService valueService;

        public DefaultController(ValueService valueService)
        {
            this.valueService = valueService;
        }

        // GET: Default
        public IEnumerable<string> Get()
        {
            return valueService.GetValues();
        }
    }
}
