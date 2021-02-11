using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class Terapeuta : BaseModel
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Tell { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public int Ativo { get; set; }
    }
}
