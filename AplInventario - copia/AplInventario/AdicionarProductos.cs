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
    public partial class AdicionarProductos : Form
    {
        private Form1 Padre { get; set; }
        public AdicionarProductos(Form1 formulario)
        {
            Padre = formulario;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            
            try
            {

                Productos producto = new Productos()
                {

                    NombreProducto = txtBXNombre.Text,
                    ValorProducto = Convert.ToDouble(txtBXValor.Text)
                };
                //var Existe = Controlador.ExisteProducto(producto);

                //if (Existe)
                //{
                //    txtBxCodigo.Text = "";
                //    txtBXNombre.Text = "";
                //    txtBXValor.Text = "";
                //    producto.CodigoProducto = txtBxCodigo.Text;
                //    producto.NombreProducto = txtBXNombre.Text;
                //    producto.ValorProducto = txtBXValor.Text;
                //    MessageBox.Show("No Se guardaron los datos", "Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
                if (Controlador.ExisteProducto(producto))
                {
                    if (Controlador.Guardar(producto))
                    {
                        if (Controlador.ActualizarProdocto())
                        {
                            MessageBox.Show("Se guardaron los datos", "Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBXNombre.Text = "";
                            txtBXValor.Text = "";
                        }

                    }
                }

                
                else
                {
                    MessageBox.Show("Vuelve a untentarlo", "Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex )
            {
                MessageBox.Show("Ocurrió un error " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }
    }
}
