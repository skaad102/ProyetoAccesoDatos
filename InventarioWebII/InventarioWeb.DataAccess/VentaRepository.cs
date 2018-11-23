using InventarioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace InventarioWeb.DataAccess
{
    public class VentaRepository : BaseRepository , IVentaRepository
    {
        public IQueryable<Venta> Ventas => this.context.Ventas;

        public VentaRepository(InventarioWebDBContext context) : base(context)
        {
        }
    }
}
