using Gestor_Digital_ASADA_CL_API.Models;
using Gestor_Digital_ASADA_CL_API.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class AveriaController : Controller
    {
        GestorDigitalASADACLAYDContext db;

        public AveriaController(GestorDigitalASADACLAYDContext db) {
            this.db = db;
        }

        [HttpPost]
        [Route ("/API/Averia/RegistrarAveria")]
        public IActionResult RegistrarAveria([FromBody] FaultViewModel averia)
        {
            Averium averium = new Averium
            {
                IdSector = averia.IdSector,
                Afectado = averia.Afectado,
                DetallesReporte = averia.DetallesReporte,
                FechaEjecucion = averia.FechaEjecucion,
                FechaReporte = averia.FechaReporte,
                TrabajoEjecutado = averia.TrabajoEjecutado
            };
            db.Averia.Add(averium);
            db.SaveChanges();
            db.AveriaTrabajadors.Add(new AveriaTrabajador
            {
                IdAveria = averium.IdAveria,
                IdTrabajador = averia.IdTrabajador
            });
            db.SaveChanges();
            return Ok("Avería registrada exitosamente!");
        }

        [HttpGet]
        [Route("/API/Averia/ObtenerFontaneros")]
        public IActionResult ObtenerFontaneros()
        {
            return Ok(db.Usuarios.ToList().Where(u=>u.IdRole==2).ToList());
        }

        [HttpGet]
        [Route("/API/Averia/ObtenerSectores")]
        public IActionResult ObtenerSectores()
        {
            return Ok(db.Sectors.ToList());
        }

        [HttpGet]
        [Route("/API/Averia/ObtenerAverias")]
        public IActionResult ObtenerAverias()
        {
            return Ok(db.Averia.ToList());
        }

        [HttpPut]
        [Route("/API/Averia/ModificarAveria")]
        public IActionResult Put(FaultViewModel averia)
        {
            var original = db.Averia.Find(averia.IdAveria);
            if (original != null)
            {
                original.IdSector = averia.IdSector;
                original.Afectado = averia.Afectado;
                original.DetallesReporte = averia.DetallesReporte;
                original.FechaEjecucion = averia.FechaEjecucion;
                original.FechaReporte = averia.FechaReporte;
                original.TrabajoEjecutado = averia.TrabajoEjecutado;
                db.SaveChanges();
                return Ok("Avería modificada exitosamente!");
            }
            return Ok("La avería no ha hizo modificada");
        }
        [HttpDelete]
        [Route("/API/Averia/BorrarAveria/{id}")]
        public IActionResult Delete(int id)
        {
            var averia = db.Averia.Find(id);
            averia.IsDelete = true;
            db.Averia.Remove(averia);
            db.SaveChanges();
            return Ok("Avería eliminada exitosamente!");
        }
    }
}
