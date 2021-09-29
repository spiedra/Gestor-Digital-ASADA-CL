using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class TaskViewModel
    {
        [Required(ErrorMessage = "El título es requerido")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El detalle es requerido")]
        public string Detail { get; set; }
    }
}
