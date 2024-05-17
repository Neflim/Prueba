using System;
using System.Windows.Forms;
using proyecto_2.Modelos;
using proyecto_2.Repositorios;
using proyecto_2.Servicios;
using System.Data.SqlClient;
using System.Collections.Generic; // Suponiendo que estás usando SQL Server

namespace proyecto_2
{
    public partial class Form1 : Form
    {
        private EstudiantesServicio estudiantesServicio;
 

        public Form1()
        {
            InitializeComponent();
            estudiantesServicio = new EstudiantesServicio();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de cargar nuevos datos
            dataGridViewEstudiantes.Rows.Clear();

            // Obtener los estudiantes del servicio
            List<Estudiante> estudiantes = estudiantesServicio.ObtenerEstudiantes();

            // Mostrar los estudiantes en el DataGridView
            foreach (Estudiante estudiante in estudiantes)
            {
                dataGridViewEstudiantes.Rows.Add(estudiante.Id, estudiante.Nombre, estudiante.Apellido, estudiante.FechaNacimiento.ToString("dd/MM/yyyy"));
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Cerrar el Form1
            this.Close();

            // Abrir el Form2 y pasarle una referencia al Form1
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
           Form3 form3 = new Form3();
            form3.ShowDialog();

        }
    }
}