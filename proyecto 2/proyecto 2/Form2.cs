using System;
using System.Windows.Forms;
using proyecto_2.Modelos;
using proyecto_2.Servicios;

namespace proyecto_2
{
    public partial class Form2 : Form
    {
        private EstudiantesServicio estudiantesServicio;
        private int idEstudianteSeleccionado;

        public Form2()
        {
            InitializeComponent();
            estudiantesServicio = new EstudiantesServicio();
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            dataGridViewEstudiantes.Rows.Clear();
            var estudiantes = estudiantesServicio.ObtenerEstudiantes();

            foreach (var estudiante in estudiantes)
            {
                dataGridViewEstudiantes.Rows.Add(estudiante.Id, estudiante.Nombre, estudiante.Apellido, estudiante.FechaNacimiento.ToString("dd/MM/yyyy"));
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idEstudianteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un estudiante para modificar.");
                return;
            }

            var estudiante = new Estudiante
            {
                Id = idEstudianteSeleccionado,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFechaNacimiento.Value
            };

            try
            {
                estudiantesServicio.Actualizar(estudiante);
                MessageBox.Show("Estudiante modificado exitosamente.");
                CargarEstudiantes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al modificar el estudiante: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            idEstudianteSeleccionado = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void dataGridViewEstudiantes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEstudiantes.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewEstudiantes.SelectedRows[0];
                idEstudianteSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaNacimiento"].Value);
            }
        }
    }
}
