using Senai.AutoPecas.WebAPI.Domains;
using Senai.AutoPecas.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebAPI.Repositories
{
    public class PecasRepository : IPecasRepository
    {
        public void Atualizar(Pecas peca)
        {
            using (AutoPecasContext contexto = new AutoPecasContext())
            {
                Pecas pecaBuscada = contexto.Pecas.FirstOrDefault(j => j.PecaId == peca.PecaId);

                pecaBuscada.Codigo = peca.Codigo;
                pecaBuscada.Descricao = peca.Descricao;
                pecaBuscada.Peso = peca.Peso;
                pecaBuscada.PrecoCusto = peca.PrecoCusto;
                pecaBuscada.PrecoVenda = peca.PrecoVenda;
                pecaBuscada.FornecedorId = peca.FornecedorId;

                contexto.Pecas.Update(pecaBuscada);
                contexto.SaveChanges();

            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.PecaId == id);
            }
        }

        public void Cadastrar(Pecas peca)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext contexto = new AutoPecasContext())
            {
                Pecas pecaBuscada = contexto.Pecas.Find(id);

                contexto.Pecas.Remove(pecaBuscada);
                contexto.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                // select
                return ctx.Pecas.ToList();
            }
        }
    }
}
