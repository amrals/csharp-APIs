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
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository UsuariosRepository { get; set; }

        public UsuariosController()
        {
            UsuariosRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuariosRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            UsuariosRepository.Cadastrar(usuario);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Usuarios usuario)
        {
            UsuariosRepository.Atualizar(usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuariosRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Usuarios usuario = UsuariosRepository.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
    }
}