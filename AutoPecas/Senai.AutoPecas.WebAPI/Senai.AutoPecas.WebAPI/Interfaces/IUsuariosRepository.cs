using Senai.AutoPecas.WebAPI.Domains;
using Senai.AutoPecas.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebAPI.Interfaces
{
    interface IUsuariosRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
