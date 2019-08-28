using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionariosRepository
    {
        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // select
                return ctx.Funcionarios.ToList();
            }
        }
        public void Cadastrar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // insert into
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
            }
        }
        public Funcionarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // encontrar oq eu quero deletar
                Funcionarios FuncionarioIdBuscado = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(FuncionarioIdBuscado);
                // efetivar as mudanças no bd
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == funcionario.IdFuncionario);
                FuncionarioBuscado.Nome = funcionario.Nome;
                ctx.Funcionarios.Update(FuncionarioBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
