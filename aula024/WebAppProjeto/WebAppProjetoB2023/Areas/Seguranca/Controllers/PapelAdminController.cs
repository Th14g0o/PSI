using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Infraestrutura;

namespace WebAppProjetoB2023.Areas.Seguranca.Controllers
{
    public class PapelAdminController : Controller
    {
        private GerenciadorPapel RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorPapel>();

            }
        }
        // GET: Seguranca/PapelAdmin
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
    }
}