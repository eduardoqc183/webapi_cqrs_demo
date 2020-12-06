using System;
using System.ComponentModel.DataAnnotations;

namespace Servicio.Services.Queries
{
    public partial class productoDto
    {
         public int productoid { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
         public string codproducto { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
         public string nombreproducto { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public decimal valorunitario { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [Range(0, int.MaxValue)]
         public int unidadmedidaid { get; set; }

         [DataType(DataType.Date)]
         public DateTime? fecharegistro { get; set; }

    }
}
