using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lojinha.Models
{
    public class Grupo
    {
        [Key]
        public long GrupoId { get; set; }
        public string Nome { get; set; }

    }
}