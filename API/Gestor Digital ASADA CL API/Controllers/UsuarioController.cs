using Gestor_Digital_ASADA_CL_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        GestorDigitalASADACLAYDContext db;
        public UsuarioController(GestorDigitalASADACLAYDContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("/API/Usuario/ObtenerUsuarios")]
        public async Task<IActionResult> Details()
        {
            return Ok(await db.Usuarios.ToListAsync());
        }

        [HttpGet]
        [Route("/API/Usuario/ObtenerUsuarioIdByNombeUsuario/{nombreUsuario}")]
        public async Task<IActionResult> Details(string nombreUsuario)
        {
            if (nombreUsuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            var user = await db.Usuarios
                .FirstOrDefaultAsync(m => m.NombreUsuario == nombreUsuario);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.IdUsuario);
        }

        [HttpPut]
        [Route("/API/Usuario/ModificarUsuario")]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            var original = db.Usuarios.Find(usuario.IdUsuario);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(usuario);
                await db.SaveChangesAsync();
                return Ok("Usuario modificado con éxito");
            }
            else
            {
                return Ok("Ha ocurrido un error al modificar al usuario. Inténtelo de nuevo");
            }
        }

        [HttpPost]
        [Route("/API/Usuario/RegistrarUsuario")]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            if (db.Usuarios.ToList().Exists(i => i.Cedula.ToString().ToLower().Equals(usuario.Cedula.ToString().ToLower())))
            {
                return Ok("Cédula existente en el sistema. Inténtelo de nuevo");
            }
            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();
            return Ok("Usuario registrado con éxito");
        }

        [HttpDelete]
        [Route("/API/Usuario/EliminarUsuario/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userFinded = db.Usuarios.Find(id);
            if (userFinded != null)
            {
                db.Remove(userFinded);
                await db.SaveChangesAsync();
                return Ok("Usuario eliminado con éxito!");
            }
            else
            {
                return Ok("Error al eliminar el usuario. Inténtelo de nuevo");
            }
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