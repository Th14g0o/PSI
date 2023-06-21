using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppRedeSocial.Models
{
    public class Post
    {
        public string DataHoraId { get; set; }
        public string Texto { get; set; }
        public bool Tipo { get; set; }
        public string NomeId { get; set; }
        public Usuario Usuario { get; set; }

        public string TipoDaFoto {get; set;}
        public byte[] ConteudoDaFoto { get; set; }
      
    }
}