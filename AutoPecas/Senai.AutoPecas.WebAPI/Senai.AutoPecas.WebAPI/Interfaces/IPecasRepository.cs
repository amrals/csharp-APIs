using Senai.AutoPecas.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebAPI.Interfaces
{
    public interface IPecasRepository
    {
        List<Pecas> Listar();
        Pecas BuscarPorId(int id);
        void Cadastrar(Pecas peca);
        void Atualizar(Pecas peca);
        void Deletar(int id);
    }
}
