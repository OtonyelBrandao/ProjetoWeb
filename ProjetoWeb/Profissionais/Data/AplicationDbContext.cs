using Microsoft.EntityFrameworkCore;
using Profissionais.Models.ModelsDb;

namespace Profissionais.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
        public DbSet<ProfissionaisT> Profissionais { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfissionaisT>().ToTable("Profissionais");
            modelBuilder.Entity<Especialidades>().ToTable("Especialidades");
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");

        }
    }
}
