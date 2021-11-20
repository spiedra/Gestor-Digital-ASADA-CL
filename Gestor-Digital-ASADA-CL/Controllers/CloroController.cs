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
            DisplayCloroInformation();
            UserController userController = new();
            ViewBag.Allfontaneros = JsonConvert.DeserializeObject<List<User>>(userController.GetAllUsers().Result);
            ViewBag.fontaneros = JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result);
            DisplayMessageDynamically();
            
            return View();
        }
        public IActionResult IndexUser()
        {
            DisplayCloroInformation();
            UserController userController = new();
            ViewBag.Allfontaneros = JsonConvert.DeserializeObject<List<User>>(userController.GetAllUsers().Result);
            ViewBag.fontaneros = JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result);
            DisplayMessageDynamically();

            return View();
        }

        [HttpPost]
        [Route("Cloro/RegistrarCloro")]
        public async Task<IActionResult> RegistrarCloro(CloroViewModel cloro)
        {
            HttpClient httpClient = new();
            var Response = await httpClient.PostAsync("https://localhost:44358/API/Cloro/RegistrarCloro"
                , new StringContent(JsonConvert.SerializeObject(cloro), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();
            
            if (HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("IndexUser");

        }

        public async Task<string> ObtenerCloro()
        {
            HttpClient httpClient = new ();
            var Response = await httpClient.GetAsync("https://localhost:44358/API/Cloro/ObtenerCloro");
            return await Response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        [Route("Cloro/ModificarCloro")]
        public async Task<IActionResult> ModificarCloro(CloroViewModel cloro)
        {
           HttpClient httpClient = new();
            var Response = await httpClient.PutAsync("https://localhost:44358/API/Cloro/ModificarCloro"
                , new StringContent(JsonConvert.SerializeObject(cloro), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await Response.Content.ReadAsStringAsync();            
            if (HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("IndexUser");
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

        [HttpGet]
        public JsonResult GetFontanerosByAjax()
        {
            return Json(JsonConvert.DeserializeObject<List<User>>(ObtenerFontaneros().Result));
        }

        private void DisplayCloroInformation()
        {
            if (TempData["fechaInicio"] != null && TempData["fechaFin"] != null)
            {
                List<CloroViewModel> datosCloro = JsonConvert.DeserializeObject<List<CloroViewModel>>(ObtenerCloro().Result)
                    .Where(x => x.Fecha >= (DateTime)TempData["fechaInicio"] && x.Fecha <= (DateTime)TempData["fechaFin"]).ToList();
                if (datosCloro.Count == 0)
                {
                    ViewBag.cloro = JsonConvert.DeserializeObject<List<CloroViewModel>>(ObtenerCloro().Result);
                    ViewBag.ShowModalResponse = true;
                    ViewBag.Message = "Información no encontrada. Inténtelo de nuevo";
                }
                else
                {
                    ViewBag.cloro = datosCloro;
                }
            }
            else
            {
                ViewBag.cloro = JsonConvert.DeserializeObject<List<CloroViewModel>>(ObtenerCloro().Result);
            }
        }

        [HttpGet]
        public IActionResult BuscarCloroPorFecha(CloroViewModel cloro)
        {
            TempData["fechaInicio"] = cloro.Fecha1;
            TempData["fechaFin"] = cloro.FechaFinal;
            
            if (HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("IndexUser");
        }


    }
}
