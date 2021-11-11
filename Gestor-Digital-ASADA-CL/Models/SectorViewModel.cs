using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class SectorViewModel
    {
        public int IdSector { get; set; }
        [Required(ErrorMessage = "El nombre del sector es requerido")]
        public string NombreSector { get; set; }
        public bool? IsDelete { get; set; }
    }
}
