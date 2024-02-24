using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Orçamento.Data
{
    public class DbConnect : DbContext
    {
        public DbSet<clientes> clientes { get; set; }
        public DbSet<servicos> servicos { get; set; }
        public DbSet<orcamento> orcamento { get; set; }
        public DbSet<item_orcamento> itemOrcamento { get; set; }
        public DbSet<detalhes_orcamento> detalhesOrcamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("User Id=postgres.ueakmklebeudwwairprr;Password=elefantemarinho123;Server=aws-0-sa-east-1.pooler.supabase.com;Port=5432;Database=postgres;");
       
        
    }
}
