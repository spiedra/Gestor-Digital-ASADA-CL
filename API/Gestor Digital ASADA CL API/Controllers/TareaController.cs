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
        [Route("/API/Tarea/ObtenerTareasByIdUsuario/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _context.Tareas.Where(x => x.IdUsuario == id).ToListAsync());
        }

        [HttpPost]
        [Route("/API/Tarea/RegistrarTarea")]
        public async Task<IActionResult> Create(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return Ok("Tarea registrada con éxito");
        }

        [HttpPut]
        [Route("/API/Tarea/ModificarTarea")]
        public async Task<IActionResult> Edit(Tarea tarea)
        {
            var task = _context.Tareas.Find(tarea.IdTarea);
            if (task != null)
            {
                tarea.FechaAsignacion = task.FechaAsignacion;
                _context.Entry(task).CurrentValues.SetValues(tarea);
                await _context.SaveChangesAsync();
                return Ok("Tarea modificada con éxito");
            }
            else
            {
                return Ok("Ha ocurrido un error al modificar la tarea. Inténtelo de nuevo");
            }
        }
    }
}
