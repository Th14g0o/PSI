﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Areas.Seguranca.Data;

namespace WebAppProjetoB2023.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {
        //Identity tem tres tabelas, a a para usuarios, papeis(funções, permissoes) e associarção de papel e usuarios

        // Definição da Propriedade GerenciadorUsuario
        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();

            }
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        // GET: Seguranca/Admin
        [Authorize(Roles = "Administradores")]
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }
        [Authorize(Roles = "Administradores")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administradores")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            // inicia o objeto usuário para visão
            var uvm = new UsuarioViewModel();
            uvm.Id = usuario.Id;
            uvm.Nome = usuario.UserName;
            uvm.Email = usuario.Email;
            return View(uvm);
        }
        [Authorize(Roles = "Administradores")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario
                {
                    UserName = model.Nome,
                    Email = model.Email
                };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if (result.Succeeded)
                { 
                    return RedirectToAction("Index"); 
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = GerenciadorUsuario.FindById(uvm.Id);
                usuario.UserName = uvm.Nome;
                usuario.Email = uvm.Email;
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.
                HashPassword(uvm.Senha);
                IdentityResult result = GerenciadorUsuario.Update(usuario);
                if (result.Succeeded)
                { return RedirectToAction("Index"); }
                else
                { AddErrorsFromResult(result); }
            }
            return View(uvm);
        }
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            Usuario user = GerenciadorUsuario.FindById(usuario.Id);
            if (user != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(user);
                if (result.Succeeded)
                {
                    TempData["Message"] = "O USUARIO " + user.UserName.ToUpper() + " FOI REMOVIDO";
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }


    }
}