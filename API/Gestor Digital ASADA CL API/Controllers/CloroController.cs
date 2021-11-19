using Gestor_Digital_ASADA_CL_API.Models;
using Microsoft.AspNetCore.Http;
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
    public class CloroController : ControllerBase
    {
        GestorDigitalASADACLAYDContext db;
        public CloroController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("/API/Cloro/RegistrarCloro")]
        public IActionResult RegistrarCloro([FromBody] Cloro cloro)
        {
            db.CloroResiduals.Add(cloro);
            db.SaveChanges();
            return Ok("Datos registrados con éxito");
        }

        [HttpGet]
        [Route("/API/Cloro/ObtenerCloro")]
        public IActionResult ObtenerCloro()
        {
            return Ok(db.CloroResiduals.ToList());
        }

        [HttpPut]
        [Route("/API/Cloro/ModificarCloro")]
        public IActionResult Put(Cloro cloro)
        {
            var original = db.CloroResiduals.Find(cloro.IdCloroResidual);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(cloro);
                db.SaveChanges();
            }
            return Ok("Datos modificados con éxito");
        }

        [HttpGet]
        [Route("/API/Cloro/ObtenerFontaneros")]
        public IActionResult ObtenerFontaneros()
        {
            return Ok(db.Usuarios.ToList().Where(u => u.IdRole == 2 && u.IsDelete == false).ToList());
        }


    }
}