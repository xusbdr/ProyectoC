using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MySql.Data.MySqlClient;





namespace COLEGIO
{
    public partial class Añadir : Form
    {


        private MySqlConnection conexion;

        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;





        public Añadir()
        {
            InitializeComponent();
            // Configura la conexión a tu base de datos MySQL para "seguros"
            string cadenaConexion = "server=127.0.0.1;user id=root;password=123456;database=colegio";
            conexion = new MySqlConnection(cadenaConexion);
        }





        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }







        private void Añadir_Load(object sender, EventArgs e)
        {
            // Si el formulario se abre para modificar un registro, carga los datos 
            if (!string.IsNullOrEmpty(textBoxdni.Text))
            {
                string dni = textBoxdni.Text;
                string nombre = textnombre.Text;
                string apellidos = textapellidos.Text;
                string telefono = texttelefono.Text;
                string ciudad = combociudad.Text;
                string provincia = combolocalidad.Text;

              
            }
        }



        //





        private void buttonguardar_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los campos del formulario
            string dni = textBoxdni.Text;
            string nombre = textnombre.Text;
            string apellidos = textapellidos.Text;
            string telefono = texttelefono.Text;
            
            string ciudad = combociudad.Text;
            string provincia= combolocalidad.Text;



            try
            {
                // Abre la conexión
                conexion.Open();

                // Validar que el campo dni no esté vacío
                if (!string.IsNullOrEmpty(dni))
                {
                    // Inicia una transacción
                    MySqlTransaction transaccion = conexion.BeginTransaction();

                    try
                    {
                        // Define la consulta SQL para insertar un cliente
                        string consultaCliente = "INSERT INTO alumnos (DNI, nombre, apellidos, telefono, ciudad, provincia) VALUES (@dni, @nombre, @apellidos, @telefono,@ciudad, @provincia)";

                        // Crea un comando con la consulta y los parámetros
                        MySqlCommand comandoCliente = new MySqlCommand(consultaCliente, conexion);
                        comandoCliente.Parameters.AddWithValue("@dni", dni);
                        comandoCliente.Parameters.AddWithValue("@nombre", nombre);
                        comandoCliente.Parameters.AddWithValue("@apellidos", apellidos);
                        comandoCliente.Parameters.AddWithValue("@telefono", telefono);
                        comandoCliente.Parameters.AddWithValue("@ciudad", ciudad);
                       
                        comandoCliente.Parameters.AddWithValue("@provincia", provincia);
                     

                        // Ejecuta el comando para insertar el cliente
                        comandoCliente.ExecuteNonQuery();

                        // Obtiene el ID del cliente recién insertado
                        int idCliente = (int)comandoCliente.LastInsertedId;


                        // Confirma la transacción
                        transaccion.Commit();

                        // Muestra un mensaje de éxito
                        MessageBox.Show("Datos guardados correctamente");

                        // Después de ejecutar la consulta, activa el evento CambiosRealizados
                        OnCambiosRealizados();
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, hace un rollback de la transacción
                        transaccion.Rollback();
                        MessageBox.Show("Error al procesar los datos: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("El campo DNI es obligatorio.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message);
            }
            finally
            {
                // Asegúrate de cerrar la conexión en el bloque finally
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        //



        private void label7_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////
        }

        //



        private void combociudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiar el ComboBox de provincias
            combolocalidad.Items.Clear();

            // Obtener la ciudad seleccionada
            string ciudadSeleccionada = combociudad.SelectedItem.ToString();

            try
            {
                // Abre la conexión
                conexion.Open();

                // Define la consulta SQL para obtener las provincias asociadas a la ciudad seleccionada
                string consultaProvincias = "SELECT * FROM ciudad WHERE ciudad = @ciudad";

                // Crea un comando con la consulta y los parámetros
                MySqlCommand comandoProvincias = new MySqlCommand(consultaProvincias, conexion);
                comandoProvincias.Parameters.AddWithValue("@ciudad", ciudadSeleccionada);

                // Ejecuta el comando para obtener la fila correspondiente a la ciudad seleccionada
                using (MySqlDataReader reader = comandoProvincias.ExecuteReader())
                {
                    // Verifica si se encontró la ciudad
                    if (reader.Read())
                    {
                        // Itera sobre las columnas a partir de la segunda, que contienen las provincias
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            // Agregar las provincias al ComboBox
                            combolocalidad.Items.Add(reader[i].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("La ciudad seleccionada no se encontró en la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las provincias: " + ex.Message);
            }
            finally
            {
                // Asegúrate de cerrar la conexión en el bloque finally
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual de modificarNOTA
            this.Close();
        }
    }
}
