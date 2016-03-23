using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Specialized;
using System.Globalization;
using MvcAppRest.WsAusa;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Routing;
using MvcAppRest.Models;

namespace MvcAppRest.Controllers
{
    public class InicioController : Controller
    {
        //
        // GET: /Inicio/

        public ActionResult Index()
        {
            return View();
        }

        #region Autentificacion

        public IFormsAuthenticationService FormsService { get; set; }
        public CustomMembershipProvider MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new CustomMembershipProvider(); }

            base.Initialize(requestContext);
        }

        // /Inicio/AutentificaUsuario/           
        [AcceptVerbs(HttpVerbs.Post)]
        //[ValidateAntiForgeryToken]
        public string AutentificaUsuario(string txtsUsuario, string txtsContrasenia)
        {
            string retorno;

            try
            {   //exitoso

                if (MembershipService.ValidateUser(txtsUsuario, txtsContrasenia))
                {
                    FormsService.SignIn(txtsUsuario, true);
                    SetupFormsAuthTicket(txtsUsuario, true);
                    string[] cadFormat = MembershipService.Result().Split(';');
                    retorno = "[{\"Ejecucion\":0" + "," + "\"Id\":" + cadFormat[0] + ",";
                    retorno += "\"Tipo\":" + cadFormat[1] + "}]";
                }
                else
                {
                    retorno = "[{\"Ejecucion\":1}]";
                }

            }
            catch (Exception e)
            {
                //error
                retorno = "[{\"Ejecucion\":1}]";
            }
            return retorno;
        }

        private void SetupFormsAuthTicket(string userName, bool persistanceFlag)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                                    userName,
                                    DateTime.Now,
                                    DateTime.Now.AddMinutes(30),
                                    persistanceFlag,
                                    userName);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            this.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
        #endregion
    }

    #region Services
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IMembershipService
    {
        int MinPasswordLength { get; }
        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public interface ICustomMembershipService : IMembershipService
    {
        string Result { get; set; }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion
}
