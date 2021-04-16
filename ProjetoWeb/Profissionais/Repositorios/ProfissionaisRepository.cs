using Microsoft.EntityFrameworkCore;
using Profissionais.Data;
using Profissionais.Models;
using Profissionais.Models.ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissionais.Repositorios
{
    public interface IProfissionaisRepository
    {
        void Add(ProfissionaisT profissionais);
        Task<List<ProfissionaisT>> GetProfissionais();
        Task<List<ProfissionaisT>> GetProfissionais(Especialidades especialidades);
        Task<List<ProfissionaisT>> GetProfissionais(Endereco endereco);
        List<ProfissionaisT> GetProfissionais(string UF, string Bairro, string IDEspecialidade);
        List<ProfissionaisT> GetProfissionais(Especialidades especialidades, Endereco endereco);
        IQueryable<ProfissionaisT> GetBuscarProfissionais(Especialidades especialidades, Endereco endereco);
        Task<ProfissionaisT> Get(int? Id);
        Task<string> Edit(ProfissionaisT profissionais);
        void Delete(int Id);

    }
    public class ProfissionaisRepository : IProfissionaisRepository
    {
        //Implementação de Dependeincia da classe AplicationDbContext
        //que serve como persistencia a dados
        private AplicationDbContext db; /*<-- Declaração do contexto*/

        //Construtor ---
        public ProfissionaisRepository(AplicationDbContext db)
        {
            this.db = db;
        }
        //Construtor ---

        //CRUD INICIO
        /// <summary>
        /// Cadastra um profissional no banco
        /// </summary>
        /// <param name="profissionais">Tem Como unico parametro uma entidade de ProfissionaisT</param>
        public async void Add(ProfissionaisT profissionais)
        {
            db.Add(profissionais);
            await db.SaveChangesAsync();
        }
        /// <summary>
        /// Deletata um profissional do banco
        /// </summary>
        /// <param name="Id">Tem como unico parametro o Id do profissional</param>
        public async void Delete(int Id)
        {
            var profissionais = await db.Profissionais.FindAsync(Id);
            db.Profissionais.Remove(profissionais);
            await db.SaveChangesAsync();
        }
        /// <summary>
        /// Faz o Update de um profissional no banco
        /// </summary>
        /// <param name="profissionais"> Tem como unico parametro uma entidade de ProfissionaisT</param>
        /// <returns>Retorna um string</returns>
        public async Task<string> Edit(ProfissionaisT profissionais)
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
        /// <summary>
        /// Buasca um profissional pelo Id.
        /// </summary>
        /// <param name="Id">Como unico parametro Tem um int? Id.</param>
        /// <returns>Retorna uma entidade de ProfissionaisT.</returns>
        public async Task<ProfissionaisT> Get(int? Id)
        {
            var profissionais = await db.Profissionais
                .FirstOrDefaultAsync(m => m.Id == Id);
            return profissionais;
        }
        /// <summary>
        /// Faz uma busca Customizada no banco nas tabelas profissionais e especialidades
        /// </summary>
        /// <param name="especialidades">Recebe uma entidade de Especialidades como parametro</param>
        /// <param name="endereco">Recebe uma entidade de Endereco como parametro</param>
        /// <returns>Retorna um IQueryable<ProfissionaisT></returns>
        public IQueryable<ProfissionaisT> GetBuscarProfissionais(Especialidades especialidades, Endereco endereco)
        {
            var profissionais = db.Profissionais.Where(p => p.Cidade == endereco.Cidade);
            var especialidadesLista = db.Especialidades.Where(e => e.Codigo == especialidades.Codigo);
            var proFiltrados = from prof in profissionais
                               from esp in especialidadesLista
                               where esp.Profissionais.Id == prof.Id
                               select (prof);
            return proFiltrados;
        }

        public async Task<List<ProfissionaisT>> GetProfissionais()
        {
            var ListaDeProfissionais = await db.Profissionais.ToListAsync();
            return ListaDeProfissionais;
        }

        public async Task<List<ProfissionaisT>> GetProfissionais(Especialidades especialidades)
        {
            //Buscandi Lista de Especialidase que tenhão o mesmo Codigo Da Especialidade Recebida
            var especialidadesLista = await db.Especialidades.Where(e => e.Codigo == especialidades.Codigo).ToListAsync();

            //Criando Lista De Profissionais
            List<ProfissionaisT> profissionais = new List<ProfissionaisT>();

            //Alimentando Lista DeProfissionais
            foreach (var profissional in especialidadesLista)
            {
                //Verificando Se A Especialidades Esta Relacionada a Um Profissional
                if (await db.Profissionais.FindAsync(profissional.Profissionais.Id) != null)
                {
                    //Adicionando Profissional
                    profissionais.Add(profissional.Profissionais);
                }
            }
            return profissionais;
        }

        public async Task<List<ProfissionaisT>> GetProfissionais(Endereco endereco)
        {
            var profissionais = await db.Profissionais.Where(p =>
                p.Cidade == endereco.Cidade ||
                p.UF == endereco.UF).ToListAsync();
            return profissionais;
        }

        public List<ProfissionaisT> GetProfissionais(Especialidades especialidades, Endereco endereco)
        {
            var especialidadesLista = db.Especialidades.Where(e => e.Codigo == especialidades.Codigo).ToList();

            var profissionaisLista = db.Profissionais.Where(
                p => p.Cidade == endereco.Cidade &&
                p.UF == endereco.UF).ToList();

            //Criando Lista De Profissionais
            List<ProfissionaisT> profissionais = new List<ProfissionaisT>();

            //Alimentando Lista DeProfissionais
            foreach (var profissional in especialidadesLista)
            {
                //Verificando Se A Especialidades Esta Relacionada a Um Profissional
                foreach (var profissionaldb in profissionaisLista)
                {
                    //Procurando Profissional numa Lista Já filtrada
                    if (profissional.Profissionais != null)
                    {
                        if (profissionaldb.Id == profissional.Profissionais.Id)
                        {
                            //Adicionando Profissional
                            profissionais.Add(profissional.Profissionais);
                        }

                    }
                }
            }

            return profissionais;
        }

        public List<ProfissionaisT> GetProfissionais(string UF, string Cidade, string IDEspecialidade)
        {
            var especialidade = db.Especialidades.Find(Convert.ToInt32(IDEspecialidade));
            var especialidades = from esp in db.Especialidades
                                 where esp.NomeDaEspecialidade == especialidade.NomeDaEspecialidade
                                 select esp;
            var profissionais = from pro in db.Profissionais
                                from esp in especialidades
                                where esp.Profissionais.Id == pro.Id &&
                                pro.UF == UF && pro.Cidade == Cidade
                                select pro;
            var Pro = profissionais.ToList();
            return Pro;
        }
        //CRUD FIM
    }
}
