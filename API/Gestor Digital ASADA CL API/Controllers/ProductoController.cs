using Gestor_Digital_ASADA_CL_API.Models;
using Gestor_Digital_ASADA_CL_API.Utility;
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
    public class ProductoController : ControllerBase
    {
        GestorDigitalASADACLAYDContext db;
        public ProductoController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("/API/Producto/ObtenerProductos")]
        public IActionResult Get()
        {
            return Ok(db.Productos.ToList());
        }

        [HttpGet]
        [Route("/API/Producto/ObtenerReportes")]
        public IActionResult GetReportes()
        {
            List<SolicitudProducto> solicitudes = new List<SolicitudProducto>();
            foreach (UsuarioProducto up in db.UsuarioProductos.ToList())
            {
                solicitudes.Add(new SolicitudProducto
                {
                    CodigoProducto = up.CodigoProducto,
                    Detalles = up.Detalles,
                    Cantidad = up.Cantidad,
                    Fecha=up.FechaSolicitud,
                    NombreUsuario = db.Usuarios.Find(up.IdUsuario).NombreUsuario
                }
                    );
            }
            return Ok(solicitudes);
        }

        [HttpPost]
        [Route("/API/Producto/RegistrarProducto")]
        public IActionResult Post([FromBody] Producto p)
        {
            bool productExists = db.Productos.ToList().Exists(i => i.CodigoProducto.ToString().ToLower().Equals(p.CodigoProducto.ToString().ToLower()));
            if (productExists)
            {
                return Ok("Error! código de producto existente.");
            }
            db.Productos.Add(p);
            db.SaveChanges();
            return Ok("Producto nuevo agregado en el inventario!");
        }

        [HttpPut]
        [Route("/API/Producto/ModificarProducto")]
        public IActionResult Put(Producto p)
        {
            var original = db.Productos.Find(p.CodigoProducto);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(p);
                db.SaveChanges();
            }
            return Ok("Producto modificado con éxito!");
        }

        [HttpDelete]
        [Route("/API/Producto/BorrarProducto/{codigo}")]
        public IActionResult Delete(string codigo)
        {
            var product = db.Productos.Find(codigo);
            db.Productos.Remove(product);
            db.UsuarioProductos.RemoveRange(db.UsuarioProductos.Where(up => up.CodigoProducto.Equals(codigo)));
            db.SaveChanges();
            return Ok("Producto eliminado con éxito!");
        }

        [HttpPost]
        [Route("/API/Producto/SolicitarProducto")]
        public IActionResult SolicitarProducto(SolicitudProducto solicitud)
        {
            //fecha
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            db.Productos.Find(solicitud.CodigoProducto).Cantidad -= solicitud.Cantidad;

            UsuarioProducto up = new UsuarioProducto
            {
                CodigoProducto = solicitud.CodigoProducto,
                Cantidad = solicitud.Cantidad,
                FechaSolicitud = myDateTime,
                Detalles = solicitud.Detalles,
                IdUsuario = db.Usuarios.ToList().First(u => u.NombreUsuario.Equals(solicitud.NombreUsuario)).IdUsuario
            };

            db.UsuarioProductos.Add(up);
            db.SaveChanges();
            return Ok("Reporte de producto realizado!");
        }

    }
}
