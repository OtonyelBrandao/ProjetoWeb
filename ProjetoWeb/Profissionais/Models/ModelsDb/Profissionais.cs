using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Profissionais.Models.ModelsDb
{
    [Table("Profissionais")]
    public class ProfissionaisT : BaseModel
    {
        //informações basicas ------------------
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        //informações basicas ------------------

        //Contato   ----------------------------
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string WhatsApp { get; set; }
        //Contato   ----------------------------

        //
        public byte[] imagem { get; set; }
        public string ContentType { get; set; }
        //

        //Especializações   --------------------
        public ICollection<Especialidades> ProfissionaisEspecialidadesFK { get; set; }
        //Especializações   --------------------

        //Endereço  ----------------------------
        [Required]
        public string Rua { get; set; }
        [Required]
        public string CEP { get; set; }
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
