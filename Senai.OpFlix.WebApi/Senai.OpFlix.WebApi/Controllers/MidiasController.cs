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

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(MidiasRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Midias midia)
        {
            MidiasRepository.Cadastrar(midia);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Midias midia)
        {
            MidiasRepository.Atualizar(midia);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            MidiasRepository.Deletar(id);
            return Ok();
        }

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
    }
}