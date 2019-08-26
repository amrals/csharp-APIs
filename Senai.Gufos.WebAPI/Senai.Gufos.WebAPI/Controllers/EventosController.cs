using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebAPI.Repositories;

namespace Senai.Gufos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/api")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        EventoRepository EventoRepository = new EventoRepository();
        
    }
}