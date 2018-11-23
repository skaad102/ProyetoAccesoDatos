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
    public partial class AdicionarVenta : Form
    {
        private Form1 Padre { get; set; }

        public AdicionarVenta(Form1 formulario)
        {
            Padre = formulario;
            InitializeComponent();
        }

        private void BtnVanta_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas()
            {
                CodigoProducto = Convert.ToInt32(txtBxCodigo.Text),
                CantidadVntas = Convert.ToInt32(txtBxCantidad.Text),
                ClaveCliente = Convert.ToInt32(txtBoxUsuario.Text),
                fechaVenta = DateTime.Now,


            };

            try
            {            
                if (Controlador.BuscarVentas (ventas))
                {
                    if (Controlador.GuardarVenta(ventas))
                    {
                        if (Controlador.ActualizarCompraProducto(ventas))
                        {
                            MessageBox.Show("Venta Exitosa :D");
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
           
        }
    }
}
