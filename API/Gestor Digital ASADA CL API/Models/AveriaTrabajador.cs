using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class AveriaTrabajador
    {
        public int IdAveria { get; set; }
        public int IdTrabajador { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Averium IdAveriaNavigation { get; set; }
        public virtual Usuario IdTrabajadorNavigation { get; set; }
    }
}
