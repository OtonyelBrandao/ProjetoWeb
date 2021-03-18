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
        Task<List<Profissionais>> GetProfissionais();
        Task<List<Profissionais>> GetProfissionais(string Profissao, string Endereco);
        Task<Profissionais> Get(int? Id);
        Task<string> Edit(Profissionais profissionais);
        void Delete(int Id);

    }
    public class ProfissionaisRepository : IProfissionaisRepository
    {
        //Implementação de Dependeincia da classe AplicationDbContext
        //que serve como persistencia a dados
        private AplicationDbContext db; /*<-- Declaração do contexto*/

        //Construtor ---
        public ProfissionaisRepository( AplicationDbContext db)
        {
            this.db = db;
        }
        //Construtor ---

        //CRUD INICIO
        public async void Add(Profissionais profissionais)
        {
            db.Add(profissionais);
            await db.SaveChangesAsync();
        }
        public async void Delete(int Id)
        {
            var profissionais = await db.profissionais.FindAsync(Id);
            db.profissionais.Remove(profissionais);
            await db.SaveChangesAsync();
        }
        public async Task<string> Edit(Profissionais profissionais)
        {
            try
            {
                db.Update(profissionais);
                await db.SaveChangesAsync();
                return "1";
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }
            
        }
        public async Task<Profissionais> Get(int? Id)
        {
            var profissionais = await db.profissionais
                .FirstOrDefaultAsync(m => m.Id == Id);
            return profissionais;
        }
        public async Task<List<Profissionais>> GetProfissionais()
        {
            var ListaDeProfissionais = await db.profissionais.ToListAsync();
            return ListaDeProfissionais;
        }
        public async Task<List<Profissionais>> GetProfissionais(string Especialidade, string Endereco)
        {
            List<Profissionais> Resultado = new List<Profissionais>();
            //List<Profissionais> profissional = db.profissionais.Where(T => T.Endereco == Endereco).ToList<Profissionais>();
            //Resultado = profissional;
            return Resultado;
        }
        //CRUD FIM
    }
}
