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
        private void ConfiguraTerapeuta(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Profissionais>(etd =>
            {
                etd.ToTable("tbCliente");
                etd.HasKey(t => t.Id).HasName("ID");
                etd.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                etd.Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(100);
                etd.Property(t => t.Telefone).HasColumnName("Telefone").HasMaxLength(15);
                etd.Property(t => t.Endereco).HasColumnName("Endereco").HasMaxLength(300);
                etd.Property(t => t.Nascimento).HasColumnName("Nascimento");
                etd.Property(t => t.WhatsApp).HasColumnName("WhatsApp");
            });
        }
        //public DbSet<Terapeuta> Terapeutas { get; set;}
        public DbSet<Profissionais> profissionais { get; set; }
        //Area dos CRUDs inicio
        //Area dos CRUDs fim
    }
}
