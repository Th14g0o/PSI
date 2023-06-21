using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppRedeSocial.Controllers
{
    public class PostagensController : Controller
    {
        // GET: Postagens
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PostagemDetalhadaMidias()
        {
            return View();
        }
        public ActionResult PostagemDetalhadaTextos()
        {
            return View();
        }
    }
}