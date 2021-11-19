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
            DisplayFaultInformation();
            UserController userController = new();
            ViewBag.Allfontaneros = JsonConvert.DeserializeObject<List<User>>(userController.GetAllUsers().Result);
            ViewBag.fontaneros = JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result);
            ViewBag.sectores = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result);
            DisplayMessageDynamically();
            return View();
        }

        [HttpPost]
        [Route("Averia/RegistrarAveria")]
        public async Task<IActionResult> RegistrarAveria(FaultViewModel averia)
        {
            HttpClient httpClient = new();
            var Response = await httpClient.PostAsync("https://localhost:44358/API/Averia/RegistrarAveria"
                , new StringContent(JsonConvert.SerializeObject(averia), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
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
            HttpClient httpClient = new();
            var Response = await httpClient.PutAsync("https://localhost:44358/API/Averia/ModificarAveria"
                , new StringContent(JsonConvert.SerializeObject(averia), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("Averia/BorrarAveria")]
        public async Task<IActionResult> BorrarAveria(int idFault)
        {
            HttpClient httpClient = new();
            var Response = await httpClient.DeleteAsync("https://localhost:44358/API/Averia/BorrarAveria/" + idFault);
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BuscarAveriaPorSector(int idSector)
        {
            TempData["idSector"] = idSector;
            return RedirectToAction("Index");
        }

        private void DisplayMessageDynamically()
        {
            if (TempData["isShow"] != null && TempData["message"] != null)
            {
                ViewBag.ShowModalResponse = TempData["isShow"];
                ViewBag.Message = TempData["message"];
            }
        }

        private void DisplayFaultInformation()
        {
            if (TempData["idSector"] != null)
            {
                List<FaultViewModel> averias = JsonConvert.DeserializeObject<List<FaultViewModel>>(ObtenerAverias().Result)
                    .Where(a => a.IdSector == (int)TempData["idSector"]).ToList();
                if (averias.Count != 0)
                {
                    ViewBag.averias = averias;
                }
                else
                {
                    TempData["isShow"] = true;
                    TempData["message"] = "No existen resultados para su búsqueda.";
                }
            }
            else
            {
                ViewBag.averias = JsonConvert.DeserializeObject<List<FaultViewModel>>(ObtenerAverias().Result);
            }
        }
    }
}

