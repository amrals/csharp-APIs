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
    public class FavoritosController : ControllerBase
    {
        private IFavoritosRepository FavoritosRepository { get; set; }

        public FavoritosController()
        {
            FavoritosRepository = new FavoritosRepository();
        }

        [HttpDelete]
        public IActionResult Deletar(Favoritos favorito)
        {
            int IdUsuario = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value);
            FavoritosRepository.Deletar(IdUsuario , favorito);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            int idBuscadoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(FavoritosRepository.Listar(idBuscadoUsuario));
        }

        [HttpPost]
        public IActionResult Cadastrar(Favoritos favorito)
        {
            FavoritosRepository.Cadastrar(favorito);
            return Ok();
        }
    }
}