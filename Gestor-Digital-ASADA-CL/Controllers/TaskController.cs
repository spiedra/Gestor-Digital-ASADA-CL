using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class TaskController : Controller
    {
        // GET: TaskController
        public ActionResult Index()
        {
            ViewBag.ShowModalResponse = false;
            return View();
        }

        [Route("Home/Task/Client/Index")]
        public ActionResult Index1()
        {
            return View();
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡Tarea registrada correctamente!";
            return View("Index");
        }

        // POST: TaskController/Edit
        public ActionResult Edit(TaskViewModel taskViewModel)
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡La información de la tarea ha sido actualizada correctamente!";
            return View("Index");
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete()
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡La tarea ha sido eliminado correctamente!";
            return View("Index");
        }

        // POST: TaskController/Delete/5
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
