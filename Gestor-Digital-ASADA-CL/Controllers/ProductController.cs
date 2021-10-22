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
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            return View();
        }
        public IActionResult IndexAdmin()
        {
            ViewBag.reportes= JsonConvert.DeserializeObject<List<SolicitudProducto>>(ObtenerReportes().Result);
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            return View();
        }

        public async Task<string> ObtenerProductos()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Producto/ObtenerProductos");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ObtenerReportes()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Producto/ObtenerReportes");
            return await response.Content.ReadAsStringAsync();
        }

        [HttpGet]
        public IActionResult BuscarProducto(string producto)
        {
            var accion = producto.Split("-");
            var productos= JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            List<ProductViewModel> resultados;
            ViewBag.resultadoBusqueda = true;

            //validar la búsqueda
            if (accion[0].ToLower().Equals("c"))
            {
                ViewBag.productoBuscar = accion[1];
                resultados= BuscarPorCódigo(productos,accion[1]);
            }
            else
            {
                ViewBag.productoBuscar = producto;
                resultados = BuscarPorNombre(productos, producto);
            }
            //informar al usuario sobre la búsqueda
            if (resultados.Count != 0)
            {
                ViewBag.products = resultados;
                ViewBag.cantidadResultado = resultados.Count;
            }

            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
                return View("IndexAdmin");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("Product/RealizarReporte")]
        public async Task<IActionResult> SolicitarProducto(string productoS, int cantidad, string detalles)
        {
            var producto = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result).Find(
                p => p.CodigoProducto.Equals(productoS));

            if (producto.Cantidad>=cantidad) {
            SolicitudProducto solicitud = new SolicitudProducto
            {
                CodigoProducto = productoS,
                Cantidad = cantidad,
                Detalles = detalles,
                NombreUsuario=HttpContext.User.Identity.Name
            };

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(solicitud), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44358/API/Producto/SolicitarProducto", content);
            ViewBag.mensaje = await response.Content.ReadAsStringAsync();
            }
            else
            {
                ViewBag.mensaje = "Error. La cantidad solicitada excede la disponible!";
            }
            ViewBag.ShowModalResponse = "True";
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);

            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
                return View("IndexAdmin");
            }
            return View("Index");
        }

        public List<ProductViewModel> BuscarPorCódigo(List<ProductViewModel> productos,string codigo)
        {
            return productos.Where(p => p.CodigoProducto.ToLower().Contains(codigo.ToLower())).ToList();
        }
        public List<ProductViewModel> BuscarPorNombre(List<ProductViewModel> productos, string nombre)
        {
            return productos.Where(p => p.NombreProducto.ToLower().Contains(nombre.ToLower())).ToList();
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
            var response = await httpClient.DeleteAsync("https://localhost:44358/API/Producto/BorrarProducto/" + productCode);
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = await response.Content.ReadAsStringAsync();
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            return View("IndexAdmin");
        }
    }
}
