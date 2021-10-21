using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController1
        public ActionResult Index()
        {
            ViewBag.ShowModalResponse = false;
            ViewBag.users = JsonConvert.DeserializeObject<List<User>>(Details().Result);
            ViewBag.Role = JsonConvert.DeserializeObject<RoleViewModel>(GetRoleById(1).Result);
            return View();
        }

        // GET: UserController
        public async Task<string> Details()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Usuario/ObtenerUsuarios");
            return await response.Content.ReadAsStringAsync();
        }

        // GET: UserController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController1/Create
        [HttpPost]
        public ActionResult Create(User userViewModel)
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡Usuario registrado correctamente!";
            return View("Index");
        }

        // POST: UserController1/Edit
        [HttpPost]
        public ActionResult Edit(User userViewModel)
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡La información del usuario ha sido actualizada correctamente!";
            return View("Index");
        }

        // GET: UserController1/Delete/5
        public ActionResult Delete()
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡El usuario ha sido eliminado correctamente!";
            return View("Index");
        }

        // POST: UserController1/Delete/5
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

        private async Task<string> GetRoleById(int idRole)
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Role/GetRoleById/"+idRole);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
