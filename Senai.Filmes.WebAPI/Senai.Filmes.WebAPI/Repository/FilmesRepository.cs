using Senai.Filmes.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebAPI.Repository
{
    public class FilmesRepository
    {
        private string StringConexao =
            "Data Source=.\\SqlExpress; Initial catalog=RoteiroFilmes; User Id=sa;Pwd=132";

        public List<FilmesDomain> Listar()
        {
            List<FilmesDomain> filmes = new List<FilmesDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFilme, Titulo, IdGenero FROM Filmes;";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FilmesDomain filme = new FilmesDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                        };
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }

        public FilmesDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = @IdFilme;";
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmesDomain filme = new FilmesDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = (sdr["Titulo"]).ToString(),
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            };
                            return filme;
                        }
                    }
                    return null;
                }
            }
        }

        public void Inserir(FilmesDomain filmesDomain)
        {
            string Query = "INSERT INTO Filmes(Titulo, IdGenero) VALUES (@Titulo,@IdGenero);";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filmesDomain.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filmesDomain.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}