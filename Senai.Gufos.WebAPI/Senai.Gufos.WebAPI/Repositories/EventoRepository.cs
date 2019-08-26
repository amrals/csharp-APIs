using Senai.Gufos.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebAPI.Repositories
{
    public class EventoRepository
    {
        public List<Eventos> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Eventos.ToList();
            }
        }
    }
}
