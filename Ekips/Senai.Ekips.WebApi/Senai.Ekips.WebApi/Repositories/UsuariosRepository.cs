using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuariosRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // buscar os dados no banco e verificar se este email e senha sao validos
                Usuarios UsuarioBuscado = ctx.Usuarios.Include(x => x.IdPermissaoNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }
    }
}
