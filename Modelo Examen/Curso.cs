using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Examen
{
    public class Curso
    {
        public string Nombre { get; set; }

        public List<Alumno> alumnos { get; set; } = new List<Alumno>();
        public Profesor profesor { get; set; }
        public Escuela escuela { get; set; }

        public void InscribirAlumno(Alumno alumno) {
            alumnos.Add(alumno);
        }

        public void AsignarProfesor(Profesor profe) {
            profesor = profe;
            profesor.curso = this;
        }

    }
}
