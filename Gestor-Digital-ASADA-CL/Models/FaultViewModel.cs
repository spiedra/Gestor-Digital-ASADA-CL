using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class FaultViewModel
    {
        public FaultViewModel()
        {
            AveriaTrabajadors = new HashSet<AveriaTrabajador>();
        }

        [Required(ErrorMessage = "El sector requerido")]
        public int IdSector { get; set; }
        public int IdAveria { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido")]
        public int IdTrabajador { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Afectado { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime FechaReporte { get; set; }
        [Required(ErrorMessage = "Los detalles son requeridos")]
        public string DetallesReporte { get; set; }
        [Required(ErrorMessage = "La fecha de ejecución es requerida")]
        public DateTime FechaEjecucion { get; set; }
        [Required(ErrorMessage = "El trabajo ejecutado es requerido")]
        public string TrabajoEjecutado { get; set; }
        public bool? IsDelete { get; set; }

        public ICollection<AveriaTrabajador> AveriaTrabajadors { get; set; }
    }
}
