using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("Profissionais")]
    public class Profissionais : BaseModel
    {

        [Required]
        public string Nome { get; set; }
        [ForeignKey("Logradouro")]
        public int LogradouroId { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string WhatsApp { get; set; }
        [Required]
        public DateTime Nascimento { get; set;}
        [Required]
        public Especialidades EspecialidadeID { get; set; }
        [Required]
        public List<Especialidades> Especialidades { get; set; }
    }
}
