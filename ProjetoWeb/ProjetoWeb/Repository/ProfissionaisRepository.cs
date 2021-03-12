using ProjetoWeb.Data;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Repository
{
    public interface IProfissionaisRepository
    {
        void Add(Profissionais profissionais);
        List<Profissionais> GetListProfissionais();
        Profissionais GetProfissional();
        void DeleteProfissionais(int IDProfissional);
        void UpdateProfissionais(Profissionais profissionais);
    }
    public class ProfissionaisRepository : IProfissionaisRepository
    {
        private AppDbContext appDbContext;
        public ProfissionaisRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Add(Profissionais profissionais)
        {
            appDbContext.Entry<Profissionais>(profissionais).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            appDbContext.profissionais.Add(profissionais);
            appDbContext.SaveChanges();
        }
        public void DeleteProfissionais(int IDProfissional)
        {
            var profissional = appDbContext.profissionais.Find(IDProfissional);
            appDbContext.Entry<Profissionais>(profissional).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            appDbContext.profissionais.Remove(profissional);
            appDbContext.SaveChanges();
        }
        public List<Profissionais> GetListProfissionais()
        {
            var profissionais = appDbContext.profissionais.ToList();
            return profissionais;
        }

        public Profissionais GetProfissional(int IDProfissional)
        {
            var profissional = appDbContext.profissionais.Find(IDProfissional);
            return profissional;
        }

        public void UpdateProfissionais(Profissionais profissionais)
        {
            var profissional = appDbContext.profissionais.Find(profissionais.ID);
            appDbContext.Entry<Profissionais>(profissional).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.profissionais.Update(profissional);
            appDbContext.SaveChanges();
        }
    }
}
