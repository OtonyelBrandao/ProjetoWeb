using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext()
        {

        }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Terapeuta>(builder =>
            //{
            //    builder.HasKey(t => t.ID);
            //});

        }
        
        //public DbSet<Terapeuta> Terapeutas { get; set;}
        public DbSet<Profissionais> profissionais { get; set; }
        public DbSet<Especialidades> especialidades { get; set; }
    }
}
