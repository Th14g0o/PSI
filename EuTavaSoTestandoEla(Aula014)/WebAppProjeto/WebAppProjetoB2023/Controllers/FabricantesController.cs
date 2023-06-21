using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;
using System.Net; // pro " new HttpStatusCodeResult(HttpStatusCode.BadRequest) " funcionar
using System.Data.Entity;

namespace WebAppProjetoB2023.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(long? id)
        {//a interrogação indica que esse parametro não é obrigatorio
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);// se não achar retorna um valor nulo
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Where(f => f.FabricanteId == id).Include("Produtos.Categoria").First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante, HttpPostedFileBase arquivo = null, string chkRemoverImagem = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (chkRemoverImagem != null)
                    {
                        fabricante.Logotipo = null;
                    }
                    if (arquivo != null)
                    {
                        fabricante.LogotipoMimeType = arquivo.ContentType; //salvando o tipo do arquivo
                        fabricante.Logotipo = SetLogoTipo(arquivo);//salvando os bytes, conteudo
                    }
                    context.Fabricantes.Add(fabricante);
                    context.SaveChanges();
                    TempData["Message"] = "O FABRICANTE " + fabricante.Nome.ToUpper() + " FOI ADICIONADO";
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }

           
            
        }
        [HttpPost]
        public ActionResult Edit(Fabricante fabricante, HttpPostedFileBase arquivo = null, string chkRemoverImagem = null)
        {
            try
            {
                if (ModelState.IsValid)//verifica se esse objeto foi preenchido corretamente
                {
                    if (chkRemoverImagem != null)
                    {
                        fabricante.Logotipo = null;
                    }
                    if (arquivo != null)
                    {
                        fabricante.LogotipoMimeType = arquivo.ContentType;
                        fabricante.Logotipo = SetLogoTipo(arquivo);
                    }

                  
                    context.Entry(fabricante).State = EntityState.Modified;       
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            TempData["Message"] = "O FABRICANTE " + fabricante.Nome.ToUpper() + " FOI DELETADO";
            return RedirectToAction("Index");
        }
        //Metodos
        private byte[] SetLogoTipo(HttpPostedFileBase arquivo)
        {
            var bytesFile = new byte[arquivo.ContentLength];
            arquivo.InputStream.Read(bytesFile, 0, arquivo.ContentLength);
            return bytesFile;
        }
        public FileContentResult GetLogoTipo(long id)
        {
            Fabricante f = context.Fabricantes.Find(id);
            if (f != null)
            {
                return File(f.Logotipo, f.LogotipoMimeType);
            }
            return null;
        }

        //
    }
}