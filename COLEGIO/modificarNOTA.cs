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
    public partial class modificarNOTA : Form
    {

        private int ID;

        private MySqlConnection conexion;

        private MySqlCommand comando;

        private MySqlDataAdapter adaptador;

        private DataTable info;

        private DataTable datos;

        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;


        private ALUMNOS formAlumnos;  // ///////////

        private DataRow clienteSeleccionado; // Agregar un campo para almacenar el cliente seleccionado





        public modificarNOTA(MySqlConnection conexion, string asignatura, string primero, string segundo, string tercero,string cuarto, string quinto, string sexto)
        {

            InitializeComponent();
            this.conexion = conexion;
            this.formAlumnos = formAlumnos;
            

            // Llenar los campos del formulario con la información del cliente
           
            textBasignatura.Text = asignatura;
            textprimero.Text = primero;
            textsegundo.Text = segundo;
            texttercero.Text = tercero;
            textBcuarto.Text = cuarto;
            textBquinto.Text = quinto;
            textbsexto.Text = sexto;

            // Asignar el evento KeyPress para validar las notas
            textprimero.KeyPress += ValidarNota;
            textsegundo.KeyPress += ValidarNota;
            texttercero.KeyPress += ValidarNota;
            textBcuarto.KeyPress += ValidarNota;
            textBquinto.KeyPress += ValidarNota;
            textbsexto.KeyPress += ValidarNota;

        }







        private void modificarNOTA_Load(object sender, EventArgs e)
        {
            ////////////////////////////
        }





        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }



        //



        private void buttonguardar_Click(object sender, EventArgs e)
        {
            string primero = textprimero.Text;
            string segundo = textsegundo.Text;
            string tercero = texttercero.Text;
            string cuarto = textBcuarto.Text;
            string quinto = textBquinto.Text;
            string sexto = textbsexto.Text;

            try
            {
                // Abrir la conexión si no está abierta
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                // Actualizar los datos en la base de datos
                string consultaActualizarNotas = "UPDATE notas SET 1Exm = @1Exm, 2Exm = @2Exm, 3Exm = @3Exm, 4Exm = @4Exm, 5Exm = @5Exm, 6Exm = @6Exm WHERE asignatura = @asignatura";

                MySqlCommand comandoActualizarNotas = new MySqlCommand(consultaActualizarNotas, conexion);

                comandoActualizarNotas.Parameters.AddWithValue("@1Exm", primero);
                comandoActualizarNotas.Parameters.AddWithValue("@2Exm", segundo);
                comandoActualizarNotas.Parameters.AddWithValue("@3Exm", tercero);
                comandoActualizarNotas.Parameters.AddWithValue("@4Exm", cuarto);
                comandoActualizarNotas.Parameters.AddWithValue("@5Exm", quinto);
                comandoActualizarNotas.Parameters.AddWithValue("@6Exm", sexto);
                comandoActualizarNotas.Parameters.AddWithValue("@asignatura", textBasignatura.Text);

                comandoActualizarNotas.ExecuteNonQuery();



                MessageBox.Show("Datos actualizados correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar los datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            this.Close();
        }


       

        // /////////////////



        private void buttonCancelar_Click(object sender, EventArgs e)
        {
           
           
            // Cerrar la ventana actual de modificarNOTA
            this.Close();
        }

        // /////////////////




        // Método para validar que solo se ingresen números del 1 al 10 en las notas
        private void ValidarNota(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Verificar si la tecla presionada es un número o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, cancelar la entrada
                e.Handled = true;
            }
            else
            {
                // Si es un número, verificar si está dentro del rango del 0 al 10
                int nota;
                if (int.TryParse(textBox.Text + e.KeyChar, out nota) && (nota < 0 || nota > 10 || (nota == 0 && textBox.Text.Length > 0)))
                {
                    // Si la nota es menor que 0, mayor que 10 o igual a 0 y ya hay un 0 ingresado, cancelar la entrada
                    e.Handled = true;
                }
            }
        }






    }
}
