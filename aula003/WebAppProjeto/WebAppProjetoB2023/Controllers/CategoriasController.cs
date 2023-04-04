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
            new Categoria() {Nome = "Notebooks", CategoriaId = 1 },
            new Categoria() {Nome = "Monitores", CategoriaId = 2 },
            new Categoria() {Nome = "Mouses", CategoriaId = 3 },
            new Categoria() {Nome = "Desktops", CategoriaId = 4 },
            new Categoria() {Nome = "Impressoras", CategoriaId = 5 }
        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
    }
}