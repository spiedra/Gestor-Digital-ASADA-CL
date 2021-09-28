using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "El código de producto es requerido")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El valor unitario es requerido")]
        public string UnitValue { get; set; }
        [Required(ErrorMessage = "La cantidad es requerida")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime InDate { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }

    }
}
