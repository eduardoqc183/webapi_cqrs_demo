using System;
using System.ComponentModel.DataAnnotations;

namespace Servicio.Services.Queries
{
    public partial class proveedorDto
    {
         public int proveedorid { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
         public string nrodocidentidad { get; set; }

         [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
         [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
         public string nombrerazonsocial { get; set; }

         [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
         public string direccionjuridica { get; set; }

         [DataType(DataType.Date)]
         public DateTime? fecharegistro { get; set; }

    }
}
