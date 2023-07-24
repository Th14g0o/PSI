using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Persistencia.Context;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
        {
            return context.Fabricantes.OrderBy(b => b.Nome);
        }
        public Fabricante ObterFabricantePorId(long id)
        {
            return context.Fabricantes.Where(f => f.FabricanteId == id).Include("Produtos.Categoria").First();
        }
        public void GravarFabricante(Fabricante fabricante)
        {
            Fabricante f = ObterFabricantePorId(fabricante.FabricanteId);
            if (f == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(f).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Fabricante EliminarFabricantePorId(long id)
        {
            Fabricante c = ObterFabricantePorId(id);
            context.Fabricantes.Remove(c);
            context.SaveChanges();
            return c;
        }
    }
}
