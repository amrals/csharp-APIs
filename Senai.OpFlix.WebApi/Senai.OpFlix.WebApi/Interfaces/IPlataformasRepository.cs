using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IPlataformasRepository
    {
        /// <summary>
        /// Lista todas plataformas
        /// </summary>
        /// <returns>Lista de plataformas</returns>
        List<Plataformas> Listar();

        /// <summary>
        /// Busca alguma plataforma por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>plataforma</returns>
        Plataformas BuscarPorId(int id);

        /// <summary>
        /// Cadastra plataformas
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>verificação</returns>
        void Cadastrar(Plataformas plataforma);

        /// <summary>
        /// Atualiza plataformas
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>verificação</returns>
        void Atualizar(Plataformas plataforma);

        /// <summary>
        /// Deleta alguma plataforma por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        void Deletar(int id);
    }
}
