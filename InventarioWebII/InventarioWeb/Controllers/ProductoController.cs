using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Controllers
{
    public class ProductoController : Controller
    {
        public IProductoRepository ProductoRepository;

        public ProductoController(IProductoRepository ProductoRepository)
        {
            this.ProductoRepository = ProductoRepository;
        }

        public IActionResult Index()
        {
            var lista = this.ProductoRepository.Productos.ToList();
            return View(lista);
        }
    }
}