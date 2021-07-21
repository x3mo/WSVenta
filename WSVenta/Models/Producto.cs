using System;
using System.Collections.Generic;

namespace WSVenta.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Concepto = new HashSet<Concepto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? PUnit { get; set; }
        public int? Costo { get; set; }

        public ICollection<Concepto> Concepto { get; set; }
    }
}
