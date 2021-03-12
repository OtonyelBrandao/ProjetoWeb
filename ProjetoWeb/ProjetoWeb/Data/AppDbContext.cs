using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Profissionais> profissionais { get; set; }
        public DbSet<Especialidades> especialidades { get; set; }
        protected AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        //{
        //}
        //private void Configurar(ModelBuilder construtorDeModelos)
        //{
        //    construtorDeModelos.Entity<Profissionais>(etd =>
        //    {
        //        etd.ToTable("tbProfissionais");
        //        etd.HasKey(t => t.ID).HasName("ID");
        //        etd.Property(t => t.ID).HasColumnName("IDProfissional").ValueGeneratedOnAdd();
        //        etd.Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(100);
        //        etd.Property(t => t.Nascimento).HasColumnName("Nascimento").HasMaxLength(200);
        //        etd.Property(t => t.Telefone).HasColumnName("Tell").HasMaxLength(15);
        //        etd.Property(t => t.WhatsApp).HasColumnName("WhatsApp").HasMaxLength(15);
        //    });
        //    construtorDeModelos.Entity<Especialidades>(etd =>
        //    {
        //        etd.ToTable("tbEspecialidades");
        //        etd.HasKey(t => t.ID).HasName("ID");
        //        etd.Property(t => t.ID).HasColumnName("IDEspecialidade").ValueGeneratedOnAdd();
        //        etd.Property(t => t.NomeDaEspecialidade).HasColumnName("Nome").HasMaxLength(100);
        //        etd.Property(t => t.Codigo).HasColumnName("Codigo").HasMaxLength(4);
        //    });
        //}
    }
}
