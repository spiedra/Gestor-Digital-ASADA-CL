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
    public class PersonalBinnacleController : Controller
    {
        // GET: PersonalBinnacle
        public ActionResult Index1()
        {
            ViewBag.actividades = JsonConvert.DeserializeObject<List<BitacoraViewModel>>(ObtenerActividades().Result);
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.actividades= JsonConvert.DeserializeObject<List<BitacoraViewModel>>(ObtenerActividades().Result);
            return View();
        }

        [HttpGet]
        public ActionResult BuscarActividad(string Detalle)
        {
           List<BitacoraViewModel>listaActividades= JsonConvert.DeserializeObject<List<BitacoraViewModel>>(ObtenerActividades().Result);
            List<BitacoraViewModel> resultadoActividades = listaActividades.Where(b => b.Detalle.ToLower().Contains(Detalle.ToLower())).ToList();
            if (resultadoActividades.Count != 0)
            {
                ViewBag.actividades = resultadoActividades;
                ViewBag.cantidadResultado = resultadoActividades.Count;
            }

            ViewBag.palabras = Detalle;

            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
                return View("Index");
            }
            return View("Index1");
        }

        public async Task<string> ObtenerActividades()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Bitacora/ObtenerActividades/"+HttpContext.User.Identity.Name);
            return await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        [Route("Bitacora/RegistrarActividad")]
        public async Task<IActionResult> RegistrarActividad(BitacoraViewModel bitacora)
        {
            bitacora.NombreUsuario = HttpContext.User.Identity.Name;
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(bitacora), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44358/API/Bitacora/RegistrarActividad",content);
            ViewBag.EstadoActividad = await response.Content.ReadAsStringAsync();
            ViewBag.actividades = JsonConvert.DeserializeObject<List<BitacoraViewModel>>(ObtenerActividades().Result);

            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
                return View("Index");
            }
            return View("Index1");
        }

        [HttpPost]
        [Route("Bitacora/ModificarActividad")]
        public async Task<IActionResult> ModificarActividad(BitacoraViewModel bitacora)
        {
            bitacora.NombreUsuario = HttpContext.User.Identity.Name;
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(bitacora), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("https://localhost:44358/API/Bitacora/ModificarActividad",content);
            ViewBag.EstadoActividad = await response.Content.ReadAsStringAsync();
            ViewBag.actividades = JsonConvert.DeserializeObject<List<BitacoraViewModel>>(ObtenerActividades().Result);
            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
                return View("Index");
            }
            return View("Index1");
        }

        [HttpPost]
        [Route("Bitacora/BorrarActividad")]
        public async Task<IActionResult> BorrarActividad(int IdBitacora)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync("https://localhost:44358/API/Bitacora/BorrarActividad/"+IdBitacora);
            ViewBag.EstadoActividad = await response.Content.ReadAsStringAsync();
            ViewBag.actividades = JsonConvert.DeserializeObject<List<BitacoraViewModel>>(ObtenerActividades().Result);
            //direccion
            if (HttpContext.User.IsInRole("Admin"))
            {
                return View("Index");
            }
            return View("Index1");
        }

    }
}
