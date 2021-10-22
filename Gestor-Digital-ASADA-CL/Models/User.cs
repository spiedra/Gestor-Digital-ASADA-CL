using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class User
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasenia { get; set; }

        public int IdRole { get; set; }

        [Required(ErrorMessage = "El puesto es requerido")]
        public string RoleName { get; set; }

        public bool? IsDelete { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}