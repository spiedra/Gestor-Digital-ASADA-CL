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
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ShowModalResponse = false;
            UserController userController = new();
            ViewBag.Users = JsonConvert.DeserializeObject<List<User>>(userController.Details().Result);
            return View();
        }

        [Route("Home/Task/Client/Index")]
        public ActionResult Index1()
        {
            return View();
        }

        [HttpGet]
        public async Task<string> Details(int UserId)
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Tarea/ObtenerTareasByIdUsuario/" + UserId);
            return await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        public async Task<JsonResult> Create(int UserId, string Title, string Details)
        {
            HttpClient httpClient = new();
            TaskViewModel task = new()
            {
                IdUsuario = UserId,
                Titulo = Title,
                Detalles = Details,
                FechaAsignacion = DateTime.Now
            };
            var response = await httpClient.PostAsync("https://localhost:44358/API/Tarea/RegistrarTarea", new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
            return Json(await response.Content.ReadAsStringAsync());
        }

        [HttpPost]
        public async Task<JsonResult> Edit(int IdTask, int UserId, string Title, string Details)
        {
            HttpClient httpClient = new();
            TaskViewModel task = new()
            {
                IdTarea = IdTask,
                IdUsuario = UserId,
                Titulo = Title,
                Detalles = Details
            };
            var response = await httpClient.PutAsync("https://localhost:44358/API/Tarea/ModificarTarea",new StringContent(JsonConvert.SerializeObject(task),Encoding.UTF8,"application/json"));
            return Json(await response.Content.ReadAsStringAsync());
        }

        public ActionResult Delete()
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡La tarea ha sido eliminado correctamente!";
            return View("Index");
        }

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

        [HttpGet]
        public JsonResult GetTasksByUserId(int UserId)
        {
            return Json(JsonConvert.DeserializeObject<List<TaskViewModel>>(Details(UserId).Result));
        }
    }
}