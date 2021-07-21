using System;
using System.Collections.Generic;

namespace WSVenta.Models
{
    public partial class Concepto
    {
        public int Id { get; set; }
        public int? IdVenta { get; set; }
        public int? Cant { get; set; }
        public int? PUnit { get; set; }
        public int? Importe { get; set; }
        public int? IdProd { get; set; }

        public Producto IdProdNavigation { get; set; }
        public Venta IdVentaNavigation { get; set; }
    }
}
