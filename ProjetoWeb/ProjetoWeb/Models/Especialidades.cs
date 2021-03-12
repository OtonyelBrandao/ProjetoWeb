using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class Especialidades : BaseModel
    {
        public int Codigo { get; set; }
        public string NomeDaEspecialidade { get; set; }
    }
}
