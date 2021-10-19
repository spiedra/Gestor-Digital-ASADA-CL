using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class IndexController : Controller
    {
        // GET: IndexController
        public ActionResult Index()
        {
            ViewBag.ServerResponse = false;
            return View();
        }

        // GET: IndexController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Index/Authentication
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Authentication(User UserViewModel)
        {
            HttpClient httpClient = new HttpClient();
            string user = "{ 'NombreUsuario': +'" + UserViewModel.NombreUsuario + "','Contrasenia':+'" + UserViewModel.Contrasenia + "'}";

            //string json = new JavaScriptSerializer().Serialize(new
            //{
            //    Username = "myusername",
            //    Password = "password"
            //});

            StringContent content = new StringContent(user, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44358/API/Usuario/IniciarSesion/"+UserViewModel.NombreUsuario+"/"+UserViewModel.Contrasenia, content);
            string action = await response.Content.ReadAsStringAsync();

            switch (action)
            {
                case "1":
                    var claimsAdmin = new[] { new Claim(ClaimTypes.Name, UserViewModel.NombreUsuario),
                    new Claim(ClaimTypes.Role, "Admin") };
                    var identityAdmin = new ClaimsIdentity(claimsAdmin, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.User = new ClaimsPrincipal(identityAdmin);

                    return Redirect("~/Home/Index");

                case "2":
                    var claimsFontanero = new[] { new Claim(ClaimTypes.Name, UserViewModel.NombreUsuario),
                    new Claim(ClaimTypes.Role, "Fontanero") };
                    var identityFontanero = new ClaimsIdentity(claimsFontanero, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.User = new ClaimsPrincipal(identityFontanero);
                    return Redirect("~/Home/Client/Index");

                default:
                    ViewBag.ShowModalResponse = true;
                    ViewBag.Message = action;
                    return View("Index");
            }
        }

        // POST: IndexController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: IndexController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: IndexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndexController/Delete/5
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
    }
}
