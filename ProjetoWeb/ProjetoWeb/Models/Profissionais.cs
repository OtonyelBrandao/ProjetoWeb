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
        //informações basicas ------------------
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        //informações basicas ------------------

        //Contato   ----------------------------
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string WhatsApp { get; set; }
        //Contato   ----------------------------

        //Especializações   --------------------
        [Required]
        public ICollection<Especialidades> Especialidades { get; set; }
        //Especializações   --------------------

        //Endereço  ----------------------------
        [Required]
        public string Rua { get; set; }
        [Required]
        public int CEP { get; set; }
        [Required]
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string UF { get; set; }
        //Endereço  ----------------------------

    }
}
