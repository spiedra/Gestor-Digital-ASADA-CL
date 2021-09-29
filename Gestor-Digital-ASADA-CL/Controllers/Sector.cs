using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class Sector : Controller
    {
        // GET: Sector
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sector/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sector/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sector/Create
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

        // GET: Sector/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sector/Edit/5
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

        // GET: Sector/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sector/Delete/5
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
