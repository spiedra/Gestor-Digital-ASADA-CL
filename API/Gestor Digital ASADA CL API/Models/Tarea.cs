using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Tarea
    {
        public int IdTarea { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string Titulo { get; set; }
        public string Detalles { get; set; }
        public int IdUsuario { get; set; }
        public bool? Realizada { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
