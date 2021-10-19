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

        [HttpGet]
        [Route("/API/Cloro/ObtenerProductos")]
        public IActionResult Get()
        {
            return Ok(db.Productos.ToList());
        }

        [HttpPost]
        [Route("/API/Cloro/RegistrarCloro")]
        public IActionResult Post([FromBody] Cloro c)
        {
            bool productExists = db.CloroResiduals.ToList().Exists(i => i.IdCloroResidual.ToString().ToLower().Equals(c.IdCloroResidual.ToString().ToLower()));
            if (productExists)
            {
                return Ok("Error! código de cloro existente.");
            }
            db.CloroResiduals.Add(c);
            db.SaveChanges();
            return Ok("Registro nuevo agregado en el control de cloro!");
        }

        [HttpPut]
        [Route("/API/Cloro/ModificarCloro")]
        public IActionResult Put(Cloro c)
        {
            var original = db.Productos.Find(c.IdCloroResidual);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(c);
                db.SaveChanges();
            }
            return Ok("Registro modificado con éxito!");
        }

       
    }
}