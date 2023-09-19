using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Tabelas;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Modelo.Cadastros
{
    public class Fabricante
    {
        [DisplayName("Codigo")]
        public long FabricanteId { get; set; }
        [StringLength(100, ErrorMessage = "O nome do produto precisa ter no mínimo 10 caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "Informe o nome do Fabricante")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}