using Senai.Optus.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebAPI.Repositories
{
    public class EstilosRepository
    {
        public List<Estilos> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Estilos.ToList();
            }
        }
        public Estilos BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }
        public void Deletar(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                // encontrar oq eu quero deletar
                Estilos EstiloIdBuscado = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(EstiloIdBuscado);
                // efetivar as mudanças no bd
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Estilos estilo)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);
                EstiloBuscado.Nome = estilo.Nome;
                ctx.Estilos.Update(EstiloBuscado);
                ctx.SaveChanges();
            }
        }
        public void Cadastrar(Estilos estilo)
        {
            using (GufosContext ctx = new GufosContext())
            {
                // insert into
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }

    }
}
