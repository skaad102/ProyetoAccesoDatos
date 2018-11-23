using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioWeb.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int cantidad_prodictos { get; set; }
        public double total_venta { get; set; }
        public DateTime fecha_venta { get; set; }

    }
}
