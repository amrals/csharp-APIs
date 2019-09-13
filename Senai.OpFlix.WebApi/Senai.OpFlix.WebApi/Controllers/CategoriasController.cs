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
    public class CategoriasController : ControllerBase
    {
        private ICategoriasRepository CategoriasRepository {get;set;}

        public CategoriasController()
        {
            CategoriasRepository = new CategoriasRepository();
        }

        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriasRepository.Listar());
        }

        /// <summary>
        /// Cadastra categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            CategoriasRepository.Cadastrar(categoria);
            return Ok();
        }

        /// <summary>
        /// Atualiza categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            CategoriasRepository.Atualizar(categoria);
            return Ok();
        }

        /// <summary>
        /// Deleta categorias
        /// </summary>
        /// <param name="id"></param>
        /// <returns>verificação</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriasRepository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Busca uma categoria por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>categoria</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias categoria = CategoriasRepository.BuscarPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }
    }
}