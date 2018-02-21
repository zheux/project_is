using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCRS.Data;
using GCRS.Web.ViewModels;
using GCRS.Domain;

namespace GCRS.Web.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View(AppDatabase.GetClientes());
        }

        // GET: Clientes/Registro
        public ActionResult Registro()
        {
            return View();
        }

        // POST: Clientes/Registro
        [HttpPost]
        public ActionResult Registro(RegisterViewModel modelo)
        {
            if (ModelState.IsValid && AppDatabase.FindCliente(modelo.Username) == null)
            {
                Cliente nuevo_cliente = new Cliente { Username = modelo.Username, Email = modelo.Email, Password = modelo.Password };
                AppDatabase.AddClientes(nuevo_cliente);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Username", "Username existente");
            return View();
        }
    }


}
