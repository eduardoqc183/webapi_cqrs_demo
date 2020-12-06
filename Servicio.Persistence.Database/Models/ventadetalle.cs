using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class ventadetalle
    {
        public int ventadetalleid { get; set; }
        public decimal cantidad { get; set; }
        public decimal valorunitario { get; set; }
        public decimal valor { get; set; }
        public decimal igv { get; set; }
        public decimal precio { get; set; }
        public int? ventaid { get; set; }
        public int? productoid { get; set; }

        public virtual producto producto { get; set; }
        public virtual venta venta { get; set; }
    }
}
