using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProjetoB2023.Models
{
    public class Produto
    {
        public long? ProdutoId { get; set; }
        public string Nome { get; set; }

        public long? CategoriaId { get; set; } // chave estrangeira
        public long? FabricanteId { get; set; }

        public Categoria Categoria { get; set; }// para carregar o objeto com o auxilio da chave estrangeiro
        public Fabricante Fabricante { get; set; }

        public string LogotipoMimeType { get; set; } //pega o tipo(png, jpg,mp4, html,css...) - MimeType são os tipos de arquivo que o navegador pode mostrar
        public byte[] Logotipo { get; set; }// Pega os bytes da imagem, pixeis, conteudo
        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }

    }
}