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
    public class CloroController : Controller
    {
        public IActionResult Index()
        {
            DisplayMessageDynamically();
            UserController userController = new();
            //ViewBag.Users = JsonConvert.DeserializeObject<List<User>>(userController.Details().Result);
            ViewBag.cloro = JsonConvert.DeserializeObject<List<CloroViewModel>>(ObtenerCloro().Result);
            ViewBag.fontaneros = JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result);
            //DisplayCloroInformation();
            return View();
        }

        [HttpPost]
        [Route("Cloro/RegistrarCloro")]
        public async Task<IActionResult> RegistrarCloro(CloroViewModel cloro)
        {
            HttpClient httpClient = new();
            //cloro.IdUsuario = Int32.Parse(await UserController.GetUserIdByUserName(HttpContext.User.Identity.Name));
            var Response = await httpClient.PostAsync("https://localhost:44358/API/Cloro/RegistrarCloro"
                , new StringContent(JsonConvert.SerializeObject(cloro), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        public async Task<string> ObtenerCloro()
        {
            HttpClient httpClient = new ();
            var Response = await httpClient.GetAsync("https://localhost:44358/API/Cloro/ObtenerCloro");
            return await Response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        [Route("Sector/ModificarCloro")]
        public async Task<IActionResult> ModificarCloro(CloroViewModel cloro)
        {
            HttpClient httpClient = new();
            //cloro.IdUsuario = Int32.Parse(await UserController.GetUserIdByUserName(HttpContext.User.Identity.Name));
            var Response = await httpClient.PutAsync("https://localhost:44358/API/Cloro/ModificarCloro"
                , new StringContent(JsonConvert.SerializeObject(cloro), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
       

        [HttpGet]
        public IActionResult BuscarCloroPorFecha(int idCloro)
        {
            TempData["idCloro"] = idCloro;
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
        public async Task<string> ObtenerFontaneros()
        {
            HttpClient httpClient = new HttpClient();
            var Response = await httpClient.GetAsync("https://localhost:44358/API/Cloro/ObtenerFontaneros");
            return await Response.Content.ReadAsStringAsync();
        }

        //private void DisplayCloroInformation()
        //{
        //    if (TempData["idSector"] != null)
        //    {
        //        List<SectorViewModel> sector = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result)
        //            .Where(s => s.IdSector == (int)TempData["idSector"]).ToList();
        //        if (sector.Count != 0)
        //        {
        //            ViewBag.sectores = sector;
        //        }
        //        else
        //        {
        //            TempData["isShow"] = true;
        //            TempData["message"] = "No existen resultados para su búsqueda.";
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.sectores = JsonConvert.DeserializeObject<List<SectorViewModel>>(ObtenerSectores().Result);
        //    }
        //}
    }
}
