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
            this.SearchResult();
            this.DisplayDynamicMessage();
            return View();
        }

        public void SearchResult()
        {

            if (TempData["search"] != null)
            {
                ViewBag.resultadoBusqueda = true;
                var productos = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
                List<ProductViewModel> resultados;

                if (TempData["action"].ToString().ToLower().Equals("c"))
                {
                    ViewBag.productoBuscar = TempData["product"];
                    resultados = BuscarPorCódigo(productos, TempData["product"].ToString());
                }
                else
                {
                    ViewBag.productoBuscar = TempData["search"];
                    resultados = BuscarPorNombre(productos, TempData["search"].ToString());
                }
                //informar al usuario sobre la búsqueda
                if (resultados.Count != 0)
                {
                    ViewBag.products = resultados;
                    ViewBag.cantidadResultado = resultados.Count;
                }
            }
        }

        public void DisplayDynamicMessage()
        {
            if (TempData["msg"] != null)
            {
                ViewBag.ShowModalResponse = true;
                ViewBag.mensaje = TempData["msg"];
            }
        }
        public IActionResult IndexAdmin()
        {
            ViewBag.reportes = JsonConvert.DeserializeObject<List<SolicitudProducto>>(ObtenerReportes().Result);
            ViewBag.products = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result);
            this.SearchResult();
            this.DisplayDynamicMessage();
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
        public IActionResult BuscarProducto(string NombreProducto)
        {
            var accion = NombreProducto.Split("-");
            TempData["search"]=NombreProducto;
            TempData["action"]=accion[0];
            ViewBag.resultadoBusqueda = true;

            //validar la búsqueda
            if (accion[0].ToLower().Equals("c"))
            {
                TempData["product"] = accion[1];
            }
            else
            {
                TempData["product"] = NombreProducto;
            }

            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
               
                return RedirectToAction("IndexAdmin");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Product/RealizarReporte")]
        public async Task<IActionResult> SolicitarProducto(string CodigoProducto, int Cantidad, string Descripcion)
        {
            var producto = JsonConvert.DeserializeObject<List<ProductViewModel>>(ObtenerProductos().Result).Find(
                p => p.CodigoProducto.Equals(CodigoProducto));

            if (producto.Cantidad >= Cantidad)
            {
                SolicitudProducto solicitud = new SolicitudProducto
                {
                    CodigoProducto = CodigoProducto,
                    Cantidad = Cantidad,
                    Detalles = Descripcion,
                    NombreUsuario = HttpContext.User.Identity.Name
                };

                HttpClient httpClient = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(solicitud), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://localhost:44358/API/Producto/SolicitarProducto", content);
                TempData["msg"] = await response.Content.ReadAsStringAsync();
            }
            else
            {
                TempData["msg"] = "Error. La cantidad solicitada excede la disponible!";
            }

            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction("IndexAdmin");
            }
            return RedirectToAction("Index");
        }

        public List<ProductViewModel> BuscarPorCódigo(List<ProductViewModel> productos, string codigo)
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
            TempData["msg"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("IndexAdmin");
        }

        [HttpPost]
        [Route("EditarProducto")]
        public async Task<IActionResult> EditarProducto(ProductViewModel product)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("https://localhost:44358/API/Producto/ModificarProducto", content);
            TempData["msg"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("IndexAdmin");
        }

        [HttpPost]
        public async Task<IActionResult> BorrarProducto(string productCode)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(productCode), Encoding.UTF8, "application/json");
            var response = await httpClient.DeleteAsync("https://localhost:44358/API/Producto/BorrarProducto/" + productCode);
            TempData["msg"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("IndexAdmin");
        }
    }
}
