using InventarioWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioWeb.DataAccess
{
    public class CompraRepository : BaseRepository, ICompraRepository
    {
        public IQueryable<Compra> Compras => this.context.Compras;

        public CompraRepository(InventarioWebDBContext context) : base(context)
        {

        }
    }
}
