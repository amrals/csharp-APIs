using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebAPI.Domains;
using Senai.Gufos.WebAPI.Repositories;

namespace Senai.Gufos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository CategoriaRepository = new CategoriaRepository();
        /// <summary>
        /// Listar todas as categorias
        /// </summary>
        /// <returns>200 com a lista de categorias</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro :(" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias Categoria = CategoriaRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
            
        }
        
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriaRepository.Deletar(id);
            return Ok();
        }
        
    }
}