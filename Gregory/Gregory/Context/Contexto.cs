using Gregory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Gregory.Context
{
    public class Contexto : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<FornecedorModel> Fornecedores { get; set; }
        public DbSet<RoupaModel> Roupas { get; set; }


        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

    }
}