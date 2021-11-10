using Gestor_Digital_ASADA_CL_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly GestorDigitalASADACLAYDContext _context;

        public TareaController(GestorDigitalASADACLAYDContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/API/Tareas/ObtenerTareasByIdUsuario/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _context.Tareas.Where(x => x.IdUsuario == id).ToListAsync());
        }

        [HttpPost]
        [Route("/API/Tareas/RegistrarTarea")]
        public async Task<IActionResult> Create(Tarea tarea) 
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return Ok("Tarea registrada con éxito");
        }
    }
}
