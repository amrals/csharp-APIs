using Microsoft.AspNetCore.Http;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class FavoritosRepository : IFavoritosRepository
    {
        public void Cadastrar(Favoritos favorito)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Favoritos.Add(favorito);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int IdUsuario, Favoritos favorito)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Favoritos FavoritoBuscado = ctx.Favoritos.FirstOrDefault(x => x.IdUsuario == IdUsuario && x.IdMidia == favorito.IdMidia);
                ctx.Favoritos.Remove(FavoritoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Favoritos> Listar(int idUsuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.Where(x => x.IdUsuario == idUsuario).ToList();
            }
        }
    }
}
