using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IMidiasRepository
    {
        List<Midias> Listar();
        Midias BuscarPorId(int id);
        void Cadastrar(Midias midia);
        void Atualizar(Midias midia);
        void Deletar(int id);
    }
}
