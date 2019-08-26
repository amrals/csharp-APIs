using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebAPI.Domains;
using Senai.Optus.WebAPI.Repositories;

namespace Senai.Optus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstilosRepository EstilosRepository = new EstilosRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstilosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos Estilo = EstilosRepository.BuscarPorId(id);
            if (Estilo == null)
                return NotFound();
            return Ok(Estilo);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstilosRepository.Deletar(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                EstilosRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro :(" + ex.Message });
            }
        }
        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            EstilosRepository.Atualizar(estilo);
            return Ok();
        }
    }
}