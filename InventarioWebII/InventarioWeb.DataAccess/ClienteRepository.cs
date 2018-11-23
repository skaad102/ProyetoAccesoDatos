using InventarioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioWeb.DataAccess
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public IQueryable<Cliente> Clientes => this.context.Clientes;

        public ClienteRepository(InventarioWebDBContext context) : base(context)
        {

        }
    }
}
