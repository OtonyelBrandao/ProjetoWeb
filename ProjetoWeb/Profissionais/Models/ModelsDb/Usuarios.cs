using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Profissionais.Models.ModelsDb
{
    public class Usuarios : IdentityUser
    {
        [Key]
        public int IDUsuario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Minimo de Caracteres é 8")]
        public string Login { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Minimo de Caracteres é 8")]
        public string Senha { get; set; }
        //public string TipoDeUsuario { get; set; }
    }
}
