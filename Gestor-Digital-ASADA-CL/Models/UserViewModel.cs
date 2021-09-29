using System.ComponentModel.DataAnnotations;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "La cédula es requerida")]
        public string IdCard { get; set; }

        [Required(ErrorMessage = "El puesto es requerido")]
        public string Job { get; set; }
    }
}