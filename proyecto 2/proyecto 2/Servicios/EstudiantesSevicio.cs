using proyecto_2.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static proyecto_2.Form1;
using System.Windows.Forms;
using proyecto_2.Repositorios;

namespace proyecto_2.Servicios
{
    public class EstudiantesServicio
    {
        private EstudiantesRepo EstudiantesRepo;
        public EstudiantesServicio()
        {
            EstudiantesRepo = new EstudiantesRepo();
        }

        public void Insertar(Estudiante estudiante)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(estudiante.Nombre) || string.IsNullOrWhiteSpace(estudiante.Apellido))
                {
                    throw new Exception("Ingrese un nombre y apellido valido");
                }

                if (estudiante.FechaNacimiento >= DateTime.Now.Date)
                {
                    throw new Exception("La fecha de nacimiento no puede ser la fecha actual");
                }

                if (estudiante.FechaNacimiento.Year < 1998)
                {
                    throw new Exception("La fecha de nacimiento no pueder ser antes del 1998");
                }

                EstudiantesRepo.Insertar(estudiante);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error de validación: " + ex.Message);
            }            
        }

        public void Actualizar(Estudiante estudiante)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(estudiante.Nombre) || string.IsNullOrWhiteSpace(estudiante.Apellido))
                {
                    throw new Exception("ingrese un nombre y apellido valido");
                }

                if (estudiante.FechaNacimiento >= DateTime.Now.Date)
                {
                    throw new Exception("la fecha de nacimiento no puede ser la fecha actual");
                }

                if (estudiante.FechaNacimiento.Year < 1998)
                {
                    throw new Exception("la fecha de nacimiento no pueder ser antes del 1998");
                }

                EstudiantesRepo.Actualizar(estudiante);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error de validación: " + ex.Message);
            }
            
        }

        public void Eliminar(Estudiante estudiante)
        {
            try
            {
                EstudiantesRepo.Eliminar(estudiante);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar: " + ex.Message);
            }
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return EstudiantesRepo.ObtenerEstudiantes();
        }
    }
}
