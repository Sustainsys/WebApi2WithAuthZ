using AuthZInOwin.Extensions;
using AuthZInOwin.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Markup;

namespace AuthZInOwin.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly IAuthorizationService authorizationService;
        private readonly ValueService valueService;

        public DefaultController(
            IAuthorizationService authorizationService,
            ValueService valueService)
        {
            this.authorizationService = authorizationService;
            this.valueService = valueService;
        }

        // GET: Default
        public async Task<IEnumerable<string>> Get()
        {
            // Should really do something with the AuthZ result. But this is just a sample
            // to show that the policy can be run.

            var succeeded = (await authorizationService.AuthorizeAsync(User, "ViewValues")).Succeeded;
            return valueService.GetValues();
        }
    }
}
