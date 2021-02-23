using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Repository
{
    public interface ITerapeutasReporitory
    {
        int Add(Terapeutas terapeutas);
        List<Terapeutas> GetTerapeutas();
        Terapeutas Get(int Id);
        int Edit(Terapeutas terapeutas);
        int Delete(int Id);

    }
}
