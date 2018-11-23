using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplInventario
{
    public partial class Controlador 
    {
        //const string ARCHIVOPRODUCTOS = @"C:\datos\prosdustos.txt";
        const string ARCHIVOVENTAS = @"C:\datos\ventas.txt";
        const string ARCHIVOCOMPRAS = @"C:\datos\compras.txt";

        

        public static bool Guardar(Productos productos)
        {
            //FileInfo file = new FileInfo(ARCHIVOPRODUCTOS);

            //try
            //{
            //    if (!file.Exists)
            //    {
            //        using (StreamWriter writer = file.CreateText())
            //        {
            //        writer.WriteLine(productos.ToString());
            //            return true;
            //        }
            //    }
            //    else
            //    {
            //        using (StreamWriter writer = file.AppendText())
            //        {
            //        writer.WriteLine(productos.ToString());
            //            return true;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //1. Creamos el objeto que permite la conneccion
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection=True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conexion
                coneccion.Open();

                //3. Contruimos el (seles insert delete update)
                string sql = @"INSERT INTO Productos(nombre_producto,val_producto,total_producto)
                        VALUES(@nombre_producto,@val_producto,@total_producto)";


                //string sqlCompl = @"select MAX(id_producto) from producto";

                //4. creamos un comando para enciar sentencas a la BD

                //int num = 0;
                    SqlCommand command = new SqlCommand(sql, coneccion);


                //5. definimos los parametros de la consulta
                command.Parameters.AddWithValue("@nombre_producto", productos.NombreProducto);
                command.Parameters.AddWithValue("@val_producto", Convert.ToDouble(productos.ValorProducto));
                command.Parameters.AddWithValue("@total_producto", 0);

                //6. ejecutamos el comado 

                int filasAfectadas = command.ExecuteNonQuery();
                if(filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Encontramos un erro D:");
                    return false;
                }
             
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
                return false;
            }
            finally
            {
                if (coneccion.State != ConnectionState.Closed)
                {
                    coneccion.Close();
                }
            }
        }

        internal static bool ActualizarCompraProducto(Ventas ventas)
        {
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection=True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conexion
                coneccion.Open();

                //3. Contruimos el (seles insert delete update)


                string sqlUpTotal = @"DECLARE @IdLast int = (SELECT MAX(VentaId) FROM Ventas)			
                                        UPDATE Ventas
                                        set total_venta = cantidad_prodictos * val_producto 
                                        from Ventas inner join Productos on Productos.ProductoID =Ventas.ProductoId WHERE VentaId = @IdLast


                                        DECLARE @IdLastVt int = (SELECT MAX(VentaId) FROM Ventas)
									        Update Productos
										    set total_producto = total_producto - cantidad_prodictos
										    from Productos inner join Ventas on Ventas.ProductoId = Productos.ProductoID where VentaId = @IdLastVt";

               
                //4. creamos un comando para enciar sentencas a la BD


                SqlCommand command = new SqlCommand(sqlUpTotal, coneccion);

                //5. definimos los parametros de la consulta


                //6. ejecutamos el comado 

                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Encontramos un erro D:");
                    return false;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
                return false;
            }
            finally
            {
                if (coneccion.State != ConnectionState.Closed)
                {
                    coneccion.Close();
                }
            }
        }

        internal static bool ActualizarProdocto()
        {
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection=True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conexion
                coneccion.Open();

                //3. Contruimos el (seles insert delete update)
                string sql = @"DECLARE @Id int = (SELECT MAX(CompraId)FROM Compras)
                                        UPDATE Productos
                                        set total_producto =  total_producto + cant_compra
                                        from Productos inner join Compras on Productos.ProductoID = Compras.ProductoId where CompraId = @id";

                SqlCommand command = new SqlCommand(sql, coneccion);


                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Encontramos un erro D:");
                    return false;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
                return false;
            }
            finally
            {
                if (coneccion.State != ConnectionState.Closed)
                {
                    coneccion.Close();
                }
            }
        }

        internal void CargarDatosVt(DataGridView dataGridView2)
        {
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection=True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                coneccion.Open();
                string sql = @"select * from Ventas";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, db);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha encontrado un error ({ex.Message})");
            }
        }

        internal static bool ExisteProducto(Productos producto)
        {
            //StreamReader lectura = File.OpenText(@"C:\datos\prosdustos.txt");
            //string cadena, codigo;
            //bool encontrado = false;
            //string[] campos = new string[3];

            //codigo = producto.CodigoProducto;
            //cadena = lectura.ReadLine();
            //while (cadena != null && encontrado == false)
            //{
            //    campos = cadena.Split(';');
            //    //se obtine el arrego partido
            //    if (campos[0].Trim().Equals(codigo))
            //    {
            //        MessageBox.Show("Producto " + codigo + " ya exixte ");
            //        encontrado = true;
            //        return true;
            //    }
            //    else
            //    {
            //        cadena = lectura.ReadLine();
            //    }
            //}

            //lectura.Close();
            //return false;

            //1. creamos el ob que permite la conneccion
            string db = @"Server=SKAAD; Database=InventarioProyecto; Trusted_Connection = True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conneccion
                coneccion.Open();

                //3. construimos el selec delet
                string sql = @"select * from Productos where ProductoID = @ProductoID";


                //4. creamos un comado para iniciar la sentencia
                SqlCommand command = new SqlCommand(sql, coneccion);


                //5. definir los parametros del command
                command.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(producto.CodigoProducto));

                SqlDataReader leer = command.ExecuteReader();
                if (leer.Read()== true)
                {
                    MessageBox.Show("Ya hay un producto con ese codigo");
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha encontrado un error ({ex.Message})");
                return false;
            }


        }

        public void CargarDatosBd(DataGridView dataGridView)
        {

            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection=True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                coneccion.Open();
                string sql = @"select * from Productos";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, db);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha encontrado un error ({ex.Message})");
            }
        }

        internal static bool BuscarVentas(Ventas ventas)
        {
            //int foundValue = -1;
            //StreamReader lectura = File.OpenText(@"C:\datos\prosdustos.txt");
            //string cadena, codigo;
            //bool encontrado = false;
            //string[] campos = new string[3];

            //codigo = ventas.CodigoProducto;
            //cadena = lectura.ReadLine();
            //while (cadena != null && encontrado == false)
            //{
            //    campos = cadena.Split(';');
            //    //se obtine el arrego partido
            //    if (campos[0].Trim().Equals(codigo))
            //    {
            //        foundValue = Convert.ToInt32(campos[2]);
            //        encontrado = true;
            //        return foundValue;
            //    }
            //    else
            //    {
            //        cadena = lectura.ReadLine();
            //    }
            //}
            //if (encontrado == false)
            //{

            //    MessageBox.Show("Producto " + codigo + " no fue encontrado");

            //}

            //lectura.Close();
            //return -1;

            //1. creamos el ob que permite la conneccion
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection = True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conneccion
                coneccion.Open();

                //3. construimos el selec delet
                string sql = @"select * from Productos where ProductoID = @ProductoID";

                //4. creamos un comado para iniciar la sentencia
                SqlCommand command = new SqlCommand(sql, coneccion);


                //5. definir los parametros del command
                command.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(ventas.CodigoProducto));

                SqlDataReader leer = command.ExecuteReader();
                if (leer.Read() == true)
                {
                    return true;

                }
                else
                {
                    
                    MessageBox.Show("No hay un producto con ese codigo");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha encontrado un error ({ex.Message})");
                return false;
            }

        }

        internal static bool GuardarVenta(Ventas ventas)
        {
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection=True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conexion
                coneccion.Open();

                //3. Contruimos el (seles insert delete update)

                    //string sqlCompl = @"select MAX(VentaId) from Ventas";
                    string sql = @"INSERT INTO Ventas(ClienteId,ProductoId,fecha_venta,cantidad_prodictos)
                        VALUES(@ClienteId,@ProductoId,@fecha_venta,@cantidad_prodictos)";

                    //4. creamos un comando para enciar sentencas a la BD
                    //SqlCommand command_comple = new SqlCommand(sqlCompl, coneccion);
                    SqlCommand command = new SqlCommand(sql, coneccion);



                    //int num = 0;

                    //object data = command_comple.ExecuteScalar();

                    //if (data is DBNull)
                    //{
                    //    num = 1;
                    //}
                    //else
                    //{
                    //    num = Convert.ToInt32(data) + 1;
                    //}

                    //5. definimos los parametros de la consulta
                    command.Parameters.AddWithValue("@ClienteId", ventas.ClaveCliente);
                    command.Parameters.AddWithValue("@ProductoId", ventas.CodigoProducto);
                    command.Parameters.AddWithValue("@fecha_venta", ventas.fechaVenta);
                    command.Parameters.AddWithValue("@cantidad_prodictos", ventas.CantidadVntas);


                    //6. ejecutamos el comado 

                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        return true;   
                    }else{
                            MessageBox.Show("Encontramos un erro D:");
                            return false;
                        }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
                 return false;
            }
            finally
            {
                if (coneccion.State != ConnectionState.Closed)
                {
                    coneccion.Close();
                }
            }   
        }

        public static bool ActualizarCompra(Compras compras)
        {
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection=True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conexion
                coneccion.Open();

                //3. Contruimos el (seles insert delete update)
                string sqlUpTotal = @"DECLARE @Id int = (SELECT MAX(CompraId)FROM Compras)
                                        UPDATE Productos
                                        set total_producto =  total_producto + cant_compra
                                        from Productos inner join Compras on Productos.ProductoID = Compras.ProductoId where CompraId = @id";


                //4. creamos un comando para enciar sentencas a la BD


                SqlCommand command = new SqlCommand(sqlUpTotal, coneccion);
                
                //5. definimos los parametros de la consulta


                //6. ejecutamos el comado 

                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Encontramos un erro D:");
                    return false;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
                return false;
            }
            finally
            {
                if (coneccion.State != ConnectionState.Closed)
                {
                    coneccion.Close();
                }
            }
        }

        public static bool GuardarCompras(Compras compras)
        {
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection = True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conexion
                coneccion.Open();

                //3. Contruimos el (seles insert delete update)
                  string sql = @"INSERT INTO Compras(ProductoId,ProveedorId,cant_compra,fecha_compra)
                         VALUES(@ProductoId,@ProveedorId,@cant_compra,@fecha_compra)";




                //4. creamos un comando para enciar sentencas a la BD
                    SqlCommand command = new SqlCommand(sql, coneccion);

               

                //5. definimos los parametros de la consulta
                command.Parameters.AddWithValue("@ProductoId", compras.CodigoProducto);
                command.Parameters.AddWithValue("@ProveedorId", compras.CodigoProv);
                command.Parameters.AddWithValue("@cant_compra", compras.CantidadCompras);
                command.Parameters.AddWithValue("@fecha_compra", compras.FechaCompar);

                //6. ejecutamos el comado 

                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Encontramos un erro D:");
                    return false;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
                return false;
            }
            finally
            {
                if (coneccion.State != ConnectionState.Closed)
                {
                    coneccion.Close();
                }
            }
        }

        public static bool BuscarCompra(Compras compras)
        {
            //1. creamos el ob que permite la conneccion
            string db = @"Server=SKAAD; Database=InventarioProyectoII; Trusted_Connection = True;";
            SqlConnection coneccion = new SqlConnection(db);
            try
            {
                //2. abrimos la conneccion
                coneccion.Open();

                //3. construimos el selec delet
                string sql = @"select * from Productos where ProductoID = @ProductoID";

                //4. creamos un comado para iniciar la sentencia
                SqlCommand command = new SqlCommand(sql, coneccion);


                //5. definir los parametros del command
                command.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(compras.CodigoProducto));

                SqlDataReader leer = command.ExecuteReader();
                if (leer.Read() == true)
                {
                    return true;

                }
                else
                {

                    MessageBox.Show("No hay un producto con ese codigo");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha encontrado un error ({ex.Message})");
                return false;
            }
        }

    }
}
