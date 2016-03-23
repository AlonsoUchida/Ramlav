using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;

namespace MvcAppRest
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += new EventHandler(MvcApplication_PostAuthenticateRequest);
            base.Init();
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                string encTicket = authCookie.Value;
                if (!String.IsNullOrEmpty(encTicket))
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
                    UserIdentity id = new UserIdentity(ticket);
                    GenericPrincipal prin = new GenericPrincipal(id, null);
                    HttpContext.Current.User = prin;
                }
            }
        }
    }
}