using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Gestor_Digital_ASADA_CL.Models
{
    public class CloroViewModel
    {
        public int? IdUsuario { get; set; }
        public int IdCloroResidual { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "La hora es requerida")]
        public DateTime Time { get; set; }
        [Required(ErrorMessage = "El porcentaje es requerido")]
        public int Percent { get; set; }
        [Required(ErrorMessage = "El número de casa es requerido")]
        public int IdHouse { get; set; }
        [Required(ErrorMessage = "El nombre del trabajador es requerido")]
        public string NameC { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        public string NameE { get; set; }
    }
}