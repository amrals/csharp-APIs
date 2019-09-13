using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ICategoriasRepository
    {
        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        List<Categorias> Listar();

        /// <summary>
        /// Busca uma categoria por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>categoria</returns>
        Categorias BuscarPorId(int id);

        /// <summary>
        /// Cadastra categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>verificação</returns>
        void Cadastrar(Categorias categoria);

        /// <summary>
        /// Atualiza categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>verificação</returns>
        void Atualizar(Categorias categoria);

        /// <summary>
        /// Deleta categorias
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        void Deletar(int id);
    }
}
