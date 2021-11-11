using Gestor_Digital_ASADA_CL.Models;
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
    
    public class FaultController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.averias = JsonConvert.DeserializeObject<List<FaultViewModel>>(ObtenerAverias().Result);
            ViewBag.fontaneros = JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result);
            ViewBag.sectores = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result);
            return View();
        }

        [HttpPost]
        [Route("Averia/RegistrarAveria")]
        public async Task<IActionResult> RegistrarAveria (FaultViewModel averia)
        {
            HttpClient httpClient = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(averia), Encoding.UTF8, "application/json");
            var Response = await httpClient.PostAsync("https://localhost:44358/API/Averia/RegistrarAveria", stringContent);
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = await Response.Content.ReadAsStringAsync();
            ViewBag.averias = JsonConvert.DeserializeObject<List<FaultViewModel>>(ObtenerAverias().Result);
            ViewBag.fontaneros = JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result);
            ViewBag.sectores = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result);
            return View("Index"); 

        }

        public async Task<string> ObtenerFontaneros()
        {
            HttpClient httpClient = new HttpClient();
            var Response = await httpClient.GetAsync("https://localhost:44358/API/Averia/ObtenerFontaneros");
            return await Response.Content.ReadAsStringAsync();
        }
        public async Task<string> ObtenerSectores()
        {
            HttpClient httpClient = new HttpClient();
            var Response = await httpClient.GetAsync("https://localhost:44358/API/Averia/ObtenerSectores");
            return await Response.Content.ReadAsStringAsync();
        }
        public async Task<string> ObtenerAverias()
        {
            HttpClient httpClient = new HttpClient();
            var Response = await httpClient.GetAsync("https://localhost:44358/API/Averia/ObtenerAverias");
            return await Response.Content.ReadAsStringAsync();
        }
        [HttpPost]
        [Route("Averia/ModificarAveria")]
        public async Task<IActionResult> ModificarAveria(FaultViewModel averia)
        {
            HttpClient httpClient = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(averia), Encoding.UTF8, "application/json");
            var Response = await httpClient.PutAsync("https://localhost:44358/API/Averia/ModificarAveria", stringContent);
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = await Response.Content.ReadAsStringAsync();
            ViewBag.fontaneros = JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result);
            ViewBag.averias = JsonConvert.DeserializeObject<List<FaultViewModel>>(ObtenerAverias().Result);
            ViewBag.sectores = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result);
            return View("Index");
        }
        [HttpPost]
        [Route("Averia/BorrarAveria")]
        public async Task<IActionResult> BorrarAveria(int idFault)
        {
            HttpClient httpClient = new HttpClient();
            var Response = await httpClient.DeleteAsync("https://localhost:44358/API/Averia/BorrarAveria/" +idFault);
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = await Response.Content.ReadAsStringAsync();
            ViewBag.averias = JsonConvert.DeserializeObject<List<FaultViewModel>>(ObtenerAverias().Result);
            return View("Index");
        }   
        
        [HttpGet]
        public IActionResult BuscarAveriaPorSector(int idSector)
        {
            List<FaultViewModel> averias = JsonConvert.DeserializeObject<List<FaultViewModel>>(ObtenerAverias().Result);
            List<FaultViewModel> averiaResultado = averias.Where(a => a.IdSector == idSector).ToList();


                if (averiaResultado.Count != 0)
                {
                    ViewBag.averias = averiaResultado;
                   
                ViewBag.sectores = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result);
            }
                else
                {
                ViewBag.averias = averias;
                ViewBag.ShowModalResponse = "True";
                ViewBag.mensaje = "No existen resultados para su búsqueda.";
                }
            return View ("Index");
            }
        }

    }

