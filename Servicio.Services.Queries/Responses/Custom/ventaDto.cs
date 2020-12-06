using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Services.Queries
{
    public partial class ventaDto
    {
        public ventaDto()
        {
            Detalles = new List<ventadetalleDto>();
        }

        public string ClienteDireccion { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteNroDoc { get; set; }
        public List<ventadetalleDto> Detalles { get; set; }
    }
}
