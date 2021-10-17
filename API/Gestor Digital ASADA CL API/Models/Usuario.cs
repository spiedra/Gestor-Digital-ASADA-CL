using System;
using System.Collections.Generic;

#nullable disable

namespace Gestor_Digital_ASADA_CL_API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AveriaTrabajadors = new HashSet<AveriaTrabajador>();
            CloroResiduals = new HashSet<CloroResidual>();
            RecaudacionDiaria = new HashSet<RecaudacionDiarium>();
            Tareas = new HashSet<Tarea>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int IdRole { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<AveriaTrabajador> AveriaTrabajadors { get; set; }
        public virtual ICollection<CloroResidual> CloroResiduals { get; set; }
        public virtual ICollection<RecaudacionDiarium> RecaudacionDiaria { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
