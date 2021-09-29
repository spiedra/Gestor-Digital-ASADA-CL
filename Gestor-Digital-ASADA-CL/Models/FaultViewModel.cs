using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class FaultViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El número de casa es requerido")]
        public int IdHouse { get; set; }
        [Required(ErrorMessage = "El nombre del trabajador es requerido")]
        public string NameW { get; set; }
        [Required(ErrorMessage = "La fecha de reporte es requerida")]
        public DateTime ReportDate { get; set; }
        [Required(ErrorMessage = "La fecha de ejecución es requerida")]
        public DateTime ExecutionDate { get; set; }

        [Required(ErrorMessage = "La descripción de la avería es requerida")]
        public string Details { get; set; }
        [Required(ErrorMessage = "El trabajo ejecutado es requerido")]
        public string Work { get; set; }

    }
}