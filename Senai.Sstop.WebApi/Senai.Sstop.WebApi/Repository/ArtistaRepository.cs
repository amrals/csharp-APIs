using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repository
{
    public class ArtistaRepository
    {
        private string StringConexao =
            "Data Source=.\\SqlExpress; Initial catalog=M_SStop; User Id=sa;Pwd=132";

        public List<ArtistasDomain> Listar()
        {
            List<ArtistasDomain> artistas = new List<ArtistasDomain>();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT Artistas.IdArtistas, Artistas.Nome, Artistas.IdEstiloMusical FROM Artistas INNER JOIN EstilosMusicais ON Artistas.IdEstiloMusical = EstilosMusicais.IdEstiloMusical;";
                con.Open();
                SqlDataReader sdr;
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ArtistasDomain artista = new ArtistasDomain
                        {
                            IdArtista = Convert.ToInt32(sdr["IdArtistas"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdArtistas"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        artistas.Add(artista);
                    }
                }
            }
            return artistas;
        }

        public void Cadastrar(ArtistasDomain artista)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Artistas(@Nome,@IdEstiloMusical) VALUES (@Nome,@IdEstiloMusical);";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", artista.Nome);
                cmd.Parameters.AddWithValue("IdEstiloMusical", artista.EstiloId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
