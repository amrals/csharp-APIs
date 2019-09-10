using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private IPlataformasRepository PlataformasRepository { get; set; }

        public PlataformasController()
        {
            PlataformasRepository = new PlataformasRepository();
        }

        // Lista todas plataformas
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformasRepository.Listar());
        }

        // Cadastra plataformas
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            PlataformasRepository.Cadastrar(plataforma);
            return Ok();
        }

        // Atualiza plataformas
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Plataformas plataforma)
        {
            PlataformasRepository.Atualizar(plataforma);
            return Ok();
        }

        // Deleta alguma plataforma por id
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PlataformasRepository.Deletar(id);
            return Ok();
        }

        // Busca alguma plataforma por id
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Plataformas plataforma = PlataformasRepository.BuscarPorId(id);
            if (plataforma == null)
            {
                return NotFound();
            }
            return Ok(plataforma);
        }
    }
}