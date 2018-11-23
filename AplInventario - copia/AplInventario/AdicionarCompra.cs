using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplInventario
{
    public partial class AdicionarCompra : Form
    {
        public AdicionarCompra()
        {
            InitializeComponent();
        }

        private void BtnComprar_Click(object sender, EventArgs e)
        {
            Compras compras = new Compras()
            {
                CodigoProducto = Convert.ToInt32(txtBxCodigo.Text),
                CantidadCompras = Convert.ToInt32(txtBXCantidad.Text),
                CodigoProv = Convert.ToInt32(txtBxProv.Text),
                FechaCompar = DateTime.Now
            };
            try
            {
                if (Controlador.BuscarCompra(compras))
                {
                    if (Controlador.GuardarCompras(compras))
                    {
                        if (Controlador.ActualizarCompra(compras))
                        {
                            MessageBox.Show("Compra exitosa " );
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            
        }
    }
}
