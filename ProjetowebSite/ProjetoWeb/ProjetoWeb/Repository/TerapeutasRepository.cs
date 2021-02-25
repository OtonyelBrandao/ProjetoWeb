using Microsoft.Extensions.Configuration;
using ProjetoWeb.Data;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoWeb.Repository
{
    public class TerapeutasRepository : ITerapeutasReporitory
    {
        private IConfiguration _configuration; /*<-- Declaração do IConfiguration*/
        private AplicationDbContext db; /*<-- Declaração do contexto*/

        //Construtor ---
        public TerapeutasRepository(IConfiguration configuration, AplicationDbContext db)
        {
            _configuration = configuration;
            this.db = db;
        }
        //Construtor ---

        //CRUD --- --- --- ---
        public void Add(Terapeutas terapeutas)
        {
            //string query = "INSERT INTO Terapeutas(Nome, Endereco, Email, Telefone, Nascimento) VALUES(@Terapeutas.Nome, @Terapeutas.Endereco, @Terapeutas.Email, @Terapeutas.Telefone ,@Terapeutas.Nascimento); SELECT CAST(SCOPE_IDENTITY() as INT); ";
            //SqlCommand cmd = new SqlCommand(query, con);
        }
        public void Delete(int Id)
        {
            Terapeutas terapeuta = db.Terapeutas.Find(Id);
        }
        public void Edit(Terapeutas terapeutas)
        {
        }
        public Terapeutas Get(int Id)
        {
            throw new NotImplementedException();
        }
        public List<Terapeutas> GetTerapeutas()
        {
            List<Terapeutas> Resultado = new List<Terapeutas>();
            List<Terapeutas> terapeuta = db.Terapeutas.ToList<Terapeutas>();
            Resultado = terapeuta;
            return Resultado;
        }
        public List<Terapeutas> GetTerapeutas(string Profissao, string Endereco)
        {
            List<Terapeutas> Resultado = new List<Terapeutas>();
            List<Terapeutas> terapeuta = db.Terapeutas.Where(T => T.Endereco == Endereco).ToList<Terapeutas>();
            Resultado = terapeuta;
            return Resultado;
        }
        //CRUD --- --- --- ---
    }
}
