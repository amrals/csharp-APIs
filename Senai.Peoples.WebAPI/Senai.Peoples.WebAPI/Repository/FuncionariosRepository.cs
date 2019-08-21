using Senai.Peoples.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Repository
{
    public class FuncionariosRepository
    {
        private string StringConexao =
               "Data Source=.\\SqlExpress; Initial catalog=M_Peoples; User Id=sa;Pwd=132";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios;";
                con.Open();
                SqlDataReader srd;
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    srd = cmd.ExecuteReader();
                    while (srd.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(srd["IdFuncionario"]),
                            Nome = (srd["Nome"]).ToString(),
                            Sobrenome = (srd["Sobrenome"]).ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @IdFuncionario;";
                con.Open();
                SqlDataReader sdr;
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionariosDomain funcionario = new FuncionariosDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = (sdr["Nome"]).ToString(),
                                Sobrenome = (sdr["Sobrenome"]).ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario;";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(FuncionariosDomain funcionariosDomain)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome WHERE IdFuncionario = @IdFuncionario;";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionariosDomain.IdFuncionario);
                cmd.Parameters.AddWithValue("@Nome", funcionariosDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Inserir(FuncionariosDomain funcionariosDomain)
        {
            string Query = "INSERT INTO Funcionarios(Nome,Sobrenome) VALUES(@Nome,@Sobrenome);";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionariosDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionariosDomain.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
