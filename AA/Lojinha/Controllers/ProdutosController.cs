using Lojinha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lojinha.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        EFContext context = new EFContext();
        public ActionResult Index()
        {
            
            
            return View(context.Produtos.OrderBy(p => p.Descricao).Include(P => P.Grupo));
        }
        public ActionResult Update(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto p = context.Produtos.OrderBy(produto => produto.Descricao).Include(P => P.Grupo).Where(pro => pro.Codigo == id).First();
            if (p == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoId = new SelectList(context.Grupos.OrderBy(c => c.GrupoId), "GrupoId", "Nome");
            return View(p);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Produto p)
        {
            if (ModelState.IsValid)
            {
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Create()
        {
            ViewBag.GrupoId = new SelectList(context.Grupos.OrderBy(c => c.GrupoId), "GrupoId", "Nome");


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto p)
        {

            context.Produtos.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        


        
        
    }
}