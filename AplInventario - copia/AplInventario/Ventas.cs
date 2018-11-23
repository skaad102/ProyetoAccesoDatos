using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplInventario
{
    public class Ventas
    {
        public int CodigoProducto { get; set; }
        public int ClaveCliente { get; set; }
        public int CantidadVntas { get; set; }
        public DateTime fechaVenta { get; set; }


    }
}
