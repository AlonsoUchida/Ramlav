using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using Bonus.WebApi.App_Start;
using Newtonsoft.Json;
using System.Web.Routing;
using System.Web.Optimization;

[assembly: OwinStartup(typeof(Bonus.WebApi.Startup))]

namespace Bonus.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Look for the reason of this order in the code here: http://stackoverflow.com/questions/27912003/api-end-point-returning-authorization-has-been-denied-for-this-request-when-s
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initialise Bootstrapper
            Bootstrapper.Initialise();

            //Define Formatters
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            // settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var appXmlType = formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Add CORS Handler
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
        }
    }
}
