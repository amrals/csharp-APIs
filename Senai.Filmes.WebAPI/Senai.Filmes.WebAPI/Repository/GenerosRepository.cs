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

        public GenerosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @IdGenero;";
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GenerosDomain genero = new GenerosDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["Idgenero"]),
                                Nome = (sdr["Nome"]).ToString(),
                            };
                            return genero;
                        }
                    }
                    return null;
                }
            }
        }

        public void Inserir(GenerosDomain generosDomain)
        {
            string Query = "INSERT INTO Generos(Nome) VALUES (@Nome);";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generosDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(GenerosDomain generosDomain)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @IdGenero;";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", generosDomain.IdGenero);
                cmd.Parameters.AddWithValue("@Nome", generosDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero;";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
