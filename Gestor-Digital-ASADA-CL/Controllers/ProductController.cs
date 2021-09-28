using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }


        [HttpPost]
        [Route("Product/RealizarReporte")]
        public IActionResult RealizarReporteInventario()
        {
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = "¡Reporte de producto satisfactorio!";
            return View("Index");
        }

        [HttpPost]
        [Route("Product/RealizarReporteAdmin")]
        public IActionResult RealizarReporteAdmin()
        {
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = "¡Reporte de producto satisfactorio!";
            return View("IndexAdmin");
        }

        [HttpPost]
        [Route("Product/EditarProducto")]
        public IActionResult EditarProducto()
        {
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = "¡El producto se ha modificado con éxito!";
            return View("IndexAdmin");
        }

        [HttpPost]
        [Route("Product/BorrarProducto")]
        public IActionResult BorrarProducto()
        {
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = "¡El producto se ha borrado con éxito!";
            return View("IndexAdmin");
        }

    }
}
