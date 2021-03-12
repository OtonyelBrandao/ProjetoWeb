using ProjetoWeb.Data;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Repository
{
    public interface IEspecialidadesRepository
    {
        void Add(Especialidades especialidades);
        List<Especialidades> GetListEspecialidades();
        Especialidades GetEspecialidade(int IDEspecialidade);
        void DeleteEspecialidades(int IDEspecialidade);
        void UpdateEspecialidades(Especialidades especialidade);
    }
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        private AppDbContext appDbContext;

        public EspecialidadesRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(Especialidades especialidades)
        {
            appDbContext.Entry<Especialidades>(especialidades).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            appDbContext.especialidades.Add(especialidades);
            appDbContext.SaveChanges();
        }

        public void DeleteEspecialidades(int IDEspecialidade)
        {
            var especialidade = appDbContext.especialidades.Find(IDEspecialidade);
            appDbContext.Entry<Especialidades>(especialidade).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            appDbContext.especialidades.Remove(especialidade);
            appDbContext.SaveChanges();
        }

        public Especialidades GetEspecialidade(int IDEspecialidade)
        {
            var especialidade = appDbContext.especialidades.Find(IDEspecialidade);
            return especialidade;
        }

        public List<Especialidades> GetListEspecialidades()
        {
            var especialidades = appDbContext.especialidades.ToList();
            return especialidades;
        }

        public void UpdateEspecialidades(Especialidades especialidade)
        {
            var especialidade1 = appDbContext.especialidades.Find(especialidade.ID);

            appDbContext.Entry<Especialidades>(especialidade1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            especialidade1.Codigo = especialidade.Codigo;
            especialidade1.NomeDaEspecialidade = especialidade.NomeDaEspecialidade;

            appDbContext.especialidades.Update(especialidade1);
            appDbContext.SaveChanges();
            
        }
    }
}
