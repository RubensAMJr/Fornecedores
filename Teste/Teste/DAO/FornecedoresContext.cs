using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.DAO
{
    public class FornecedoresContext : DbContext
    {
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FornecedoresDb;Trusted_Connection=true;");
        }
    }

}
