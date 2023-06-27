using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppRedeSocial.Models
{
    public class Usuario
    {
     
        public string UsuarioId { get; set; }
        public string NomeVisivel { get; set; }
        public int Matricula { get; set; }
        public char Senha { get; set; }
        public char Email { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public ICollection<Post> Posts { get; set; }
        public string TipoDaFoto { get; set; }
        public byte[] ConteudoDaFoto { get; set; }
    }
}