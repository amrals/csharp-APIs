using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class MidiasRepository : IMidiasRepository
    {
        public List<Midias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Midias.ToList();
            }
        }

        public Midias BuscarPorId(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Midias.FirstOrDefault(x => x.IdMidia == id);

            }
        }

        public void Atualizar(Midias midia)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Midias midiaBuscada = ctx.Midias.FirstOrDefault(x => x.IdMidia == midia.IdMidia);
                midiaBuscada.Nome = midia.Nome;
                midiaBuscada.DataLancamento = midia.DataLancamento;
                midiaBuscada.IdCategoria = midia.IdCategoria;
                midiaBuscada.Sinopse = midia.Sinopse;
                midiaBuscada.Duracao = midia.Duracao;
                midiaBuscada.IdTipoMidia = midia.IdTipoMidia;
                midiaBuscada.IdPlataforma = midia.IdPlataforma;

                ctx.Midias.Update(midiaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Midias midia)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Midias.Add(midia);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Midias midiaBuscada = ctx.Midias.Find(id);
                ctx.Midias.Remove(midiaBuscada);
                ctx.SaveChanges();
            }
        }

    }
}
