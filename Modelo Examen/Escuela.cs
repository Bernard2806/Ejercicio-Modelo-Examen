using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Examen
{
    public class Escuela
    {
        public string NombreEsc { get; set; }
        public string Ciudad { get; set; }
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
