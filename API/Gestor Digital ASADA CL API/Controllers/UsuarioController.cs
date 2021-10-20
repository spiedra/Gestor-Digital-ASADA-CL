using Gestor_Digital_ASADA_CL_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        GestorDigitalASADACLAYDContext db;
        public UsuarioController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpGet] 
        [Route("/API/Usuario/ObtenerUsuarios")]
        public IActionResult Get()
        {
            return Ok(db.Usuarios.ToList());
        }
    }
}
