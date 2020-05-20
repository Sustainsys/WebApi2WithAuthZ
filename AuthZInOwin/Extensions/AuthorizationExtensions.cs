using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace AuthZInOwin.Extensions
{
    public static class AuthorizationExtensions
    {
        public static Task<AuthorizationResult> AuthorizeAsync(
            this IAuthorizationService authorizationService, IPrincipal principal, string policyName)
            =>  authorizationService.AuthorizeAsync((ClaimsPrincipal)principal, null, policyName);
    }
}