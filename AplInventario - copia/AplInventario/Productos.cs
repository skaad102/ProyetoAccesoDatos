using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplInventario
{
    public class Productos
    {
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public double ValorProducto { get; set; }


        public override string ToString()
        {
            return $"{CodigoProducto};{NombreProducto};{ValorProducto}";
        }
    }
}
