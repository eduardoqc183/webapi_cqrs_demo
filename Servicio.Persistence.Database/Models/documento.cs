using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class documento
    {
        public documento()
        {
            compra = new HashSet<compra>();
            venta = new HashSet<venta>();
        }

        public int documentoid { get; set; }
        public string siglas { get; set; }
        public string descripcion { get; set; }
        public bool esfactura { get; set; }
        public bool esboleta { get; set; }
        public bool esncr { get; set; }
        public bool esndb { get; set; }
        public bool fecharegistro { get; set; }

        public virtual ICollection<compra> compra { get; set; }
        public virtual ICollection<venta> venta { get; set; }
    }
}
