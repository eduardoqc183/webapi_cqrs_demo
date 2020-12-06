using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class compra
    {
        public compra()
        {
            compradetalle = new HashSet<compradetalle>();
        }

        public int compraid { get; set; }
        public int? proveedorid { get; set; }
        public DateTime fechaemision { get; set; }
        public string serie { get; set; }
        public long correlativo { get; set; }
        public decimal baseimponible { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }
        public DateTime? fecharegistro { get; set; }
        public int? documentoid { get; set; }

        public virtual documento documento { get; set; }
        public virtual proveedor proveedor { get; set; }
        public virtual ICollection<compradetalle> compradetalle { get; set; }
    }
}
