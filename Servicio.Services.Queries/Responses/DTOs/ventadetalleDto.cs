using System;
using System.ComponentModel.DataAnnotations;

namespace Servicio.Services.Queries
{
    public partial class ventadetalleDto
    {
         public int ventadetalleid { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal cantidad { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal valorunitario { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal valor { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal igv { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal precio { get; set; }

         [Range(0, int.MaxValue)]
         public int? ventaid { get; set; }

         [Range(0, int.MaxValue)]
         public int? productoid { get; set; }

    }
}
