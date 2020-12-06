using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class venta
    {
        public venta()
        {
            ventadetalle = new HashSet<ventadetalle>();
        }

        public int ventaid { get; set; }
        public int? clienteid { get; set; }
        public DateTime fechaemision { get; set; }
        public string serie { get; set; }
        public long correlativo { get; set; }
        public decimal baseimponible { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }
        public DateTime? fecharegistro { get; set; }
        public int? documentoid { get; set; }

        public virtual cliente cliente { get; set; }
        public virtual documento documento { get; set; }
        public virtual ICollection<ventadetalle> ventadetalle { get; set; }
    }
}
