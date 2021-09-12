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
        const string STRINGCONEXAO = @"Data Source= DESKTOP-DHSRSVI\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string querySelect = @"SELECT t.idTipoUsuario,idUsuario, email, senha FROM usuario
                                       JOIN tipoUsuario t
                                       ON usuario.idTipoUsuario = t.idTipoUsuario
                                       WHERE email = @email AND senha = @senha;";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@senha", senha);
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();



                    if (sqlReader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(sqlReader[0]),
                            idUsuario = Convert.ToInt32(sqlReader[1]),
                            email = sqlReader[2].ToString(),
                            senha = sqlReader[3].ToString(),
                        };


                        return usuario;
                    }

                    return null;
                }
            }
            
        }
    }
}
