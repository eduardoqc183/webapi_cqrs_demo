using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class cliente
    {
        public cliente()
        {
            venta = new HashSet<venta>();
        }

        public int clienteid { get; set; }
        public string nrodocidentidad { get; set; }
        public string nombrerazonsocial { get; set; }
        public string direccionjuridica { get; set; }
        public DateTime? fecharegistro { get; set; }

        public virtual ICollection<venta> venta { get; set; }
    }
}
