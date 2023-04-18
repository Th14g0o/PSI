using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;


namespace WebAppProjetoB2023.Controllers
{
    public class CategoriasController : Controller
    {
      

        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria(){Nome = "Ação", CategoriaId = 1},
            new Categoria(){Nome = "Aventura", CategoriaId = 2},
            new Categoria(){Nome = "RPG", CategoriaId = 3},
            new Categoria(){Nome = "Action-RPG", CategoriaId = 4},
            new Categoria(){Nome = "Terror", CategoriaId = 5},
        
           
        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
        // GET: Categorias
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }
        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(t => t.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(ct => ct.CategoriaId ==  categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
                categorias.Add(categoria);
            }
            catch
            {
                categoria.CategoriaId = 1;
                categorias.Add(categoria);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }
    }
}