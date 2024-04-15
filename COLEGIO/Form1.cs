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
    public partial class Form1 : Form
    {


        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;

        // Constantes para la conexión
        private const string host = "127.0.0.1";
        private const string usuarioBD = "root";
        private const string contraseñaBD = "123456";
        private const string nombreBD = "Seguros"; // Reemplaza "tu_basededatos" por el nombre de tu base de datos








        public Form1()
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)// alumnos
        {
           ALUMNOS alumnos = new  ALUMNOS(conexion);
            alumnos.ShowDialog();
        }

        private void ajustesToolStripMenuItem_Click(object sender, EventArgs e)//ajustes
        {
            Ajustes ajustar = new Ajustes();
            ajustar.ShowDialog();
        }
    }
}
