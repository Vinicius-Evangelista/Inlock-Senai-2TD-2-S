using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        const string STRINGCONEXAO = @"Data Source= DESKTOP-DHSRSVI\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        public void AtualizarJogo(int id, JogoDomain jogoAtualizado)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryUpdate = @"UPDATE jogo
                                       SET nomeJogo = @nomeJogo, dataLancamento = @dataLancamento, descricao = @descricao, valor = @valor;
                                       WHERE idJogo =  @idJogo  ";
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    //adicionando os parâmetros para colocar no sql
                    sqlCommand.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                    sqlCommand.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                    sqlCommand.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                    sqlCommand.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    sqlCommand.Parameters.AddWithValue("@idJogo", id);
                    sqlCommand.ExecuteNonQuery();

                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string querySelectById = @"SELECT idjogo, e.idEstudio, nomeJogo,dataLancamento,descricao, valor, e.idEstudio, nomeEstudio FROM jogo
                                         JOIN estudio e
                                         ON jogo.idEstudio = e.idEstudio
                                         WHERE idJogo = @idJogo 
                                         ;";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(querySelectById, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idJogo", id);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader != null)
                    {

                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(reader[0]),
                            idEstudio = Convert.ToInt32(reader[1]),
                            nomeJogo = reader[2].ToString(),
                            dataLancamento = Convert.ToDateTime(reader[3]),
                            descricao = reader[4].ToString(),
                            valor = (float)reader[5],
                            estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(reader[6]),
                                nomeEstudio = reader[7].ToString()
                            }
                        };

                        return jogo;
                    }
                    return null;
                }
            }
        }

        public void CadastrarJogo(JogoDomain novoJogo)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryInsert = @"INSERT INTO jogo (idEstudio, nomeJogo, dataLancamento, descricao, valor)
                                       VALUES (@idEstudio, @nomeJogo, @dataLancamento, @descricao, @valor)";
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert))
                {
                    sqlCommand.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    sqlCommand.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    sqlCommand.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    sqlCommand.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    sqlCommand.Parameters.AddWithValue("@valor", novoJogo.valor);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Deletarjogo(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryDelete = "DELETE FROM jogo WHERE idJogo = @idJogo";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idJogo", id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarJogos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string querySelectAll = @"SELECT idjogo, e.idEstudio, nomeJogo,dataLancamento,descricao, valor, e.idEstudio, nomeEstudio FROM jogo
                                         JOIN estudio e
                                         ON jogo.idEstudio = e.idEstudio;";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(querySelectAll, sqlConnection))
                {

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(reader[0]),
                            idEstudio = Convert.ToInt32(reader[1]),
                            nomeJogo = reader[2].ToString(),
                            dataLancamento = Convert.ToDateTime(reader[3]),
                            descricao = reader[4].ToString(),
                            valor = Convert.ToDouble(reader[5]),
                            estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(reader[6]),
                                nomeEstudio = reader[7].ToString()
                            }

                        };

                        listaJogo.Add(jogo);
                    }

                    return listaJogo;
                }

            }
        }
    }
}
