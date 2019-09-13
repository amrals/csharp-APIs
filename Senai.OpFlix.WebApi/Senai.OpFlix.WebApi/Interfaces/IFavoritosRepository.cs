using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IFavoritosRepository
    {
        /// <summary>
        /// Lista todos os favoritos
        /// </summary>
        /// <returns>Lista de favoritos</returns>
        List<Favoritos> Listar(int idUsuario);

        /// <summary>
        /// Cadastro um favorito
        /// </summary>
        /// <param name="favorito"></param>
        /// <returns>verificação</returns>
        void Cadastrar(Favoritos favorito);

        /// <summary>
        /// Deleta um favorito
        /// </summary>
        /// <param name="favorito"></param>
        /// <returns>verificação</returns>
        void Deletar(int IdUsuario, Favoritos favorito);
    }
}
