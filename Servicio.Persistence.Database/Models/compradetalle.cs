using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class compradetalle
    {
        public int compradetalleid { get; set; }
        public decimal cantidad { get; set; }
        public decimal valorunitario { get; set; }
        public decimal valor { get; set; }
        public decimal igv { get; set; }
        public decimal precio { get; set; }
        public int? productoid { get; set; }
        public int? compraid { get; set; }

        public virtual compra compra { get; set; }
        public virtual producto producto { get; set; }
    }
}
