using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class DailyCollectionViewModel
    {
        public int IdRecaudacion { get; set; }
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "La fecha de recaudación es requerida")]
        public DateTime FechaRecaudacion { get; set; }

        [Required(ErrorMessage = "La fecha de recaudación es requerida")]
        public DateTime FechaRecaudacionFinal { get; set; }

        [Required(ErrorMessage = "La cantidad de efectivo es requerida")]
        public string CantidadEfectivo { get; set; }

        [Required(ErrorMessage = "La cantidad de dinero en tarjeta es requerida")]
        public string CantidadTarjeta { get; set; }

        [Required(ErrorMessage = "La cantidad de dinero por sinpe es requerida")]
        public string CantidadSinpe { get; set; }

        [Required(ErrorMessage = "La cantidad del IVA es requerida")]
        public string CantidadIva { get; set; }

        [Required(ErrorMessage = "La cantidad de hidrantes es requerida")]
        public int CuentaHidrantes { get; set; }

        [Required(ErrorMessage = "El total es requerido")]
        public string TotalRecaudado { get; set; }

        [Required(ErrorMessage = "La cantidad de recibos es requerida")]
        public int? CantidadRecibos { get; set; }
    }
}
