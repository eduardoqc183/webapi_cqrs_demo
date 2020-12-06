using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class proveedor
    {
        public proveedor()
        {
            compra = new HashSet<compra>();
        }

        public int proveedorid { get; set; }
        public string nrodocidentidad { get; set; }
        public string nombrerazonsocial { get; set; }
        public string direccionjuridica { get; set; }
        public DateTime? fecharegistro { get; set; }

        public virtual ICollection<compra> compra { get; set; }
    }
}
