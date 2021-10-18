using Gestor_Digital_ASADA_CL_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    public class UsuarioController : Controller
    {
        GestorDigitalASADACLAYDContext db;
        public UsuarioController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult IniciarSesión()
        {

        }
    }
}
