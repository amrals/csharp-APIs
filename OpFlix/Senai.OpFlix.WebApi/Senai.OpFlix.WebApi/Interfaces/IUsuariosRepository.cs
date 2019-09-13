using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        /// <summary>
        /// Listagem de usuários pelo usuário administrador.
        /// </summary>
        /// <returns>Lista de usuários</returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Busca pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>usuario</returns>
        Usuarios BuscarPorId(int id);

        /// <summary>
        /// Cadastro de usuários feito pelo usuário administrador.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        void Cadastrar(Usuarios usuario);

        /// <summary>
        /// Atualização de usuários pelo usuário administrador
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        void Atualizar(Usuarios usuario);

        /// <summary>
        /// Deletar usuários.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        void Deletar(int id);

        /// <summary>
        /// Busca por email e senha para realização do login do usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        /// <summary>
        /// Se o id do usuário que está logado for o mesmo do usuario que ele está tentando atualizar, retorna ok. Caso contrário, se os id's forem diferentes, seu request não é autorizado.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        void AtualizarComum(Usuarios usuario);

        /// <summary>
        /// Cadastro de usuários padrão e público, com o tipo de usuário travado em "2" (comum).
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        void CadastrarComum(Usuarios usuario);
    }
}
