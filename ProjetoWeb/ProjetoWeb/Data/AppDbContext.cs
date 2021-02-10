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
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
        private void ConfiguraTerapeuta(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Terapeuta>(etd =>
            {
                etd.ToTable("tbCliente");
                etd.HasKey(t => t.ID).HasName("ID");
                etd.Property(t => t.ID).HasColumnName("ID").ValueGeneratedOnAdd();
                etd.Property(t => t.Nome).HasColumnName("nome").HasMaxLength(100);
                etd.Property(t => t.Titulo).HasColumnName("titulo").HasMaxLength(30);
                etd.Property(t => t.Email).HasColumnName("email").HasMaxLength(75);
                etd.Property(t => t.Tell).HasColumnName("tell").HasMaxLength(15);
                etd.Property(t => t.Endereco).HasColumnName("endereco").HasMaxLength(300);
                etd.Property(t => t.Ativo).HasColumnName("ativo").HasMaxLength(3);
            });
        }
        //public DbSet<Terapeuta> Terapeutas { get; set;}
        //Area dos CRUDs inicio
        //Area dos CRUDs fim
    }
}
