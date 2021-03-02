using Microsoft.Extensions.Configuration;
using ProjetoWeb.Data;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoWeb.Repository
{
    public class ProfissionaisRepository : IProfissionaisReporitory
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
        public List<Profissionais> GetProfissionais()
        {
            List<Profissionais> Resultado = new List<Profissionais>();
            List<Profissionais> profissional = db.profissionais.ToList<Profissionais>();
            Resultado = profissional;
            return Resultado;
        }
        public List<Profissionais> GetProfissionais(string Especialidade, string Endereco)
        {
            List<Profissionais> Resultado = new List<Profissionais>();
            List<Profissionais> profissional = db.profissionais.Where(T => T.Endereco == Endereco).ToList<Profissionais>();
            Resultado = profissional;
            return Resultado;
        }
        //CRUD --- --- --- ---
    }
}
