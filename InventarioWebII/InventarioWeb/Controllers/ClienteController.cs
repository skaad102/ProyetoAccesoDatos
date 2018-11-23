using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Controllers
{
    public class ClienteController : Controller
    {
        public IClienteRepository ClienteRepository;

        public ClienteController(IClienteRepository ClienteRepository)
        {
            this.ClienteRepository = ClienteRepository;
        }
        public IActionResult Index()
        {
            var lista = this.ClienteRepository.Clientes.ToList();
            return View(lista);
        }
    }
}