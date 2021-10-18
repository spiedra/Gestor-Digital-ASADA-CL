using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Controllers
{
    public class PersonalBinnacleController : Controller
    {
        // GET: PersonalBinnacle
        public ActionResult Index1()
        {

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<string> ObtenerActividades()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44358/API/Producto/ObtenerProductos");
            return await response.Content.ReadAsStringAsync();
        }

        // GET: PersonalBinnacle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonalBinnacle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalBinnacle/Create
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

        [HttpPost]
        [Route("PersonalBinnacle/Edit")]
        public ActionResult Edit()
        {
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = "Actividad modificada con éxito";
            return View("Index");
        }

        // POST: PersonalBinnacle/Edit/5
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

        [HttpPost]
        [Route("PersonalBinnacle/Delete")]
        public ActionResult Delete()
        {
            ViewBag.ShowModalResponse = "True";
            ViewBag.mensaje = "Actividad borrada con éxito";
            return View("Index");
        }

        // POST: PersonalBinnacle/Delete/5
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
