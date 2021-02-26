using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Repository
{
    public interface IProfissionaisReporitory
    {
        void Add(Profissionais profissionais);
        List<Profissionais> GetProfissionais();
        List<Profissionais> GetProfissionais(string Profissao ,string Endereco);
        Profissionais Get(int Id);
        void Edit(Profissionais profissionais);
        void Delete(int Id);

    }
}
