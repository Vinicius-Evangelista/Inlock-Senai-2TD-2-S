using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-20INV7D\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=SenaiSamuel1";

        public void CadastrarEstudio(EstudioDomain estudioDomain)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarEstudios()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

           using (SqlConnection con = new SqlConnection(stringConexao))
           {
                string querySelectAll = "SELECT * FROM estudio";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(reader[0]),

                            nomeEstudio = reader[1].ToString()
                        };

                        listaEstudios.Add(estudio);
                    }
                }
           }

            return listaEstudios;
        }
    }
}
