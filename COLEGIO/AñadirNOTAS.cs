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


    public partial class AñadirNOTAS : Form
    {


        private MySqlConnection conexion;

        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;






        public AñadirNOTAS(MySqlConnection conexion)
        {
            InitializeComponent();

            this.conexion = conexion;

            // Asignar el evento KeyPress para validar las notas
            textBprimero.KeyPress += ValidarNota;
            textBsegundo.KeyPress += ValidarNota;
            textBtercero.KeyPress += ValidarNota;
            textBcuarto.KeyPress += ValidarNota;
            textBquinto.KeyPress += ValidarNota;
            textBsexto.KeyPress += ValidarNota;

        }


        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }



        private void AñadirNOTAS_Load(object sender, EventArgs e)
        {
            // Si el formulario se abre para modificar un registro, carga los datos 
            if (!string.IsNullOrEmpty(textBoxid.Text))
            {
                string id = textBoxid.Text;
                string primero = textBprimero.Text;
                string segundo = textBsegundo.Text;
                string tercero = textBtercero.Text;
                string cuarto = textBcuarto.Text;
                string quinto = textBquinto.Text;
                string sexto = textBsexto.Text;
                string asignaturas = comboBox1.Text;




               

            }
        }






        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            string id = textBoxid.Text;
            string asignatura = comboBox1.Text;
            string primero = textBprimero.Text;
            string segundo = textBsegundo.Text;
            string tercero = textBtercero.Text;
            string cuarto = textBcuarto.Text;
            string quinto = textBquinto.Text;
            string sexto = textBsexto.Text;

            // Verificar si algún campo está vacío
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(asignatura) || string.IsNullOrEmpty(primero) ||
                string.IsNullOrEmpty(segundo) || string.IsNullOrEmpty(tercero) || string.IsNullOrEmpty(cuarto) ||
                string.IsNullOrEmpty(quinto) || string.IsNullOrEmpty(sexto))
            {
                // Mostrar el mensaje de advertencia en el labelAdvertencia con letras rojas
                labelAdvertencia.ForeColor = Color.Red;
                labelAdvertencia.Text = "¡Por favor, completa todos los campos!";
            }
            else
            {
                try
                {
                    // Abre la conexión
                    conexion.Open();

                    // Verificar si el ID del alumno existe
                    string consultaExisteID = "SELECT COUNT(*) FROM alumnos WHERE id = @id";
                    MySqlCommand comandoExisteID = new MySqlCommand(consultaExisteID, conexion);
                    comandoExisteID.Parameters.AddWithValue("@id", id);
                    int cantidadAlumnos = Convert.ToInt32(comandoExisteID.ExecuteScalar());

                    if (cantidadAlumnos == 0)
                    {
                        // Si el ID del alumno no existe, mostrar un mensaje de advertencia
                        labelAdvertencia.ForeColor = Color.Red;
                        labelAdvertencia.Text = "¡El ID del alumno no existe!";
                    }
                    else
                    {
                        // Verificar si ya existe una nota para la asignatura seleccionada
                        string consultaExisteNota = "SELECT COUNT(*) FROM notas WHERE id = @id AND asignatura = @asignatura";
                        MySqlCommand comandoExisteNota = new MySqlCommand(consultaExisteNota, conexion);
                        comandoExisteNota.Parameters.AddWithValue("@id", id);
                        comandoExisteNota.Parameters.AddWithValue("@asignatura", asignatura);
                        int cantidadNotas = Convert.ToInt32(comandoExisteNota.ExecuteScalar());

                        if (cantidadNotas > 0)
                        {
                            // Si ya existe una nota para la asignatura seleccionada, mostrar un mensaje de advertencia
                            labelAdvertencia.ForeColor = Color.Red;
                            labelAdvertencia.Text = "¡El alumno ya tiene esa asignatura asignada!";
                        }
                        else
                        {
                            // Inicia una transacción
                            MySqlTransaction transaccion = conexion.BeginTransaction();

                            try
                            {
                                // Define la consulta SQL para insertar una nota
                                string consultaNota = "INSERT INTO notas (id, asignatura, 1Exm, 2Exm, 3Exm, 4Exm, 5Exm, 6Exm) VALUES (@id, @asignatura, @primero, @segundo, @tercero, @cuarto, @quinto, @sexto)";

                                // Crea un comando con la consulta y los parámetros
                                MySqlCommand comandoNota = new MySqlCommand(consultaNota, conexion);
                                comandoNota.Parameters.AddWithValue("@id", id);
                                comandoNota.Parameters.AddWithValue("@asignatura", asignatura);
                                comandoNota.Parameters.AddWithValue("@primero", primero);
                                comandoNota.Parameters.AddWithValue("@segundo", segundo);
                                comandoNota.Parameters.AddWithValue("@tercero", tercero);
                                comandoNota.Parameters.AddWithValue("@cuarto", cuarto);
                                comandoNota.Parameters.AddWithValue("@quinto", quinto);
                                comandoNota.Parameters.AddWithValue("@sexto", sexto);

                                // Ejecuta el comando para insertar la nota
                                comandoNota.ExecuteNonQuery();

                                // Confirma la transacción
                                transaccion.Commit();

                                // Muestra un mensaje de éxito
                                MessageBox.Show("Datos guardados correctamente");

                                // Después de ejecutar la consulta, activa el evento CambiosRealizados
                                OnCambiosRealizados();

                                // Cierra la ventana
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                // Si ocurre un error, hace un rollback de la transacción
                                transaccion.Rollback();
                                MessageBox.Show("Error al procesar los datos: " + ex.Message);
                            }
                            finally
                            {
                                // Asegúrate de cerrar la conexión en el bloque finally
                                conexion.Close();
                            }
                        }
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
        }
        




        private void butCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual de modificarNOTA
            this.Close();
        }

        private void labelAdvertencia_Click(object sender, EventArgs e)
        {

        }











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
