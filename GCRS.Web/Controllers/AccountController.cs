using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Web.ViewModels;
using GCRS.Web.Infrastructure;

namespace GCRS.Web.Controllers
{
    public class AccountController : Controller
    {
        private FormAuthenticationProvider authProvider;

        public AccountController()
            :this(new FormAuthenticationProvider())
        { }

        public AccountController(FormAuthenticationProvider AuthProvider)
            : base()
        {
            authProvider = AuthProvider;
        }

        //GET: Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!Request.IsAuthenticated)
            {
                if(authProvider.Authenticate(model.Username, model.Password, false))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
            }
            return View();
        }

        //GET: Account/LogOff
        public ActionResult LogOff()
        {
            authProvider.LogOff();
            return RedirectToAction("Index", "Home");
        }
    }
}