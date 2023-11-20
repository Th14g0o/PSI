using Imobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Imobiliaria.Controllers
{
    public class TiposController : Controller
    {
        // GET: Tipos
        private EFContext context = new EFContext();
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo t)
        {

            context.Tipos.Add(t);
            context.SaveChanges();
            return RedirectToAction("Index", "Imoveis");
        }
    }
}