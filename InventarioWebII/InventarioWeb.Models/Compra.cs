using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioWeb.Models
{
    public class Compra
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public int cant_compra { get; set; }
        public DateTime fecha_compra { get; set; }

    }
}
