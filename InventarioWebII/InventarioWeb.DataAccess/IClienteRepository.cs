using InventarioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioWeb.DataAccess
{
    public interface IClienteRepository
    {
        IQueryable<Cliente> Clientes { get; }
    }
}
