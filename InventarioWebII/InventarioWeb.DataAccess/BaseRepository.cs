using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioWeb.DataAccess
{
    public class BaseRepository
    {
        public InventarioWebDBContext context;

        public BaseRepository(InventarioWebDBContext context)
        {
            this.context = context;
        }
    }

}
