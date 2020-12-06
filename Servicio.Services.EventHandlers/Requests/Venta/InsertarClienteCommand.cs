using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;

namespace Servicio.Services.Commands.Requests.Venta
{
    public class InsertarClienteCommand :  IRequest<int>
    {
        [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string nrodocidentidad { get; set; }

        [Required(ErrorMessage = "Campo requerido", AllowEmptyStrings = false)]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string nombrerazonsocial { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        public string direccionjuridica { get; set; }
    }
}
