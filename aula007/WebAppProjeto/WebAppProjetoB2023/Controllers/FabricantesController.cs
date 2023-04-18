using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;

namespace WebAppProjetoB2023.Controllers
{
    public class FabricantesController : Controller
    {
        // GET: Fabricantes
        private EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.nome));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}