using InventarioWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioWeb.DataAccess
{
    public class InventarioWebDBContext : DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public InventarioWebDBContext(DbContextOptions<InventarioWebDBContext> options) : base(options)
        {

        }

        //public InventarioWebDBContext()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=intentarioWeb.db");
        //}
    }
}
