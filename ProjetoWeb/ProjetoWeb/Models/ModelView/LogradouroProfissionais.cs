using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models.ModelView
{
    public class LogradouroProfissionais
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        [Required]
        [MaxLength(8)]
        public string CEP { get; set; }
        public string Complemento { get; set; }
        [Required]
        public Especialidades EspecialidadesID { get; set; }
    }
}
