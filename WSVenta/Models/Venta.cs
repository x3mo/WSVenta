using System;
using System.Collections.Generic;

namespace WSVenta.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Concepto = new HashSet<Concepto>();
        }

        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? Total { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public ICollection<Concepto> Concepto { get; set; }
    }
}
