using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProjetoWeb.Data;
using ProjetoWeb.Models;

namespace ProjetoWeb.Repository
{
    public class TerapeutasRepository : ITerapeutasReporitory
    {
        IConfiguration _configuration;
        AplicationDbContext db;
        public TerapeutasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var connection = _configuration.
                GetSection("ConnectionStrings").
                GetSection("Default").
                Value;
            return connection;
        }
        public int Add(Terapeutas terapeutas)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Terapeutas(Nome, Endereco, Email, Telefone, Nascimento) VALUES(@Terapeutas.Nome, @Terapeutas.Endereco, @Terapeutas.Email, @Terapeutas.Telefone ,@Terapeutas.Nascimento); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    count = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Delete(int Id)
        {
            return 1;
        }

        public int Edit(Terapeutas terapeutas)
        {
            return 1;
        }

        public Terapeutas Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Terapeutas> GetTerapeutas()
        {
            var connectionString = this.GetConnection();
            
            using (var con = new SqlConnection(connectionString))
            {
                var Resultado = new List<Terapeutas>();
                try
                {
                    var terapeuta = db.Terapeutas.ToList<Terapeutas>();
                    Resultado = terapeuta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return Resultado;
            }
        }
    }
}
