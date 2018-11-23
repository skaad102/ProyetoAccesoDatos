using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Controllers
{
    public class CompraController : Controller
    {
        public ICompraRepository CompraRepository;

        public CompraController(ICompraRepository compraRepository)
        {
            this.CompraRepository = compraRepository;
        }

        public IActionResult Index()
        {
            var lista = this.CompraRepository.Compras.ToList();
            return View(lista);
        }
    }
}