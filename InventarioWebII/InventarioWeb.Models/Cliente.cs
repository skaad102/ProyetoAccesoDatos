    using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioWeb.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string num_cli { get; set; }
        public string nombre_cli { get; set; }
        public string tel_cli { get; set; }
        public string dir_cli { get; set; }

        public IList<Venta> Ventas { get; set; }
    }
}
