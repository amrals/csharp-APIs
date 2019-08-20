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

    public class GenerosController
    {
        GenerosRepository GenerosRepository = new GenerosRepository();

        [HttpGet]
        public IEnumerable<GenerosDomain> Listar()
        {
            return GenerosRepository.Listar();
        }
    }
}
