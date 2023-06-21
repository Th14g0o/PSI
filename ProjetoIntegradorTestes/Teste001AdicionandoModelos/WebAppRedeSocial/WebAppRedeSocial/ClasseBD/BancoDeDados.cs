using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebAppRedeSocial.Models;

namespace WebAppRedeSocial.Models
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados() : base("LinhaDeConectar")
        {
            Database.SetInitializer<BancoDeDados>(new DropCreateDatabaseIfModelChanges<BancoDeDados>());
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Post> Posts { get; set; }
        

    }
}