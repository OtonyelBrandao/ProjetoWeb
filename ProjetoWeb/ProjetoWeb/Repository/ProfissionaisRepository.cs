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
    public interface IProfissionaisRepository
    {
        void Add(Profissionais profissionais);
        List<Profissionais> GetProfissionais();
        List<Profissionais> GetProfissionais(string Profissao, string Endereco);
        Profissionais Get(int Id);
        void Edit(Profissionais profissionais);
        void Delete(int Id);

    }
    public class ProfissionaisRepository : IProfissionaisRepository
    {
        private IConfiguration _configuration; /*<-- Declaração do IConfiguration*/
        private AplicationDbContext db; /*<-- Declaração do contexto*/

        //Construtor ---
        public ProfissionaisRepository(IConfiguration configuration, AplicationDbContext db)
        {
            _configuration = configuration;
            this.db = db;
        }
        //Construtor ---

        //CRUD --- --- --- ---
        public void Add(Profissionais profissionais)
        {
            //string query = "INSERT INTO Terapeutas(Nome, Endereco, Email, Telefone, Nascimento) VALUES(@Terapeutas.Nome, @Terapeutas.Endereco, @Terapeutas.Email, @Terapeutas.Telefone ,@Terapeutas.Nascimento); SELECT CAST(SCOPE_IDENTITY() as INT); ";
            //SqlCommand cmd = new SqlCommand(query, con);
        }
        public void Delete(int Id)
        {
            Profissionais profissional = db.profissionais.Find(Id);
            
        }
        public void Edit(Profissionais profissionais)
        {
        }
        public Profissionais Get(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Profissionais>> GetProfissionais()
        {
            var ListaDeProfissionais = await db.profissionais.ToListAsync();
            return ListaDeProfissionais;
        }
        public List<Profissionais> GetProfissionais(string Especialidade, string Endereco)
        {
            List<Profissionais> Resultado = new List<Profissionais>();
            //List<Profissionais> profissional = db.profissionais.Where(T => T.Endereco == Endereco).ToList<Profissionais>();
            //Resultado = profissional;
            return Resultado;
        }
        //CRUD --- --- --- ---
    }
}
