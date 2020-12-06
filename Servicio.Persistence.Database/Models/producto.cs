using System;
using System.Collections.Generic;

namespace Servicio.Persistence.Database.Models
{
    public partial class producto
    {
        public producto()
        {
            compradetalle = new HashSet<compradetalle>();
            ventadetalle = new HashSet<ventadetalle>();
        }

        public int productoid { get; set; }
        public string codproducto { get; set; }
        public string nombreproducto { get; set; }
        public decimal valorunitario { get; set; }
        public int unidadmedidaid { get; set; }
        public DateTime? fecharegistro { get; set; }

        public virtual ICollection<compradetalle> compradetalle { get; set; }
        public virtual ICollection<ventadetalle> ventadetalle { get; set; }
    }
}
