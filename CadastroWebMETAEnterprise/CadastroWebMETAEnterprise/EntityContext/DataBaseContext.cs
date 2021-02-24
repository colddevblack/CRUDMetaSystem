using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CadastroWebMETAEnterprise.Models;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlClient;

namespace CadastroWebMETAEnterprise.EntityContext
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("ConnectionMetaSystem") { }
        public virtual DbSet<ClienteModel> clientedb { get; set; }
        public virtual DbSet<ProdutoModel> produtodb { get; set; }

        public virtual DbSet<OrcamentoModel> orcadb { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

         
            modelBuilder.Entity<ClienteModel>()
                .HasMany(e => e.orcaclientelist)
                .WithRequired(e => e.clientemodel)
                .HasForeignKey(e => e.clienteid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProdutoModel>()
               .HasMany(e => e.orcamentosprodutoslist)
               .WithRequired(e => e.produtomodel)
               .HasForeignKey(e => e.produtoid)
               .WillCascadeOnDelete(false);


        }
    }

}