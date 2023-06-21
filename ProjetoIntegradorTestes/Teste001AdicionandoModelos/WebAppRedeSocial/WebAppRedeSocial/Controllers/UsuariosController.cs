using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRedeSocial.Models;

namespace WebAppRedeSocial.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        BancoDeDados bd = new BancoDeDados();
        // GET: MeuPerfil
        public ActionResult MeuPerfilMidias()
        {
            return View();
        }
        public ActionResult MeuPerfilTextos()
        {
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
        public ActionResult Notificados()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult CriarPerfil()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult OutroPerfilMidia()
        {
            return View();
        }
        public ActionResult OutroPerfilTexto()
        {
            return View();
        }
    }
}