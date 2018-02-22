using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Web.ViewModels;
using GCRS.Web.Infrastructure;
using GCRS.Data;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;

        public AccountController()
            :this(new FormAuthenticationProvider())
        { }

        public AccountController(IAuthProvider AuthProvider)
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



        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                if(AppDatabase.FindClient(modelo.Username) == null)
                {
                    Client nuevo_cliente = new Client { Username = modelo.Username, Email = modelo.Email, Password = modelo.Password };
                    AppDatabase.AddClient(nuevo_cliente);
                    authProvider.Authenticate(modelo.Username, modelo.Password, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Username", "The username is being used");
                }
            }
            return View();
        }
    }
}