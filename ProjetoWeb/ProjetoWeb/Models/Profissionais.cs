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
       
        public string Telefone { get; set; }
        [Required]
        public string WhatsApp { get; set; }
        //Contato   ----------------------------

        //Especializações   --------------------
        
        public Especialidades EspecialidadeID { get; set; }
        
        public List<Especialidades> Especialidades { get; set; }
        //Especializações   --------------------

        //Endereço  ----------------------------
        
        public string Rua { get; set; }
        [Required]
        public int CEP { get; set; }
        [Required]
        public string Complemento { get; set; }
        
        public string Bairro { get; set; }
       
        public string Cidade { get; set; }
        
        public string UF { get; set; }
        //Endereço  ----------------------------

    }
}
