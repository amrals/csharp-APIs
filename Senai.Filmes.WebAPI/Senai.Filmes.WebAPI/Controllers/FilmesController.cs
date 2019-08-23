using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebAPI.Domains;
using Senai.Filmes.WebAPI.Repository;

namespace Senai.Filmes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        FilmesRepository FilmesRepository = new FilmesRepository();

        public IEnumerable<FilmesDomain> Listar()
        {
            return FilmesRepository.Listar();
        }

        [HttpGet("{id}")]
        public FilmesDomain BuscarPorId(int id)
        {
            return FilmesRepository.BuscarPorId(id);
        }

        [HttpPost]
        public IActionResult Inserir(FilmesDomain filmesDomain)
        {
            FilmesRepository.Inserir(filmesDomain);
            return Ok();
        }
    }
}