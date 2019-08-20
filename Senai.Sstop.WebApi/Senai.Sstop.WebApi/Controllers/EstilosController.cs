using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repository;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>
        {
            new EstiloDomain { IdEstilo = 1,Nome = "Rock"}
            , new EstiloDomain { IdEstilo = 2,Nome = "Pop"}
        };

        EstiloRepository EstiloRepository = new EstiloRepository();

        // GET /api/estilos
        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            return EstiloRepository.Listar();
        }

        // GET /api/estilos/id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EstiloDomain Estilo = EstiloRepository.BuscarPorId(id);
            if(Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }
        
        // Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            // do bd
            EstiloRepository.Cadastrar(estiloDomain);
            return Ok();
        }

        // Atualizar
        [HttpPut]
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Alterar(estiloDomain);
            return Ok();
        }

        // Deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }
    }
}