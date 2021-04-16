using Profissionais.Data;
using Profissionais.Models.ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissionais.Repositorios
{
    public interface IEspecialidadesRepository
    {
        void Add(Especialidades Especialidades);
        List<Especialidades> GetEspecialidades();
        IEnumerable<Especialidades> GetEspecialidades(ProfissionaisT profissionais);
        List<Especialidades> GetEspecialidades(string Profissao, string Endereco);
        Task<Especialidades> GetEspecialidades(int Id);
        IQueryable<Especialidades> GetEspecialidades(string local);
        List<Especialidades> GetEspecialidades(Especialidades especialidades);
        void Edit(Especialidades especialidades);
        void Delete(int IDEspecialidades);
    }
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        //Implementação de Dependeincia da classe AplicationDbContext
        //que serve como persistencia a dados
        private AplicationDbContext db;
        //Construtor
        public EspecialidadesRepository(AplicationDbContext db)
        {
            this.db = db;
        }
        //Construtor
        //CRUD INICIO
        public void Add(Especialidades Especialidades)
        {
            throw new NotImplementedException();
        }

        public void Delete(int IDEspecialidades)
        {
            throw new NotImplementedException();
        }

        public void Edit(Especialidades especialidades)
        {
            throw new NotImplementedException();
        }

        public List<Especialidades> GetEspecialidades()
        {
            var especialidades = db.Especialidades.Where(e => e.Profissionais == null);
            List<Especialidades> especialidades2 = especialidades.ToList();

            return especialidades2;
        }
        public List<Especialidades> GetEspecialidades(string Profissao, string Endereco)
        {
            throw new NotImplementedException();
        }

        public async Task<Especialidades> GetEspecialidades(int Id)
        {
            var especialidade = await db.Especialidades.FindAsync(Id);
            return especialidade;
        }
        public IEnumerable<Especialidades> GetEspecialidades(ProfissionaisT profissionais)
        {
            var especialidades = db.Especialidades.Where(e => e.Profissionais == profissionais);
            return especialidades;
        }
        public List<Especialidades> GetEspecialidades(Especialidades especialidade)
        {
            if (especialidade != null)
            {
                var especialidades = db.Especialidades.Where(e => e.Codigo == especialidade.Codigo).ToList();
                return especialidades;
            }
            return null;
        }
        public IQueryable<Especialidades> GetEspecialidades(string local)
        {
            var especialidades = from pro in db.Profissionais
                                 from esp in db.Especialidades
                                 where pro.Id == esp.Profissionais.Id
                                 && (pro.UF == local || pro.Cidade == local)
                                 select (esp);
            List<Especialidades> especialidadeList = new List<Especialidades>();
            foreach (var item in especialidades)
            {
                if (especialidadeList.Count == 0)
                {
                    especialidadeList.Add(item);
                }
                else
                {
                    int contem = 0;
                    foreach (var item1 in especialidadeList)
                    {
                        if (item1.Codigo == item.Codigo)
                        {
                            contem = 1;
                        }

                    }
                    if (contem == 0)
                    {
                        especialidadeList.Add(item);
                    }
                }
            }
            return especialidadeList.AsQueryable();

        }
        //CRUD FIM
    }
}
