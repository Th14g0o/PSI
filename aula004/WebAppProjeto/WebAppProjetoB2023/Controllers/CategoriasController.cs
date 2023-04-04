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
            new Categoria(){Nome = "Ação", IdCategoria = 1},
            new Categoria(){Nome = "Aventura", IdCategoria = 2},
            new Categoria(){Nome = "RPG", IdCategoria = 3},
            new Categoria(){Nome = "Action-RPG", IdCategoria = 4},
            new Categoria(){Nome = "Terror", IdCategoria = 5},
        
           
        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
    }
}