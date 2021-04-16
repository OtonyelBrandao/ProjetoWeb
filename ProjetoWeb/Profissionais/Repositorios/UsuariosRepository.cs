using Profissionais.Data;
using Profissionais.Models.ModelsDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Profissionais.Repositorios
{
    public interface IUsuariosRepository
    {
        Usuarios GetUsuario(string Nome, string Senha);
        void AddUsuario(Usuarios usuario);
    }
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AplicationDbContext db;
        public UsuariosRepository(AplicationDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Ésta função Cadasta um Usuario no banco e não contem retorno.
        /// </summary>
        /// <param name="usuario">Tem Como unico Parametro uma entidade de Usuarios</param>
        public void AddUsuario(Usuarios usuario)
        {
            usuario.Senha = CriptografarSenha(usuario.Senha);
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
        /// <summary>
        /// Ésta função retorna um usuario cadastrado no banco.
        /// </summary>
        /// <param name="Nome">Nome do usuario.</param>
        /// <param name="Senha">Senha do Usuario</param>
        /// <returns>Retornar uma entidade de Usuarios </returns>
        public Usuarios GetUsuario(string Nome, string Senha)
        {
            Senha = CriptografarSenha(Senha);
            var usuarios = from usu in db.Usuarios
                           where usu.Login == Nome && usu.Senha == Senha
                           select (usu);
            var usuario = usuarios.FirstOrDefault();
            if (usuario == null)
            {
                return null;
            }
            Usuarios user = new Usuarios();
            user.IDUsuario = usuario.IDUsuario;
            user.Login = usuario.Login;
            user.Senha = usuario.Senha;
            return user;
        }
        private string CriptografarSenha(string senha)
        {
            var algorithim = HashAlgorithm.Create("SHA512");
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = algorithim.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        //public bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
        //{
        //    if (string.IsNullOrEmpty(senhaCadastrada))
        //        throw new NullReferenceException("Cadastre uma senha.");
        //    var algorithim = HashAlgorithm.Create("SHA512");
        //    var encryptedPassword = algorithim.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

        //    var sb = new StringBuilder();
        //    foreach (var caractere in encryptedPassword)
        //    {
        //        sb.Append(caractere.ToString("X2"));
        //    }

        //    return sb.ToString() == senhaCadastrada;
        //}
    }
}

