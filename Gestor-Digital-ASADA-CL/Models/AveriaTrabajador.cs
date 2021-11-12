using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Digital_ASADA_CL.Models
{
    public partial class AveriaTrabajador
    {
        public int IdAveria { get; set; }
        public int IdTrabajador { get; set; }
        public bool? IsDelete { get; set; }
    }
}
