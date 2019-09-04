using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                // select
                return ctx.Estudios.ToList();
            }
        }
        public void Cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // insert into
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }
        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.IdEstudio == id);
            }
        }
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // encontrar oq eu quero deletar
                Estudios EstudioIdBuscado = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(EstudioIdBuscado);
                // efetivar as mudanças no bd
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.FirstOrDefault(x => x.IdEstudio == estudio.IdEstudio);
                EstudioBuscado.Nome = estudio.Nome;
                ctx.Estudios.Update(EstudioBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
