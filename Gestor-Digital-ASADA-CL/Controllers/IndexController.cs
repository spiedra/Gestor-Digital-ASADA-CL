using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Authentication(UserViewModel UserViewModel)
        {
            if (UserViewModel.NombreUsuario == "admin" && UserViewModel.Contrasenia == "admin")
            {

                return Redirect("~/Home/Index");
            }
            else if (UserViewModel.Nombre == "fontanero" && UserViewModel.Contrasenia == "fontanero")
            {
                return Redirect("~/Home/Client/Index");
            }

            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡Nombre o contraseña incorrectos!";
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
