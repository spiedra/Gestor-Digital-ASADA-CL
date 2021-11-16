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
            db.Sectors.Remove(sector);
            db.SaveChanges();
            var averiaSector = db.Averia.FirstOrDefault(x => x.IdSector == id);
            db.Averia.Remove(averiaSector);
            db.SaveChanges();
            return Ok("Sector eliminado con éxito");


        }



    }
}
