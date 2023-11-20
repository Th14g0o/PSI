using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Imobiliaria.Models
{
    public class Imovel
    {
        public long? ImovelId{get;set;} //Codigo
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public long? TipoId { get; set; }
        public Tipo Tipo { get; set; }
    }
}