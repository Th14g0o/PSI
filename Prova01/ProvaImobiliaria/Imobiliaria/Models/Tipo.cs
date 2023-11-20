using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Imobiliaria.Models
{
    public class Tipo
    {
        public long TipoId{get;set;} //codigo
        public int TipoOpera { get; set; }//venda = 0, locação = 1
        public string Nome { get; set; }//venda = 0, locação = 1
    }
}