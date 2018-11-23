using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Controllers
{
    public class VentaController : Controller
    {
        public IVentaRepository VentaRepository;

        public VentaController(IVentaRepository ventaRepository)
        {
            this.VentaRepository = ventaRepository;
        }

        public IActionResult Index()
        {
            var lista = this.VentaRepository.Ventas.ToList();
            return View(lista);
        }
    }
}