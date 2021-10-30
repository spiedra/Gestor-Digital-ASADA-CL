using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor_Digital_ASADA_CL_API.Models;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecaudacionDiariaController : ControllerBase
    {
        private readonly GestorDigitalASADACLAYDContext _context;

        public RecaudacionDiariaController(GestorDigitalASADACLAYDContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/API/Producto/ObtenerRecaudacionesDiarias")]
        public IActionResult Get()
        {
            return Ok(_context.RecaudacionDiaria.ToList());
        }
    }
}
