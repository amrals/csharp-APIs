using Microsoft.AspNetCore.Authorization;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        public List<Categorias> Listar()
        {
           using(OpFlixContext ctx = new OpFlixContext())
           {
                return ctx.Categorias.ToList();
           }
        }

        public Categorias BuscarPorId(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        
        public void Cadastrar(Categorias categoria)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Categorias categoria)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Categorias categoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                categoriaBuscada.Nome = categoria.Nome;
                ctx.Categorias.Update(categoriaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Categorias categoriaBuscada = ctx.Categorias.Find(id);
                ctx.Categorias.Remove(categoriaBuscada);
                ctx.SaveChanges();
            }
        }

    }
}
