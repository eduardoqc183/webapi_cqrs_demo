using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class ObtenerVentasView_1
    {
        public string nrodocidentidad { get; set; }
        public string nombrerazonsocial { get; set; }
        public string direccionjuridica { get; set; }
        public DateTime? fechaemision { get; set; }
        public string serie { get; set; }
        public long? correlativo { get; set; }
        public decimal? baseimponible { get; set; }
        public decimal? igv { get; set; }
        public decimal? total { get; set; }
    }
}
