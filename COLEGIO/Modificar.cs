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
    public partial class Modificar : Form
    {




        private MySqlConnection conexion;

        private MySqlCommand comando;

        private MySqlDataAdapter adaptador;

        private DataTable info;

        private DataTable datos;

        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;









        public Modificar(MySqlConnection conexion, string dni, string nombre, string apellidos, string telefono, string ciudad,  string provincia)
        {
            InitializeComponent();
            this.conexion = conexion;



            // Llenar los campos del formulario con la información del cliente
            textBoxdni.Text = dni;
           textnombre.Text = nombre;
            textapellidos.Text = apellidos;
            texttelefono.Text = telefono;
            combociudad.Text = ciudad;      
            combolocalidad.Text = provincia;
           
        }








        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }

        //



        private void buttonguardar_Click(object sender, EventArgs e)
        {

            string dni = textBoxdni.Text;
            string nombre = textnombre.Text;
            string apellidos = textapellidos.Text;
            string telefono = texttelefono.Text;
            string ciudad = combociudad.Text;
           
            string provincia = combolocalidad.Text;
          

            try
            {
                // Abrir la conexión
                conexion.Open();

                // Actualizar los datos del cliente en la base de datos
                string consultaActualizarCliente = "UPDATE alumnos SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono, ciudad = @ciudad, Provincia = @provincia WHERE DNI = @dni";

                MySqlCommand comandoActualizarCliente = new MySqlCommand(consultaActualizarCliente, conexion);
                comandoActualizarCliente.Parameters.AddWithValue("@nombre", nombre);
                comandoActualizarCliente.Parameters.AddWithValue("@apellidos", apellidos);
                comandoActualizarCliente.Parameters.AddWithValue("@telefono", telefono);
                comandoActualizarCliente.Parameters.AddWithValue("@ciudad", ciudad);
               
                comandoActualizarCliente.Parameters.AddWithValue("@provincia", provincia);
               
                comandoActualizarCliente.Parameters.AddWithValue("@dni", dni);

                comandoActualizarCliente.ExecuteNonQuery();

                MessageBox.Show("Datos actualizados correctamente");

                // Activar el evento CambiosRealizados
                OnCambiosRealizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar los datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
