using Profissionais.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profissionais.Repositorios
{
    public interface IBuscaRepository
    {
        IQueryable<string> GetCidades(string Especialidade, string UF);
        IQueryable<string> GetCidadesUFs(string UF);
        IQueryable<string> GetCidadesEspecialidade(string Especialidade);
        IQueryable<string> GetUFs(string Especialidade);
    }
    public class BuscaRepository : IBuscaRepository
    {
        private readonly AplicationDbContext _context;

        public BuscaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<string> GetCidades(string Especialidade, string UF)
        {
            var profissionais = _context.Profissionais.AsQueryable();
            var especialidade = _context.Especialidades.Find(Convert.ToInt32(Especialidade));

            var Listespecialidades = from esp in _context.Especialidades
                                     where esp.Codigo == especialidade.Codigo &&
                                     esp.Profissionais != null
                                     select (esp);

            var Cidades = from pro in profissionais
                          from esp in Listespecialidades
                          where esp.Profissionais.Id == pro.Id &&
                                pro.UF == UF
                          select (pro.Cidade);

            Cidades = Cidades.Distinct();
            return Cidades;
        }

        public IQueryable<string> GetCidadesEspecialidade(string Especialidade)
        {
            var profissionais = _context.Profissionais.AsQueryable();
            var especialidade = _context.Especialidades.Find(Convert.ToInt32(Especialidade));

            var Listespecialidades = from esp in _context.Especialidades
                                     where esp.Codigo == especialidade.Codigo &&
                                     esp.Profissionais != null
                                     select (esp);

            var Cidades = from pro in profissionais
                          from esp in Listespecialidades
                          where esp.Profissionais.Id == pro.Id
                          select (pro.Cidade);

            Cidades = Cidades.Distinct();

            return (Cidades);
        }

        public IQueryable<string> GetCidadesUFs(string UF)
        {
            var Cidades = from Prof in _context.Profissionais
                          where Prof.UF == UF
                          select (Prof.Cidade);

            var cidades = Cidades.Distinct();

            return (cidades);
        }

        public IQueryable<string> GetUFs(string Especialidade)
        {
            var profissionais = _context.Profissionais.AsQueryable();
            var especialidade = _context.Especialidades.Find(Convert.ToInt32(Especialidade));

            var Listespecialidades = from esp in _context.Especialidades
                                     where esp.Codigo == especialidade.Codigo &&
                                     esp.Profissionais != null
                                     select (esp);
            var UFS = from pro in profissionais
                      from esp in Listespecialidades
                      where esp.Profissionais.Id == pro.Id
                      select (pro.UF);

            UFS = UFS.Distinct();

            return UFS;
        }
    }
}
