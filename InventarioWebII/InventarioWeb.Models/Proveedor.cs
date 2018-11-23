using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioWeb.Models
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string nom_prov { get; set; }
        public string tel_prov { get; set; }
        public bool act_prov { get; set; }

        public IList<Compra> Proveedores { get; set; }
    }
}
