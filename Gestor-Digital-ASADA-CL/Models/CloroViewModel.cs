using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Gestor_Digital_ASADA_CL.Models
{
    public class CloroViewModel
    {
        public int IdCloroResidual { get; set; }

        [Required(ErrorMessage = "El nombre del trabajador es requerido")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El número de casa es requerido")]
        public int NumeroCasa { get; set; }

        [Required(ErrorMessage = "La fecha y hora son requeridas")]
        public DateTime Fecha { get; set; }
     
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha1 { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime FechaFinal { get; set; }

        [Required(ErrorMessage = "El porcentaje es requerido")]
        public string PorcentajeCloro { get; set; }

        [Required(ErrorMessage = "El detalle es requerido")]
        public string Detalles { get; set; }
       
     
    }
}