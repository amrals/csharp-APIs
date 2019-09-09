using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public List<Usuarios> Listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            }
        }

        public void Atualizar(Usuarios usuario)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.IdTipoUsuario = usuario.IdTipoUsuario;

                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.Find(id);
                ctx.Usuarios.Remove(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

    }
}
