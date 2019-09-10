using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IFavoritosRepository
    {
        List<Favoritos> Listar();
        void Cadastrar(Favoritos favorito);
        void Deletar(int idUsuario, int idMidia);
    }
}
