using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gestor_Digital_ASADA_CL.Models
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "El código de producto es requerido")]
        public string CodigoProducto { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "El valor unitario es requerido")]
        public string ValorUnitario { get; set; }
        [Required(ErrorMessage = "La cantidad es requerida")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }

        public bool? IsDelete { get; set; }

    }
}
