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
    [Route("[controller]")]
    public class BitacoraController : Controller
    {
        GestorDigitalASADACLAYDContext db;
        public BitacoraController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("/API/Bitacora/RegistrarActividad")]
        public IActionResult Post([FromBody] BitacoraViewModel bitacora)
        {
            db.BitacoraPersonals.Add(new BitacoraPersonal
            {
                Detalle = bitacora.Detalle,
                IdUsuario = db.Usuarios.ToList().Find
                (u => u.NombreUsuario.Equals(bitacora.NombreUsuario)).IdUsuario,
                Fecha=DateTime.Now
            });
            db.SaveChanges();
            return Ok("Nueva actividad agregada!");
        }

        [HttpGet]
        [Route("/API/Bitacora/ObtenerActividades/{nombreUsuario}")]
        public IActionResult Post(string nombreUsuario)
        {
            int idUsuario = db.Usuarios.ToList().Find(u => u.NombreUsuario.Equals(nombreUsuario)).IdUsuario;
            return Ok(db.BitacoraPersonals.ToList().FindAll(b=>b.IdUsuario==idUsuario).OrderByDescending(b=>b.Fecha));
        }

        [HttpPut]
        [Route("/API/Bitacora/ModificarActividad")]
        public IActionResult Put(BitacoraViewModel bitacoraPersonal)
        {
            var bitacora = db.BitacoraPersonals.Find(bitacoraPersonal.IdBitacora);
            bitacora.Detalle = bitacoraPersonal.Detalle;
            bitacora.Fecha = DateTime.Now;
            db.SaveChanges();
            return Ok("Actividad #"+bitacoraPersonal.IdBitacora+" modificada!");
        }
        [HttpDelete]
        [Route("/API/Bitacora/BorrarActividad/{id}")]
        public IActionResult Delete(int id)
        {
            var actividad = db.BitacoraPersonals.Find(id);
            db.BitacoraPersonals.Remove(actividad);
            db.SaveChanges();
            return Ok("Actividad eliminada");
        }
    }
}
