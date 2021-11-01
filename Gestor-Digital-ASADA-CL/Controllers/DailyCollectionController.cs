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
            ViewBag.Collections = JsonConvert.DeserializeObject<List<DailyCollectionViewModel>>(Details().Result);
            return View();
        }

        public async Task<string> Details()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Recaudacion/ObtenerRecaudacionesDiarias");
            return await response.Content.ReadAsStringAsync();
        }

        // GET: DailyCollection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DailyCollection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DailyCollectionViewModel dailyCollectionViewModel)
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡Recaudación diaria registrada correctamente!";
            return View("Index");
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
    }
}
