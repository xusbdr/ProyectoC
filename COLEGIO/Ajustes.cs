using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Threading;
using System.Globalization;

using MySql.Data.MySqlClient;



namespace COLEGIO
{
    public partial class Ajustes : Form
    {

        private MySqlConnection conexion;

        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;

        

        public Ajustes()
        {
            InitializeComponent();
            // Configura la conexión a tu base de datos MySQL para "seguros"
            string cadenaConexion = "server=127.0.0.1;user id=root;password=123456;database=colegio";
            conexion = new MySqlConnection(cadenaConexion);
        }



        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Obtiene el valor de la asignatura seleccionada en el ComboBox
            string asignatura = comboBox1.Text;

            try
            {
                // Abre la conexión
                conexion.Open();

                // Validar que el campo asignatura no esté vacío
                if (!string.IsNullOrEmpty(asignatura))
                {
                    // Inicia una transacción
                    using (MySqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Define la consulta SQL para insertar una asignatura
                            string consultaAsignatura = "INSERT INTO asignaturasañadidas (asignatura) VALUES (@asignatura)";

                            // Crea un comando con la consulta y los parámetros
                            using (MySqlCommand comandoAsignatura = new MySqlCommand(consultaAsignatura, conexion))
                            {
                                comandoAsignatura.Parameters.AddWithValue("@asignatura", asignatura);

                                // Ejecuta el comando para insertar la asignatura
                                comandoAsignatura.ExecuteNonQuery();
                            }

                            // Confirma la transacción
                            transaccion.Commit();

                            // Muestra un mensaje de éxito
                            MessageBox.Show("Asignatura guardada correctamente");

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
                }
                else
                {
                    MessageBox.Show("El campo de asignatura es obligatorio.");
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




        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }





        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual de modificarNOTA
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //////
        }









       

    }
    }

