using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Cadastros;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Modelo.Tabelas
{
    public class Categoria
    {
        [DisplayName("Codigo")]
        public long CategoriaId { get; set; }
        [StringLength(100, ErrorMessage = "O nome do produto precisa ter no mínimo 10 caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        //I relaciona ao conceito de interface. Assinatura nome e paremetros de um metodo
    }
}