using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; //




namespace COLEGIO
{
    public partial class ALUMNOS : Form
    {
        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;
        private DataTable datos;
        private DataTable datos3;

        public ALUMNOS(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            dataGridINFORMACION.CellContentClick += dataGridVisualizar_CellContentClick;

        }



        // //////////////////////



        private void ALUMNOS_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "server=127.0.0.1;user id=root;password=123456;database=colegio";
            conexion = new MySqlConnection(cadenaConexion);
            string consulta = "SELECT * FROM alumnos";

            try
            {
                conexion.Open();
                adaptador = new MySqlDataAdapter(consulta, conexion);
                datos = new DataTable();
                adaptador.Fill(datos);
                dataGridALUMNOS.DataSource = datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        // /////////////////



        private void buttonAÑADIR_Click(object sender, EventArgs e)
        {
            Añadir añadir = new Añadir();
            añadir.CambiosRealizados += Añadir_CambiosRealizados;
            añadir.ShowDialog();
        }



        // //////////////////



        private void buttonMODIFICAR_Click(object sender, EventArgs e)
        {
            if (dataGridALUMNOS.SelectedRows.Count > 0)
            {
                string dni = dataGridALUMNOS.SelectedRows[0].Cells["dni"].Value.ToString();
                string nombre = dataGridALUMNOS.SelectedRows[0].Cells["nombre"].Value.ToString();
                string apellidos = dataGridALUMNOS.SelectedRows[0].Cells["apellidos"].Value.ToString();
                string telefono = dataGridALUMNOS.SelectedRows[0].Cells["telefono"].Value.ToString();
                string ciudad = dataGridALUMNOS.SelectedRows[0].Cells["ciudad"].Value.ToString();
                string localidad = dataGridALUMNOS.SelectedRows[0].Cells["provincia"].Value.ToString();

                Modificar modificarForm = new Modificar(conexion, dni, nombre, apellidos, telefono, ciudad, localidad);
                modificarForm.CambiosRealizados += Añadir_CambiosRealizados;
                modificarForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de modificar");
            }
        }




        // //////////////////////




        private void buttonBORRAR_Click(object sender, EventArgs e)
        {
            if (dataGridALUMNOS.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar este registro?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    object idObject = dataGridALUMNOS.SelectedRows[0].Cells["ID"].Value;

                    if (idObject != null && int.TryParse(idObject.ToString(), out int id))
                    {
                        try
                        {
                            if (conexion.State == ConnectionState.Closed)
                            {
                                conexion.Open();
                            }

                            string consultaBorrar = "DELETE FROM alumnos WHERE ID = @id";
                            comando = new MySqlCommand(consultaBorrar, conexion);
                            comando.Parameters.AddWithValue("@id", id);
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Registro eliminado correctamente");

                            RefreshDataGridView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al borrar el registro: " + ex.Message);
                        }
                        finally
                        {
                            if (conexion.State == ConnectionState.Open)
                            {
                                conexion.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor en la columna 'ID' no es un número válido.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de borrar");
            }
        }



        // ///////////////////



        private void Añadir_CambiosRealizados(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            datos.Clear();
            adaptador.Fill(datos);
            dataGridALUMNOS.DataSource = datos;
        }

       


        // //////////////////////////////////



        // Método invocado cuando se hace clic en una celda del DataGridView para mostrar más información
        private void dataGridVisualizar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridALUMNOS.Rows[e.RowIndex];
                DataRow clienteSeleccionado = ((DataRowView)row.DataBoundItem).Row;
                MostrarClienteSeleccionado(clienteSeleccionado);
            }
        }

       

       
        /// //////////////
       


        private void buttonFICHA_Click(object sender, EventArgs e)
        {
            if (dataGridALUMNOS.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridALUMNOS.SelectedRows[0];
                DataRow clienteSeleccionado = ((DataRowView)selectedRow.DataBoundItem).Row;
                MostrarClienteSeleccionado(clienteSeleccionado);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente primero.");
            }
        }



        // ////////////////////////////////////////////////////



        // Método para calcular la nota media por asignatura de un alumno dado su ID
        private Dictionary<string, double> CalcularNotaMediaPorAsignatura(string id)
        {
            Dictionary<string, Tuple<double, int>> notasSumadas = new Dictionary<string, Tuple<double, int>>();

            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string consultaNotas = "SELECT asignatura, 1Exm, 2Exm, 3Exm, 4Exm, 5Exm, 6Exm " +
                                       "FROM notas " +
                                       "WHERE id = @id";


                adaptador = new MySqlDataAdapter(consultaNotas, conexion);
                adaptador.SelectCommand.Parameters.AddWithValue("@id", id);

                DataTable tablaNotas = new DataTable();
                adaptador.Fill(tablaNotas);

                foreach (DataRow row in tablaNotas.Rows)
                {
                    string asignatura = row["asignatura"].ToString();
                    double primer = Convert.ToDouble(row["1Exm"]);
                    double segundo = Convert.ToDouble(row["2Exm"]);
                    double tercer = Convert.ToDouble(row["3Exm"]);
                    double cuarto = Convert.ToDouble(row["4Exm"]);
                    double quinto = Convert.ToDouble(row["5Exm"]);
                    double sexto = Convert.ToDouble(row["6Exm"]);


                    double notaMediaAsignatura = (primer + segundo + tercer + cuarto + quinto + sexto) / 3.0;

                    // Agregar o actualizar la suma de las notas y la cantidad de notas por asignatura
                    if (notasSumadas.ContainsKey(asignatura))
                    {
                        var sumaCantidad = notasSumadas[asignatura];
                        notasSumadas[asignatura] = new Tuple<double, int>(sumaCantidad.Item1 + notaMediaAsignatura, sumaCantidad.Item2 + 1);
                    }
                    else
                    {
                        notasSumadas.Add(asignatura, new Tuple<double, int>(notaMediaAsignatura, 1));
                    }
                }

                // Calcular la media final para cada asignatura
                foreach (string asignatura in notasSumadas.Keys.ToList())
                {
                    double sumaNotas = notasSumadas[asignatura].Item1;
                    int cantidadNotas = notasSumadas[asignatura].Item2;
                    double notaMedia = sumaNotas / cantidadNotas;
                    notasSumadas[asignatura] = new Tuple<double, int>(notaMedia, cantidadNotas);
                }

             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la nota media por asignatura: " + ex.Message);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            // Convertir el diccionario de notas sumadas a un diccionario de medias por asignatura
            Dictionary<string, double> notasMedias = new Dictionary<string, double>();
            foreach (var kvp in notasSumadas)
            {
                notasMedias.Add(kvp.Key, kvp.Value.Item1);
            }

            return notasMedias;
        }




        /// /////////////////////




        public void MostrarClienteSeleccionado(DataRow clienteSeleccionado)
        {

            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string id = clienteSeleccionado["ID"].ToString();

                // Calcular la nota media por asignatura
                Dictionary<string, double> notasMediasPorAsignatura = CalcularNotaMediaPorAsignatura(id);

                DataTable tablaNotas = new DataTable();
                tablaNotas.Columns.Add("Asignatura");
                tablaNotas.Columns.Add("1Exm");
                tablaNotas.Columns.Add("2Exm");
                tablaNotas.Columns.Add("3Exm");
                tablaNotas.Columns.Add("4Exm");
                tablaNotas.Columns.Add("5Exm");
                tablaNotas.Columns.Add("6Exm");


                tablaNotas.Columns.Add("Nota Media Asignatura");
               tablaNotas.Columns.Add("Nota Media del curso"); // Nueva columna para la nota media del curso

                string consultaNotas = "SELECT asignatura, 1Exm, 2Exm, 3Exm, 4Exm, 5Exm, 6Exm " +
                                       "FROM notas " +
                                       "WHERE id = @id";

                adaptador = new MySqlDataAdapter(consultaNotas, conexion);
                adaptador.SelectCommand.Parameters.AddWithValue("@id", id);

                DataTable tablaNotasIndividuales = new DataTable();
                adaptador.Fill(tablaNotasIndividuales);

                double sumaTotal = 0.0; // Variable para sumar todas las notas del curso

                foreach (DataRow row in tablaNotasIndividuales.Rows)
                {
                    string asignatura = row["asignatura"].ToString();
                    double primer= Convert.ToDouble(row["1Exm"]);
                    double segundo = Convert.ToDouble(row["2Exm"]);
                    double tercer = Convert.ToDouble(row["3Exm"]);
                    double cuarto = Convert.ToDouble(row["4Exm"]);
                    double quinto = Convert.ToDouble(row["5Exm"]);
                    double sexto = Convert.ToDouble(row["6Exm"]);

                    double notaMediaAsignatura = notasMediasPorAsignatura.ContainsKey(asignatura) ? notasMediasPorAsignatura[asignatura] : 0.0;


                    // Calcular la nota media del curso
                    double notaMediaCurso = (primer + segundo+ tercer + cuarto + quinto + sexto) / 3.0;
                    sumaTotal += notaMediaCurso;

                    tablaNotas.Rows.Add(asignatura, primer, segundo, tercer, cuarto, quinto, sexto,  notaMediaAsignatura);
                }

                // Calcular la nota media del curso para mostrar en la última fila
                double notaMediaTotal = tablaNotas.Rows.Count > 0 ? sumaTotal / tablaNotas.Rows.Count : 0.0;
                tablaNotas.Rows.Add("Nota media del curso", "-", "-", "-", "-","-", "-", "-" , notaMediaTotal);

                dataGridINFORMACION.DataSource = tablaNotas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
        }



        // //////////////////////////////




        private void buttonMOfifcarNota_Click(object sender, EventArgs e)
        {

            if (dataGridINFORMACION.SelectedRows.Count > 0)
            {

                string asignatura = dataGridINFORMACION.SelectedRows[0].Cells["asignatura"].Value.ToString();
                string primero = dataGridINFORMACION.SelectedRows[0].Cells["1Exm"].Value.ToString();
                string segundo = dataGridINFORMACION.SelectedRows[0].Cells["2Exm"].Value.ToString();
                string tercero = dataGridINFORMACION.SelectedRows[0].Cells["3Exm"].Value.ToString();
                string cuarto = dataGridINFORMACION.SelectedRows[0].Cells["4Exm"].Value.ToString();
                string quinto = dataGridINFORMACION.SelectedRows[0].Cells["5Exm"].Value.ToString();
                string sexto = dataGridINFORMACION.SelectedRows[0].Cells["6Exm"].Value.ToString();



                modificarNOTA modificar = new modificarNOTA(conexion, asignatura, primero, segundo, tercero,cuarto,quinto,sexto);
             
                modificar.CambiosRealizados += Añadir_CambiosRealizados;
                modificar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de modificar");
            }
        }



        //


        private void dataGridINFORMACION_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }



        // ////////////////////////





        private void buttonAñadirNOTAS_Click(object sender, EventArgs e)
        {
            AñadirNOTAS añadir = new AñadirNOTAS(conexion);
            añadir.ShowDialog();
            añadir.CambiosRealizados += Añadir_CambiosRealizados;
        }




        // ///////////////////////////



    }
}
