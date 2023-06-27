using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjetoB2023.Models;
using System.Data.Entity;
using System.Net;
using System.IO;

namespace WebAppProjetoB2023.Controllers
{
    //MVC witch read/write ja cria o post com os http get e post
    //
    public class ProdutosController : Controller
    {
        EFContext context = new EFContext();
        public ActionResult Index()
        {
            var produtos = context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
            //return View(context.Produtos.OrderBy(p => p.Nome));
            return View(produtos);
        }
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
            //ViewBag.chave_estrangeira = new SelectList(context.tabela.OrderBy(c => c.Nome), "chave", "mascara/nome_visivel");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");
            return View();
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto p = context.Produtos.Find(id);
            if (p == null)
                return HttpNotFound();
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome", p.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome", p.FabricanteId);
            return View(p);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Produto p = context.Produtos.Where(pr => pr.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (p == null)
                HttpNotFound();
            return View(p);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Produto p = context.Produtos.Where(pr => pr.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (p == null)
                HttpNotFound();
            return View(p);
        }


        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        [HttpPost]
        public ActionResult Edit(Produto produto,
HttpPostedFileBase logotipo = null, string chkRemoverImagem = null)
        {
            return GravarProduto(produto, logotipo, chkRemoverImagem);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Produto p = context.Produtos.Find(id);
                context.Produtos.Remove(p);
                context.SaveChanges();
                TempData["Message"] = "O PRODUTO " + p.Nome.ToUpper() + " FOI REMOVIDO";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Metodos

        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoId == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        private void PopularViewBag(Produto produto = null)
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome", produto.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome", produto.FabricanteId);
        }
        private byte[] SetLogotipo(HttpPostedFileBase logotipo)
        {
            var bytesLogotipo = new byte[logotipo.ContentLength];//reservou espaço para os conteudos do byte(arquivo)
            logotipo.InputStream.Read(bytesLogotipo, 0 , logotipo.ContentLength);//pega o conteudo
            return bytesLogotipo;

        }
        public Produto ObterProdutoPorId(long id)//Encontra o Produto com a imagem
        {
            return context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).
            Include(f => f.Fabricante).First();
        }
        public FileContentResult GetLogotipo(long id)//retorna a imagem, do BD
        {
            Produto produto = ObterProdutoPorId(id);
            if (produto != null)
            {
                return File(produto.Logotipo, produto.LogotipoMimeType);
            }
            return null;
        }
        public FileContentResult GetLogotipo2(long id)//retira do servidor
        {
            Produto produto = ObterProdutoPorId(id);
            if (produto != null)
            {
                if (produto.NomeArquivo != null)
                {
                    var bytesLogotipo = new byte[produto.TamanhoArquivo];
                    FileStream fileStream = new
                    FileStream(Server.MapPath("~/App_Data/" + produto.NomeArquivo), FileMode.Open,
                    FileAccess.Read);
                    fileStream.Read(bytesLogotipo, 0, (int)produto.TamanhoArquivo);
                    return File(bytesLogotipo, produto.LogotipoMimeType);
                }
            }
            return null;
        }
        public ActionResult DownloadArquivo(long id)//salvar localmente, retira do bd
        {
            try
            {
                Produto produto = ObterProdutoPorId(id);
                FileStream fileStream = new FileStream(Server.MapPath(
                "~/App_Data/" + produto.NomeArquivo), FileMode.Create, FileAccess.Write);//cria um arquivo na pasta padrao
                fileStream.Write(produto.Logotipo, 0, Convert.ToInt32(produto.TamanhoArquivo));
                fileStream.Close();
                return File(fileStream.Name, produto.LogotipoMimeType, produto.NomeArquivo);
            }
            catch
            {
                return RedirectToAction("Edit/" + id.ToString());
            }
            
        }
        public ActionResult DownloadArquivo2(long id)//salvar localmente, retira do servidor
        {
            Produto produto = ObterProdutoPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath("~/App_Data/" + produto.NomeArquivo), FileMode.Open, FileAccess.Read);
            return File(fileStream.Name, produto.LogotipoMimeType, produto.NomeArquivo);
        }
        
        
        private ActionResult GravarProduto(Produto produto, HttpPostedFileBase logotipo, string chkRemoverImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (chkRemoverImagem != null)
                    {
                        produto.Logotipo = null;
                    }
                    if (logotipo != null)
                    {
                        produto.LogotipoMimeType = logotipo.ContentType;
                        produto.Logotipo = SetLogotipo(logotipo);
                        produto.NomeArquivo = logotipo.FileName;
                        produto.TamanhoArquivo =logotipo.ContentLength;
                        //salva no BD


                        string strFileName = Server.MapPath("~/App_Data/") + Path.GetFileName(logotipo.FileName);
                        logotipo.SaveAs(strFileName);
                        //salva no local

                        //se os dis tiverem aqui o arquivo duplica
                    }
                    GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                PopularViewBag(produto);
                return View(produto);
            }
        }

        //Termina aqui
    }
}
