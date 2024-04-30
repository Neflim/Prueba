using proyecto_2.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_2.Repositorios
{
    public class EstudiantesRepo
    {
        private ConexionBD conexionBD;
        public EstudiantesRepo()
        {
            conexionBD = new ConexionBD();
        }

        public void Insertar(Estudiante estudiante)
        {
            conexionBD = new ConexionBD();
            string query = "INSERT INTO Estudiantes (Nombre, Apellido, FechaNacimiento) VALUES (@Nombre, @Apellido, @FechaNacimiento)";
            using (SqlConnection conexion = conexionBD.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(Estudiante estudiante)
        {
            conexionBD = new ConexionBD();
            string query = "DELETE FROM Estudiantes WHERE Id = @Id";
            using (SqlConnection conexion = conexionBD.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", estudiante.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Estudiante estudiante)
        {
            conexionBD = new ConexionBD();
            string query = "UPDATE Estudiantes SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento WHERE Id = @Id";
            using (SqlConnection conexion = conexionBD.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Id", estudiante.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            DataTable dt = new DataTable();
            conexionBD = new ConexionBD();
            using (SqlConnection conexion = conexionBD.AbrirConexion())
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Estudiantes", conexion);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
            }

            List<Estudiante> estudiantes = new List<Estudiante>();
            foreach (DataRow row in dt.Rows)
            {
                Estudiante estudiante = new Estudiante
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"])
                };
                estudiantes.Add(estudiante);
            }

            return estudiantes;
        }
    }
}
