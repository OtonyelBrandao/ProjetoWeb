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
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Profissionais> profissionais { get; set; }
        public DbSet<Especialidades> especialidades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profissionais>().ToTable("Profissionais");
            modelBuilder.Entity<Especialidades>().ToTable("Especialidades");
        }
    }
}
