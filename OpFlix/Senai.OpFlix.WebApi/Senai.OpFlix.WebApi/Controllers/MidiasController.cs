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
    public class MidiasController : ControllerBase
    {
        private IMidiasRepository MidiasRepository { get; set; }

        public MidiasController()
        {
            MidiasRepository = new MidiasRepository();
        }

        /// <summary>
        /// Lista todas as mídias
        /// </summary>
        /// <returns>Lista de mídias</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(MidiasRepository.Listar());
        }

        /// <summary>
        /// Cadastra uma mídia
        /// </summary>
        /// <param name="midia"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Midias midia)
        {
            MidiasRepository.Cadastrar(midia);
            return Ok();
        }

        /// <summary>
        /// Atualiza alguma mídia
        /// </summary>
        /// <param name="midia"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Midias midia)
        {
            MidiasRepository.Atualizar(midia);
            return Ok();
        }

        /// <summary>
        /// Deletar alguma mídia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            MidiasRepository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Busca alguma mídia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>midia</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Midias midia = MidiasRepository.BuscarPorId(id);
            if (midia == null)
            {
                return NotFound();
            }
            return Ok(midia);
        }

        [Authorize]
        [HttpGet("FiltrarPorCategoria/{categoria}")]
        public IActionResult FiltrarPorCategoria(int categoria)
        {
            return Ok(MidiasRepository.FiltrarPorCategoria(categoria));
        }

        [Authorize]
        [HttpGet("FiltrarPorCategoria/")]
        public IActionResult Nulo()
        {
            return Ok(MidiasRepository.Listar());
        }
    }
}