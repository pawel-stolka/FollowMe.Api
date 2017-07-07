using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.IoC.Modules;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using Newtonsoft.Json;

namespace FollowMe.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureAutofac();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureJsonOutput();
        }

        private void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<InMemoryCategoryRepo>().As<ICategoryRepository>();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<CommandModule>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICategoryService>();
            }
        }

        private void ConfigureJsonOutput()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            GlobalConfiguration
                .Configuration
                .Formatters
                .JsonFormatter
                .SerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
        }
    }
}
