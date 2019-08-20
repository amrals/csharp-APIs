using Senai.Filmes.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebAPI.Repository
{
    public class GenerosRepository
    {
        private string StringConexao =
            "Data Source=.\\SqlExpress; Initial catalog=RoteiroFilmes; User Id=sa;Pwd=132";

        public List<GenerosDomain> Listar()
        {
            List<GenerosDomain> generos = new List<GenerosDomain>();
            
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero , Nome FROM Generos;";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // Executa a Query
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GenerosDomain genero = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
    }
}
