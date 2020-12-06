using System;
using System.ComponentModel.DataAnnotations;

namespace Servicio.Services.Queries
{
    public partial class documentoDto
    {
         public int documentoid { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [MaxLength(3, ErrorMessage = "Máximo de 3 caracteres")]
         public string siglas { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
         public string descripcion { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public bool esfactura { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public bool esboleta { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public bool esncr { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public bool esndb { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         public bool fecharegistro { get; set; }

    }
}
