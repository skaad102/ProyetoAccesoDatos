using InventarioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioWeb.DataAccess
{
    public class ProveedorRepository : BaseRepository , IProveedorRepository
    {
        public IQueryable<Proveedor> Proveedores => this.context.Proveedores;

        public ProveedorRepository(InventarioWebDBContext context) : base(context)
        {
        }
    }
}
