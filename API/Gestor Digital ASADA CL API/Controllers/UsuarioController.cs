using Gestor_Digital_ASADA_CL_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    public class UsuarioController : Controller
    {
        GestorDigitalASADACLAYDContext db;
        public UsuarioController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("/API/Usuario/IniciarSesion/{NombreUsuario}/{Contrasenia}")]
        public IActionResult Login(string NombreUsuario, string Contrasenia)
        {
            //return Ok(NombreUsuario+ Contrasenia);

            bool UserExists = db.Usuarios.ToList().Exists(
                u => u.NombreUsuario.Equals(NombreUsuario)
                &&
                 u.Contrasenia.Equals(Contrasenia)
                );

            if (UserExists)
            {
                var userAux = db.Usuarios.First
                (
                u =>
                u.NombreUsuario.Equals(NombreUsuario)
                &&
                u.Contrasenia.Equals(Contrasenia)
                );

                return Ok(userAux.IdRole);
            }
            else
            {
                return Ok("Los datos de usuario no coinciden.");
            }
        }
    }
}
