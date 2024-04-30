using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_2.Repositorios
{
    public class ConexionBD
    {
        public SqlConnection conexion;
        public string connectionString = "server=localhost; database=TestJosue; integrated security=true";

        public ConexionBD()
        {
            conexion = new SqlConnection(connectionString);
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}
