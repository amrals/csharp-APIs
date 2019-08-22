using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebAPI.Domains;
using Senai.Filmes.WebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class GenerosController : ControllerBase
    {
        GenerosRepository GenerosRepository = new GenerosRepository();

        [HttpGet]
        public IEnumerable<GenerosDomain> Listar()
        {
            return GenerosRepository.Listar();
        }

        [HttpGet("{id}")]
        public GenerosDomain BuscarPorId(int id)
        {
            return GenerosRepository.BuscarPorId(id);
        }

        [HttpPost]
        public IActionResult Inserir(GenerosDomain generosDomain)
        {
            GenerosRepository.Inserir(generosDomain);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(GenerosDomain generosDomain)
        {
            GenerosRepository.Alterar(generosDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            GenerosRepository.Deletar(id);
            return Ok();
        }
    }
}
