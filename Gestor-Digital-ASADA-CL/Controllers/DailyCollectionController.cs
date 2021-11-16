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
    public class DailyCollectionController : Controller
    {
        public ActionResult Index()
        {
            DisplayMessageDynamically();
            UserController userController = new();
            ViewBag.Users = JsonConvert.DeserializeObject<List<User>>(userController.Details().Result);
            DisplayCollectionInformation();
            return View();
        }

        public async Task<string> Details()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Recaudacion/ObtenerRecaudacionesDiarias");
            return await response.Content.ReadAsStringAsync();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DailyCollectionViewModel dailyCollection)
        {
            HttpClient httpClient = new();
            dailyCollection.IdUsuario = Int32.Parse(await UserController.GetUserIdByUserName(HttpContext.User.Identity.Name)); 
            var response = await httpClient.PostAsync("https://localhost:44358/API/Recaudacion/RegistrarRecaudacion"
                , new StringContent(JsonConvert.SerializeObject(dailyCollection), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DailyCollectionViewModel dailyCollection)
        {
            HttpClient httpClient = new();
            dailyCollection.IdUsuario = Int32.Parse(await UserController.GetUserIdByUserName(HttpContext.User.Identity.Name));
            var response = await httpClient.PutAsync("https://localhost:44358/API/Recaudacion/ModificarRecaudacion"
                , new StringContent(JsonConvert.SerializeObject(dailyCollection), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        // GET: DailyCollection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DailyCollection/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void DisplayMessageDynamically()
        {
            if (TempData["isShow"] != null && TempData["message"] != null)
            {
                ViewBag.ShowModalResponse = TempData["isShow"];
                ViewBag.Message = TempData["message"];
            }
        }

        private void DisplayCollectionInformation()
        {
            if (TempData["startDate"] != null && TempData["endDate"] != null)
            {
                List<DailyCollectionViewModel> collections = JsonConvert.DeserializeObject<List<DailyCollectionViewModel>>(Details().Result)
                    .Where(x => x.FechaRecaudacion >= (DateTime)TempData["startDate"] && x.FechaRecaudacion <= (DateTime)TempData["endDate"]).ToList();
                if (collections.Count == 0)
                {
                    ViewBag.Collections = JsonConvert.DeserializeObject<List<DailyCollectionViewModel>>(Details().Result);
                    ViewBag.ShowModalResponse = true;
                    ViewBag.Message = "Recaudaciones no encontradas. Inténtelo de nuevo";
                }
                else
                {
                    ViewBag.Collections = collections;
                }
            }
            else
            {
                ViewBag.Collections = JsonConvert.DeserializeObject<List<DailyCollectionViewModel>>(Details().Result);
            }
        }

        [HttpGet]
        public IActionResult GetCollectionsByDateRange(DailyCollectionViewModel dailyCollectionViewModel)
        {
            TempData["startDate"] = dailyCollectionViewModel.FechaRecaudacion;
            TempData["endDate"] = dailyCollectionViewModel.FechaRecaudacionFinal;
            return RedirectToAction("Index");
        }
    }
}
