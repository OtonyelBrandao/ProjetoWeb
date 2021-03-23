using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        void Add(Especialidades Especialidades);
        IEnumerable<Especialidades> GetEspecialidades();
        List<Especialidades> GetEspecialidades(string Profissao, string Endereco);
        Task<Especialidades> GetEspecialidades(int Id);
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

        public IEnumerable<Especialidades> GetEspecialidades()
        {
            IEnumerable<Especialidades> especialidades =  db.especialidades;
            return especialidades;
        }

        public List<Especialidades> GetEspecialidades(string Profissao, string Endereco)
        {
            throw new NotImplementedException();
        }

        public async Task<Especialidades> GetEspecialidades(int Id)
        {
            var especialidade = await db.especialidades.FindAsync(Id);
            return especialidade;
        }
        //CRUD FIM
    }
}
