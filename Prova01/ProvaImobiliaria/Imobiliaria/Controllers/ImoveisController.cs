using Imobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Imobiliaria.Controllers
{
    public class ImoveisController : Controller
    {
        // GET: Imoveis
        private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Imoveis.OrderBy(i => i.Descricao).Include(im => im.Tipo));
        }

        public ActionResult Create()
        {
            ViewBag.TipoId = new SelectList(context.Tipos.OrderBy(c => c.TipoId), "TipoId", "Nome");
           
    
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Imovel i)
        {
            
            context.Imoveis.Add(i);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel i = context.Imoveis.Where(im => im.ImovelId == id).Include(c => c.Tipo).First();

            if (i == null)
            {
                return HttpNotFound();
            }
            return View(i);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel i = context.Imoveis.Find(id);
            if (i == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoId = new SelectList(context.Tipos.OrderBy(c => c.TipoId), "TipoId", "Nome");
            return View(i);
        }
        
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel i = context.Imoveis.Where(im => im.ImovelId == id).Include(c => c.Tipo).First();
            if (i == null)
            {
                return HttpNotFound();
            }
            return View(i);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Imovel i)
        {
            if (ModelState.IsValid)
            {
                context.Entry(i).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(i);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Imovel i = context.Imoveis.Find(id);
            context.Imoveis.Remove(i);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}