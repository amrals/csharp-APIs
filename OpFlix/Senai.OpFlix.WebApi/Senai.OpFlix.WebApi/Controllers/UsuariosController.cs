using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        /// <summary>
        /// Listagem de usuários pelo usuário administrador.
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuariosRepository.Listar());
        }

        /// <summary>
        /// Cadastro de usuários feito pelo usuário administrador.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            UsuariosRepository.Cadastrar(usuario);
            return Ok();
        }

        /// <summary>
        /// Cadastro de usuários padrão e público, com o tipo de usuário travado em "2" (comum).
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        [HttpPost("cadastrocomum")]
        public IActionResult CadastrarComum(Usuarios usuario)
        {
            usuario.IdTipoUsuario = 2;  
            UsuariosRepository.Cadastrar(usuario);
            return Ok();
        }

        /// <summary>
        /// Atualização de usuários pelo usuário administrador
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Usuarios usuario)
        {
            UsuariosRepository.Atualizar(usuario);
            return Ok();
        }

        /// <summary>
        /// Se o id do usuário que está logado for o mesmo do usuario que ele está tentando atualizar, retorna ok. Caso contrário, se os id's forem diferentes, seu request não é autorizado.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>verificação</returns>
        [Authorize]
        [HttpPut("atualizarcomum")]
        public IActionResult AtualizarComum(Usuarios usuario)
        {
            try
            {
                int idBuscadoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                if (idBuscadoUsuario == usuario.IdUsuario)
                {
                    UsuariosRepository.Atualizar(usuario);
                    return Ok();
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar usuários.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuariosRepository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Busca pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>usuario</returns>
        [Authorize(Roles = "1")]
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