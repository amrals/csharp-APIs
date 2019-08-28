using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentosRepository
    {
        public List<Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // select
                return ctx.Departamentos.ToList();
            }
        }
        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }
        public void Cadastrar(Departamentos departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // insert into
                ctx.Departamentos.Add(departamento);
                ctx.SaveChanges();
            }
        }
    }
}
