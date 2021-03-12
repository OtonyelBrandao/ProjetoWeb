using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class Profissionais : BaseModel
    {
        
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string WhatsApp { get; set; }
        public int IDEspecialidades { get; set; }
        public Especialidades Especialidades { get; set; }
    }
}
