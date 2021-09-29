using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController1/Create
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡Usuario registrado correctamente!";
            return View("Index");
        }

        // POST: UserController1/Edit
        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
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
    }
}
