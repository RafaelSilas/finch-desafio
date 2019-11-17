using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repositorio
{
    public class ProtestoContext : DbContext
    {
     
        public DbSet<Devedores> Devedores{ get; set; }
        public DbSet<Bancos> Bancos { get; set; }
        public DbSet<UFs> Ufs { get; set; }
        public DbSet<Cidades> Cidades { get; set; }
        public DbSet<DevedoresEnderecos> DevedoresEnderecos { get; set; }
        public DbSet<PracasPagamentos> PracasPagamentos { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<ContratosParcelas> ContratosParcelas { get; set; }
        public DbSet<Protestos> Protestos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=Protesto;Data Source=LAPTOP-377IADQP\\SQLEXPRESS");
        }
    }
}
