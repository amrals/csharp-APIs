using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repository
{
    public class EstiloRepository
    {
        //List<EstiloDomain> estilos = new List<EstiloDomain>
        //{
        //    new EstiloDomain { IdEstilo = 1,Nome = "Rock"}
        //    , new EstiloDomain { IdEstilo = 2,Nome = "Pop"}
        //};

        private string StringConexao =
            "Data Source=.\\SqlExpress; Initial catalog=M_SStop; User Id=sa;Pwd=132";

        public List<EstiloDomain> Listar()
        {
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            // Abrir uma conexão com o BD
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Fazer a leitura de todos os registros
                // Declarar a instrução a ser realizada
                string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicais";

                // Abre a conexão com o BD
                con.Open();
                // Declaro para percorrer a lista
                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // Executa a Query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(rdr["IdEstiloMusical"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    }
                }
            }
            return estilos;
        }
    }
}
