using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargosRepository
    {
        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // select
                return ctx.Cargos.ToList();
            }
        }
        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }
        public void Cadastrar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // insert into
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
            }
        }
    }
}
