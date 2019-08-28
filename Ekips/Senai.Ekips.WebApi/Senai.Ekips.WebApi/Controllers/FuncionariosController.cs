using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(FuncionariosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            try
            {
                FuncionariosRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro :(" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionarios Funcionario = FuncionariosRepository.BuscarPorId(id);
            if (Funcionario == null)
                return NotFound();
            return Ok(Funcionario);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionariosRepository.Deletar(id);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizar(Funcionarios funcionario)
        {
            FuncionariosRepository.Atualizar(funcionario);
            return Ok();
        }
    }
}