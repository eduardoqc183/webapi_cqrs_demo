using System;

namespace Servicio.Services.Queries.Responses.Custom
{
    public partial class ConsultaVenta
    {
        public string TipoDoc { get; set; }
        public string Serie { get; set; }
        public long Correlativo { get; set; }
        public string Cliente { get; set; }
        public string NroDocCliente { get; set; }
        public DateTimeOffset FechaEmision { get; set; }
    }
}
