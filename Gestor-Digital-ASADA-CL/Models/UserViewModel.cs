using System.ComponentModel.DataAnnotations;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
    }
}