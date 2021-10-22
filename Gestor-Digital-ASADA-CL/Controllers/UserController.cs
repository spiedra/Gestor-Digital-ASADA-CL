﻿using Gestor_Digital_ASADA_CL.Models;
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
    public class UserController : Controller
    {
        // GET: UserController1
        public ActionResult Index()
        {
            ViewBag.users = JsonConvert.DeserializeObject<List<User>>(Details().Result);
            ViewBag.Roles = JsonConvert.DeserializeObject<List<RoleViewModel>>(GetRoles().Result);

            if (TempData["isShow"] != null && TempData["message"] != null) {
                ViewBag.ShowModalResponse = TempData["isShow"];
                ViewBag.Message = TempData["message"];
            }

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

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            HttpClient httpClient = new();
            user.IdRole = Int32.Parse(await GetRoleIdByName(user.RoleName));
            var response = await httpClient.PutAsync("https://localhost:44358/API/Usuario/ModificarUsuario", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetUsersByAjax()
        {
            return Json(JsonConvert.DeserializeObject<List<User>>(Details().Result));
        }

        private async Task<string> GetRoleById(int idRole)
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Role/GetRoleById/" + idRole);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetRoleIdByName(string roleName)
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Role/GetRoleIdByName/" + roleName);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetRoles()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Role/GetRoles");
            return await response.Content.ReadAsStringAsync();
        }

        [HttpGet]
        public JsonResult GetRolesByAjax()
        {
            return Json(JsonConvert.DeserializeObject<List<RoleViewModel>>(GetRoles().Result));
        }
    }
}
