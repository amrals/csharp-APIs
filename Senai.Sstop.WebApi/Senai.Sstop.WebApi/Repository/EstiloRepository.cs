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
        private string StringConexao =
            "Data Source=.\\SqlExpress; Initial catalog=M_SStop; User Id=sa;Pwd=132";

        // POST
        public void Cadastrar(EstiloDomain estilo)
        {
            string Query = "INSERT INTO EstilosMusicais (Nome) VALUES (@Nome)";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET
        public EstiloDomain BuscarPorId(int id)
        {
            string Query ="SELECT IdEstiloMusical, Nome FROM EstilosMusicais WHERE IdEstiloMusical = @IdEstiloMusical";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
                    sdr = cmd.ExecuteReader();
                    if(sdr.HasRows)
                    {
                        while(sdr.Read())
                        {
                            EstiloDomain estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                    }
                    return null;
                }
            }
        }

        // GET
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

        // PUT
        public void Alterar(EstiloDomain estiloDomain)
        {
            string Query = "UPDATE EstilosMusicais SET Nome = @Nome WHERE IdEstiloMusical = @IdEstiloMusical";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", estiloDomain.IdEstilo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Deletar(int id)
        {
            string Query = "DELETE  FROM EstilosMusicais WHERE IdEstiloMusical = @IdEstiloMusical";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
