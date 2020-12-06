using System;
using System.ComponentModel.DataAnnotations;

namespace Servicio.Services.Queries
{
    public partial class ventaDto
    {
         public int ventaid { get; set; }

         [Range(0, int.MaxValue)]
         public int? clienteid { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [DataType(DataType.Date)]
         public DateTime fechaemision { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [MaxLength(4, ErrorMessage = "Máximo de 4 caracteres")]
         public string serie { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public long correlativo { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal baseimponible { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal igv { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal total { get; set; }

         [DataType(DataType.Date)]
         public DateTime? fecharegistro { get; set; }

         [Range(0, int.MaxValue)]
         public int? documentoid { get; set; }

   
    }
}
