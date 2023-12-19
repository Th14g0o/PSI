using Lojinha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lojinha.Controllers
{
    public class GruposController : Controller
    {
        // GET: Grupos
        EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(context.Grupos.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grupo g)
        {

            context.Grupos.Add(g);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}