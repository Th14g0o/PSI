using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Lojinha.Models
{
    public class Produto
    {
        [Key]
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public long? GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public double Valor { get; set; }
    }
}