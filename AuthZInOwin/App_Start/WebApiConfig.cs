using AuthZInOwin.Services;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace AuthZInOwin
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Autofac setup
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ValueService>();

            builder.RegisterAuthorization();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "default", id = RouteParameter.Optional }
            );
        }

        public static void RegisterAuthorization(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DebugLogger<>)).As(typeof(ILogger<>));

            builder.RegisterType<DefaultAuthorizationService>().As<IAuthorizationService>();
            builder.RegisterType<DefaultAuthorizationPolicyProvider>().As<IAuthorizationPolicyProvider>();
            builder.RegisterType<DefaultAuthorizationHandlerProvider>().As<IAuthorizationHandlerProvider>();
            builder.RegisterType<DefaultAuthorizationEvaluator>().As<IAuthorizationEvaluator>();
            builder.RegisterType<DefaultAuthorizationHandlerContextFactory>().As<IAuthorizationHandlerContextFactory>();
            builder.RegisterType<PassThroughAuthorizationHandler>().As<IAuthorizationHandler>();

            var options = new AuthorizationOptions();
            options.AddPolicy("ViewValues", p => p.RequireAssertion(MyAssertion));

            builder.RegisterGeneric(typeof(Options<>)).As(typeof(IOptions<>));
            builder.RegisterInstance(options);
                
        }

        private static bool MyAssertion(AuthorizationHandlerContext arg)
        {
            return true;
        }
    }
}
