using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Servicio.Services.Commands.Requests.Venta
{
    public class VentaDetalle
    {
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
        public int? productoid { get; set; }
    }

    public class InsertarVentaCommand : IRequest<int>
    {
        public InsertarVentaCommand()
        {
            Detalles = new List<VentaDetalle>();
        }

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

        [Range(0, int.MaxValue)]
        public int? documentoid { get; set; }

        [Required]
        public List<VentaDetalle> Detalles { get; set; }
    }
}
