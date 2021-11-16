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
    public class SectorController : Controller
    {
        public IActionResult Index()
        {
            DisplaySectorInformation();
            DisplayMessageDynamically();
            return View();
        }

        [HttpPost]
        [Route("Sector/RegistrarSector")]
        public async Task<IActionResult> RegistrarSector(SectorViewModel sector)
        {
            HttpClient httpClient = new();
            var Response = await httpClient.PostAsync("https://localhost:44358/API/Sector/RegistrarSector"
                , new StringContent(JsonConvert.SerializeObject(sector), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        public async Task<string> ObtenerSectores()
        {
            HttpClient httpClient = new HttpClient();
            var Response = await httpClient.GetAsync("https://localhost:44358/API/Sector/ObtenerSectores");
            return await Response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        [Route("Sector/ModificarSector")]
        public async Task<IActionResult> ModificarSector(SectorViewModel sector)
        {
            HttpClient httpClient = new();
            var Response = await httpClient.PutAsync("https://localhost:44358/API/Sector/ModificarSector"
                , new StringContent(JsonConvert.SerializeObject(sector), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("Sector/BorrarSector")]
        public async Task<IActionResult> BorrarSector(int id)
        {
            HttpClient httpClient = new();
            var Response = await httpClient.DeleteAsync("https://localhost:44358/API/Sector/BorrarSector/" + id);
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BuscarSectorPorNombre(int idSector)
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
        private void DisplaySectorInformation()
        {
            List<SectorViewModel> sectores = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result);
            if (TempData["idSector"] != null)
            {
                List<SectorViewModel> sector = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result)
                    .Where(s => s.IdSector == (int)TempData["idSector"]).ToList();
                if (sector.Count != 0)
                {
                    ViewBag.sectores = sector;
                }
                else
                {
                    TempData["isShow"] = true;
                    TempData["message"] = "No existen resultados para su búsqueda.";
                }
            }
            else
            {
                ViewBag.sectores = sectores;
            }
            ViewBag.Allsectores = sectores;
        }
    }
}
