using Gestor_Digital_ASADA_CL_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectorController : Controller
    {
        GestorDigitalASADACLAYDContext db;

        public SectorController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("/API/Sector/RegistrarSector")]
        public IActionResult RegistrarSector([FromBody] Sector sector)
        {
            db.Sectors.Add(sector);
            db.SaveChanges();
            return Ok("Sector registrado con éxito");
        }

        [HttpGet]
        [Route("/API/Sector/ObtenerSectores")]
        public IActionResult ObtenerSectores()
        {
            return Ok(db.Sectors.ToList());
        }

        [HttpPut]
        [Route("/API/Sector/ModificarSector")]
        public IActionResult Put(Sector sector)
        {
            var original = db.Sectors.Find(sector.IdSector);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(sector);
                db.SaveChanges();
            }
            return Ok("Sector modificado con éxito");
        }

        [HttpDelete]
        [Route("/API/Sector/BorrarSector/{id}")]
        public IActionResult Delete(int id)
        {
            var sector = db.Sectors.Find(id);
            if (sector != null)
            {
                IEnumerable<Averium> averia = db.Averia.ToList().Where(x => x.IdSector == id);
                foreach (Averium a in averia)
                {
                    db.AveriaTrabajadors.RemoveRange(db.AveriaTrabajadors.Where(x => x.IdAveria == a.IdAveria));
                }
                db.Averia.RemoveRange(db.Averia.Where(x => x.IdSector == id));
                db.Sectors.Remove(sector);
                db.SaveChanges();
                return Ok("Sector eliminado con éxito");
            }
            else
            {
                return Ok("Ha ocurrido un error al eliminar el sector. Inténtelo de nuevo");
            }
        }
    }
}
