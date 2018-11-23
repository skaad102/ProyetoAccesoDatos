using InventarioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioWeb.DataAccess
{
    public class ProductoRepository : BaseRepository , IProductoRepository
    {
        public IQueryable<Producto> Productos => this.context.Productos;

        public ProductoRepository(InventarioWebDBContext context) : base(context)
        {
        }
    }
}
