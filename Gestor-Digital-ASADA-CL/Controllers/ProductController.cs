using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public IActionResult IndexAdmin()
        {
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            return View();
        }

        public async Task<string> ObtenerProductos()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Producto/ObtenerProductos");
            return await response.Content.ReadAsStringAsync();
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
        [Route("Product/RegistrarProducto")]
        public async Task<IActionResult> RegistrarProducto(ProductViewModel product)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44358/API/Producto/RegistrarProducto", content);
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = await response.Content.ReadAsStringAsync();
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            return View("IndexAdmin");
        }

        [HttpPost]
        [Route("EditarProducto")]
        public async Task<IActionResult> EditarProducto(ProductViewModel product)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("https://localhost:44358/API/Producto/ModificarProducto", content);
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = await response.Content.ReadAsStringAsync();
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            return View("IndexAdmin");
        }

        [HttpPost]
        public async Task<IActionResult> BorrarProducto(string productCode)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(productCode), Encoding.UTF8, "application/json");
            var response = await httpClient.DeleteAsync("https://localhost:44358/API/Producto/BorrarProducto/"+productCode);
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = await response.Content.ReadAsStringAsync();
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            return View("IndexAdmin");
        }
    }
}
