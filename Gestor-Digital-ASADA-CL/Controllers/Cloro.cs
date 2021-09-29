using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class Cloro : Controller
    {
        // GET: Cloro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cloro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cloro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cloro/Create
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

        // GET: Cloro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cloro/Edit/5
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

        // GET: Cloro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
       
        // POST: Cloro/Delete/5
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
        //------------ CLORO USUARIO ---------//
        // GET: Cloro
        public ActionResult IndexUser()
        {
            return View();
        }

        // GET: Cloro/Details/5
        public ActionResult DetailsUser(int id)
        {
            return View();
        }

        // GET: Cloro/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Cloro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(IFormCollection collection)
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

        // GET: Cloro/Edit/5
        public ActionResult EditUser(int id)
        {
            return View();
        }

        // POST: Cloro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(int id, IFormCollection collection)
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

        // GET: Cloro/Delete/5
        public ActionResult DeleteUser(int id)
        {
            return View();
        }
       
        // POST: Cloro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(int id, IFormCollection collection)
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
