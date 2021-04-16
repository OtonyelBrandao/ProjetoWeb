using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Profissionais.Models.ModelsDb
{
    [Table("Especialidades")]
    public class Especialidades : BaseModel
    {
        //Informações Basicas -------------------------
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string NomeDaEspecialidade { get; set; }
        //Informações Basicas -------------------------

        //Profissionais   -----------------------------
        public ProfissionaisT Profissionais { get; set; }
        //Profissionais   -----------------------------
    }
}
