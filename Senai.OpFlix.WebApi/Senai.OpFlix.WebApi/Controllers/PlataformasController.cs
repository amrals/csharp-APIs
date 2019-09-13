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

        /// <summary>
        /// Lista todas plataformas
        /// </summary>
        /// <returns>Lista de plataformas</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformasRepository.Listar());
        }

        /// <summary>
        /// Cadastra plataformas
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            PlataformasRepository.Cadastrar(plataforma);
            return Ok();
        }

        /// <summary>
        /// Atualiza plataformas
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Plataformas plataforma)
        {
            PlataformasRepository.Atualizar(plataforma);
            return Ok();
        }

        /// <summary>
        /// Deleta alguma plataforma por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PlataformasRepository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Busca alguma plataforma por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>plataforma</returns>
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