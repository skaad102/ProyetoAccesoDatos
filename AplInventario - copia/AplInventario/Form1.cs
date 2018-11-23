using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplInventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Controlador controlador = new Controlador();
            controlador.CargarDatosBd(dataGridView1);
            controlador.CargarDatosVt(dataGridView2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controlador controlador = new Controlador();
            AdicionarProductos ventana = new AdicionarProductos(this);
            ventana.ShowDialog();
            controlador.CargarDatosBd(dataGridView1);

            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //CargarInfo();
        }

        public void CargarInfo()
        {
            List<Productos> lista = CargarDatosProductos();

            this.dataGridView1.DataSource = lista;
        }


        public List<Productos> CargarDatosProductos()
        {
            List<Productos> lospd = new List<Productos>();

            string db = @"Server=SKAAD; Database=intentario_2; Trusted_Connection = True;";

            SqlConnection connection = new SqlConnection(db);

            try
            {
                connection.Open();

                string command = @"slect cod_id_producto,nombre_producto,val_producto from producto";

                SqlCommand sqlCommand = new SqlCommand(command, connection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    int productoId = sqlDataReader.GetInt32(0);
                    string nombreProducto = sqlDataReader.GetString(1);
                    double valor = sqlDataReader.GetDouble(2);

                    Productos producto = new Productos
                    {
                        CodigoProducto = productoId,
                        NombreProducto = nombreProducto,
                        ValorProducto = valor
                    };
                    lospd.Add(producto);
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return lospd;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controlador controlador = new Controlador();
            AdicionarCompra ventana = new AdicionarCompra();
            ventana.ShowDialog();
            controlador.CargarDatosBd(dataGridView1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Controlador controlador = new Controlador();
            AdicionarVenta adicionar = new AdicionarVenta(this);
            adicionar.ShowDialog();
            controlador.CargarDatosVt(dataGridView2);
            controlador.CargarDatosBd(dataGridView1);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
