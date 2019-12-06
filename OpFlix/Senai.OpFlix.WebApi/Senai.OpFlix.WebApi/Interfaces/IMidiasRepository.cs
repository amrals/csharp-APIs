using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IMidiasRepository
    {
        /// <summary>
        /// Lista todas as mídias
        /// </summary>
        /// <returns>Lista de mídias</returns>
        List<Midias> Listar();

        /// <summary>
        /// Busca alguma mídia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>midia</returns>
        Midias BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma mídia
        /// </summary>
        /// <param name="midia"></param>
        /// <returns>verificação</returns>
        void Cadastrar(Midias midia);

        /// <summary>
        /// Atualiza alguma mídia
        /// </summary>
        /// <param name="midia"></param>
        /// <returns>verificação</returns>
        void Atualizar(Midias midia);

        /// <summary>
        /// Deletar alguma mídia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        void Deletar(int id);

        /// <summary>
        /// Filtra alguma mídia por categoria
        /// </summary>
        /// <param name="id categoria"></param>
        /// <returns>midia</returns>
        List<Midias> FiltrarPorCategoria(int categoria);
    }
}
