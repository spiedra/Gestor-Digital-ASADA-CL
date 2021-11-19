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
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            DynamicUserSending();
            ViewBag.Roles = JsonConvert.DeserializeObject<List<RoleViewModel>>(GetRoles().Result);
            DisplayMessageDynamically();
            return View();
        }

        public async Task<string> Details()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Usuario/ObtenerUsuarios");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAllUsers()
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Usuario/ObtenerTodosUsuarios");
            return await response.Content.ReadAsStringAsync();
        }

        [HttpGet]
        public IActionResult Details(User user)
        {
            TempData["name"] = user.Nombre;
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            HttpClient httpClient = new();
            user.IdRole = Int32.Parse(await GetRoleIdByName(user.RoleName));
            var response = await httpClient.PostAsync("https://localhost:44358/API/Usuario/RegistrarUsuario", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            TempData["isShow"] = true;
            TempData["message"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int idUser)
        {
            HttpClient httpClient = new();
            var response = await httpClient.DeleteAsync("https://localhost:44358/API/Usuario/EliminarUsuario/" + idUser);
            TempData["isShow"] = true;
            TempData["message"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
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

        private void DynamicUserSending()
        {
            if (TempData["name"] != null)
            {
                List<User> users = JsonConvert.DeserializeObject<List<User>>(Details().Result).Where(u => u.Nombre.ToLower().Contains(((string)TempData["name"]).ToLower())).ToList();
                if (users.Count != 0)
                {
                    ViewBag.Users = users;
                }
                else
                {
                    ViewBag.Users = JsonConvert.DeserializeObject<List<User>>(Details().Result);
                    ViewBag.ShowModalResponse = true;
                    ViewBag.Message = "Usuario no encontrado. Inténtelo de nuevo";
                }
            }
            else
            {
                ViewBag.Users = JsonConvert.DeserializeObject<List<User>>(Details().Result);
            }
        }

        public static async Task<string> GetUserIdByUserName(string userName)
        {
            HttpClient httpClient = new();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Usuario/ObtenerUsuarioIdByNombeUsuario/" + userName);
            return await response.Content.ReadAsStringAsync();
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