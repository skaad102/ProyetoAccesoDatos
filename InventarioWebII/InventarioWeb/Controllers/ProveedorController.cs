using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Controllers
{
    public class ProveedorController : Controller
    {
        public IProveedorRepository proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            this.proveedorRepository = proveedorRepository;
        }
        public IActionResult Index()
        {
            var lista = this.proveedorRepository.Proveedores.ToList();
            return View(lista);
        }
    }
}