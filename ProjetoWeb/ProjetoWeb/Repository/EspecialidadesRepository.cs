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
        List<Especialidades> GetEspecialidades();
        List<Especialidades> GetEspecialidades(string Profissao, string Endereco);
        Especialidades GetEspecialidades(int Id);
        void Edit(Especialidades especialidades);
        void Delete(int IDEspecialidades);

    }
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        //Implementação de Dependeincia da classe AplicationDbContext
        //que serve como persistencia a dados
        private readonly AplicationDbContext DB;
        //Construtor
        public EspecialidadesRepository(AplicationDbContext dB)
        {
            DB = dB;
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
            throw new NotImplementedException();
        }

        public List<Especialidades> GetEspecialidades(string Profissao, string Endereco)
        {
            throw new NotImplementedException();
        }

        public Especialidades GetEspecialidades(int Id)
        {
            throw new NotImplementedException();
        }
        //CRUD FIM
    }
}
