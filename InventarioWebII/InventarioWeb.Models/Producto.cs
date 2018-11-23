using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioWeb.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string nombre_producto { get; set; }
        public double val_producto { get; set; }
        public int total_producto { get; set; }

        public IList<Venta> ventas { get; set; }
        public IList<Compra> compras { get; set; }
    }
}
