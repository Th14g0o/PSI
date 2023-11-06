using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppProjetoB2023.Areas.Seguranca.Data;
using WebAppProjetoB2023.DAL;

namespace WebAppProjetoB2023.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("IdentityDb")
        { }
        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(
            new IdentityDbInit());
        }
        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }

    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
    { }

}
