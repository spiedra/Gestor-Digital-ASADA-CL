using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class DailyCollectionViewModel
    {
        [Required(ErrorMessage = "La cantidad de hidrantes es requerida")]
        public string Hydrant { get; set; }

        [Required(ErrorMessage = "La cantidad de recibos es requerida")]
        public string Invoce { get; set; }

        [Required(ErrorMessage = "La cantidad del IVA es requerida")]
        public string Tax { get; set; }

        [Required(ErrorMessage = "La cantidad de efectivo es requerida")]
        public string Cash { get; set; }

        [Required(ErrorMessage = "El total es requerido")]
        public string Total { get; set; }

        [Required(ErrorMessage = "La fecha de recaudación es requerida")]
        public string Date { get; set; }
    }
}
