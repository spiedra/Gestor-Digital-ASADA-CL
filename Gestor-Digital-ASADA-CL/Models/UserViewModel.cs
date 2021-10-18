using System.ComponentModel.DataAnnotations;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class UserViewModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellidos { get; set; }


        [Required(ErrorMessage = "La cédula es requerida")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El puesto es requerido")]
        public string IdRole { get; set; }
    }
}