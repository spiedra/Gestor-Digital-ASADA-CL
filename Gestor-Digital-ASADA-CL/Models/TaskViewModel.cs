using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class TaskViewModel
    {
        public int IdTarea { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El detalle es requerido")]
        public string Detalles { get; set; }

        public int IdUsuario { get; set; }

        public bool Realizada { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public bool? IsDelete { get; set; }
    }
}
