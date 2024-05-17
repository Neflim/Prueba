using System;
using System.Windows.Forms;
using proyecto_2.Modelos;
using proyecto_2.Servicios;

namespace proyecto_2
{
    public partial class Form3 : Form
    {
        private EstudiantesServicio estudiantesServicio;

        public Form3()
        {
            InitializeComponent();
            estudiantesServicio = new EstudiantesServicio();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var estudiante = new Estudiante
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFechaNacimiento.Value
            };

            try
            {
                estudiantesServicio.Insertar(estudiante);
                MessageBox.Show("Estudiante insertado exitosamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al insertar el estudiante: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
