using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            //validar usuario en API
            HttpClient httpClient = new HttpClient();
            string user = "{ 'NombreUsuario': +'" + UserViewModel.NombreUsuario + "','Contrasenia':+'" + UserViewModel.Contrasenia + "'}";
            StringContent content = new StringContent(user, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44358/API/Usuario/IniciarSesion/" + UserViewModel.NombreUsuario + "/" + UserViewModel.Contrasenia, content);
            string action = await response.Content.ReadAsStringAsync();


            //según la respuesta valida que tipo de usuario es, y crea una identidad (sesion) en el sistema.
           
            switch (action)
            {
                case "1":

                    //creacion de claim de usuario
                    await CreateUserSession(UserViewModel.NombreUsuario, "Admin");
                    return Redirect("~/Home/Index");

                case "2":

                    await CreateUserSession(UserViewModel.NombreUsuario, "Fontanero");
                    return Redirect("~/Home/Client/Index");

                default:
                    ViewBag.ShowModalResponse = true;
                    ViewBag.Message = action;
                    return View("Index");
            }
        }

        public async Task<bool> CreateUserSession(string NombreUsuario, string Role) {

            List<Claim> claims;
            AuthenticationProperties authProperties;
            ClaimsIdentity claimsIdentity;

            claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name,NombreUsuario ),
                 new Claim(ClaimTypes.Role, Role),
             };

            //uso de cookies para la sesion

            claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //propiedades de la sesion

            authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires.

                IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            //informe al contexto (todo el sistema) que hay un nuevo usuario
            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

            return true;
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Index");
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
