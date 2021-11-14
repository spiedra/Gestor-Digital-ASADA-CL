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

        [Route("Client/Task/Index")]
        public async Task<ActionResult> IndexClient()
        {
            int UserId = Int32.Parse(await UserController.GetUserIdByUserName(HttpContext.User.Identity.Name));
            ViewBag.Tasks = JsonConvert.DeserializeObject<List<TaskViewModel>>(Details(UserId).Result).Where(x => x.Realizada == false);
            ViewBag.TasksDone = JsonConvert.DeserializeObject<List<TaskViewModel>>(Details(UserId).Result).Where(x => x.Realizada == true);
            DisplayMessageDynamically();
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
            var response = await httpClient.PutAsync("https://localhost:44358/API/Tarea/ModificarTarea", new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
            return Json(await response.Content.ReadAsStringAsync());
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int IdTask)
        {
            HttpClient httpClient = new();
            var response = await httpClient.DeleteAsync("https://localhost:44358/API/Tarea/EliminarTarea/" + IdTask);
            return Json(await response.Content.ReadAsStringAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CompleteTask(TaskViewModel taskViewModel)
        {
            HttpClient httpClient = new();
            var response = await httpClient.PostAsync("https://localhost:44358/API/Tarea/CompletarTarea"
                , new StringContent(JsonConvert.SerializeObject(taskViewModel), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("IndexClient");
        }

        [HttpGet]
        public JsonResult GetTasksByUserId(int UserId)
        {
            return Json(JsonConvert.DeserializeObject<List<TaskViewModel>>(Details(UserId).Result));
        }

        [HttpGet]
        public JsonResult GetTasksByTitle(int UserId, string Title) =>
            Json(JsonConvert.DeserializeObject<List<TaskViewModel>>(Details(UserId).Result)
                .Where(x => x.Titulo.ToLower().Contains(Title.ToLower())).ToList());

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