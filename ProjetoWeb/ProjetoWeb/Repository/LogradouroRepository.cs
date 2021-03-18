using ProjetoWeb.Data;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Repository
{
    public interface ILogradouroRepository
    {
        
            void Add(Logradouro logradouro);
            List<Logradouro> GetLogradouro();
            List<Logradouro> GetLogradouro(string Profissao, string Endereco);
            Logradouro Get(int Id);
            void Edit(Logradouro logradouro);
            void Delete(int Id);

        
    }
    public class LogradouroRepository : ILogradouroRepository
    {
        //Implementação de Dependeincia da classe AplicationDbContext
        //que serve como persistencia a dados
        private readonly AplicationDbContext db;
        //Construtor
        public LogradouroRepository(AplicationDbContext db)
        {
            this.db = db;
        }
        //Construtor
        //CRUD INICIO
        public void Add(Logradouro logradouro)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Logradouro logradouro)
        {
            throw new NotImplementedException();
        }

        public Logradouro Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Logradouro> GetLogradouro()
        {
            throw new NotImplementedException();
        }

        public List<Logradouro> GetLogradouro(string Profissao, string Endereco)
        {
            throw new NotImplementedException();
        }
        //CRUD FIM
    }
}
