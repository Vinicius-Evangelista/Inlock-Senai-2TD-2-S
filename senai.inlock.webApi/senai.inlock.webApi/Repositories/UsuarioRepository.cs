using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-20INV7D\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=SenaiSamuel1";

        //const string STRINGCONEXAO = @"Data source= DESKTOP-DHSRSVI\SQLEXPRESS; initial_catalog= inlock_games_tarde; user Id=sa; pwd=senai@132;";
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection sqlConnection = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT t.titulo, email, senha FROM usuario
                                       JOIN tipoUsuario t
                                       ON usuario.idTipoUsuario = t.idTipoUsuario
                                       WHERE email = @email AND senha = @senha;";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@senha", senha);
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();



                    if (sqlReader != null)
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            tipoUsuario = new TipoUsuarioDomain
                            {
                                titulo = sqlReader[0].ToString()
                            },

                            email = sqlReader[1].ToString(),
                            senha = sqlReader[2].ToString()
                        };
                    }

                    return null;
                }
            }
            
        }
    }
}
