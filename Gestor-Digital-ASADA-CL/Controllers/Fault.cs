using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class Fault : Controller
    {
        // GET: Fault
        public ActionResult Index()
        {
            return View();
        }

        // GET: Fault/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fault/Create
        public ActionResult InsertFault()
        {
            return View();
        }

        // POST: Fault/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertFault(IFormCollection collection)
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

        // GET: Fault/Edit/5
        public ActionResult EditFault(int id)
        {
            return View();
        }

        // POST: Fault/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFault(int id, IFormCollection collection)
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

        // GET: Fault/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [Route("Fault/Delete")]
        public ActionResult Delete()
        {
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = "Avería eliminada con éxito";
            return View("Index");
        }

        // POST: Fault/Delete/5
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
