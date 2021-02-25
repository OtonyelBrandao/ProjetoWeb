using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Repository
{
    public interface ITerapeutasReporitory
    {
        void Add(Terapeutas terapeutas);
        List<Terapeutas> GetTerapeutas();
        List<Terapeutas> GetTerapeutas(string Profissao ,string Endereco);
        Terapeutas Get(int Id);
        void Edit(Terapeutas terapeutas);
        void Delete(int Id);

    }
}
