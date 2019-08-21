using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebAPI.Domains;
using Senai.Peoples.WebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository();

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Listar()
        {
            return FuncionariosRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionariosDomain Funcionario = FuncionariosRepository.BuscarPorId(id);
            if(Funcionario == null)
            {
                return NotFound();
            }
            return Ok(Funcionario);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionariosRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(FuncionariosDomain funcionariosDomain)
        {
            FuncionariosRepository.Alterar(funcionariosDomain);
            return Ok();
        }

        [HttpPost]
        public IActionResult Inserir(FuncionariosDomain funcionariosDomain)
        {
            FuncionariosRepository.Inserir(funcionariosDomain);
            return Ok();
        }
    }
}
