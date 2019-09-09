using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformasRepository : IPlataformasRepository
    {
        public List<Plataformas> Listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }

        public Plataformas BuscarPorId(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }

        public void Atualizar(Plataformas plataforma)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataformaBuscada = ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);
                plataformaBuscada.Nome = plataforma.Nome;
                ctx.Plataformas.Update(plataformaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Plataformas plataforma)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataformaBuscada = ctx.Plataformas.Find(id);
                ctx.Plataformas.Remove(plataformaBuscada);
                ctx.SaveChanges();
            }
        }

    }
}
