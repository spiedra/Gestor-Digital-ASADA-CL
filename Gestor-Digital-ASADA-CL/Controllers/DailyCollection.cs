using Gestor_Digital_ASADA_CL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class DailyCollection : Controller
    {
        // GET: DailyCollection
        public ActionResult Index()
        {
            return View();
        }

        // GET: DailyCollection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DailyCollection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DailyCollection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DailyCollectionViewModel dailyCollectionViewModel)
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡Recaudación diaria registrada correctamente!";
            return View("Index");
        }

        // GET: DailyCollection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DailyCollection/Edit/5
        [HttpPost]
        public ActionResult Edit(DailyCollectionViewModel dailyCollectionViewModel)
        {
            ViewBag.ShowModalResponse = true;
            ViewBag.Message = "¡La información de la recaudación diaria ha sido actualizada correctamente!";
            return View("Index");
        }

        // GET: DailyCollection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DailyCollection/Delete/5
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
