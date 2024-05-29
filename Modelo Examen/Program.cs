using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Examen
{
    internal class Program
    {
        private static string[] MenuVerOCargar = new string[] {
            "Cargar Escuela",
            "Ver / Modificar Escuelas",
        };
        static void Main(string[] args)
        {
            List<Escuela> escuelas = new List<Escuela>();
            ImprimirMenuInicial();
            if (MostrarMenu(MenuVerOCargar) == 0){
                escuelas.Add(CargarEscuela());
            }
            else { 
            
            }
            

            
        }

        private static void ImprimirMenuInicial()
        {
            string MenuIncio = @"
 _      ____  ____  _____ _     ____    ________  _ ____  _      _____ _     
/ \__/|/  _ \/  _ \/  __// \   /  _ \  /  __/\  \///  _ \/ \__/|/  __// \  /|
| |\/||| / \|| | \||  \  | |   | / \|  |  \   \  / | / \|| |\/|||  \  | |\ ||
| |  ||| \_/|| |_/||  /_ | |_/\| \_/|  |  /_  /  \ | |-||| |  |||  /_ | | \||
\_/  \|\____/\____/\____\\____/\____/  \____\/__/\\\_/ \|\_/  \|\____\\_/  \|
                                                                             
";
            Console.WriteLine(MenuIncio);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static Escuela CargarEscuela() {
            Escuela escuela = new Escuela();
            bool repeat;
            do
            {
                Console.WriteLine("Ingrese el Nombre de la Institución: ");
                escuela.NombreEsc = Console.ReadLine();
                Console.WriteLine("Ingrese la Cuidad Donde se Ubica: ");
                escuela.Ciudad = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("A continuacion se mostrara la informacion de la Institución:");

                Console.WriteLine("¿La informacion es correcta? (y/n)");
                repeat = "n" == Console.ReadLine().ToLower();
            } while (repeat);
            Console.WriteLine("A Continuacion se Solicitara la Carga de los Cursos...");
            do
            {
                escuela.Cursos.Add(CargarCurso(escuela));
                Console.WriteLine("¿Desea cargar otro curso? (y/n)");
                repeat = "y" == Console.ReadLine().ToLower();
            } while (repeat);
            return escuela;
        }

        private static Curso CargarCurso(Escuela esc) {
            Curso curso = new Curso();
            curso.escuela = esc;

            Console.WriteLine("Ingrese el Nombre del Curso/Materia:");
            curso.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los Datos del Profersor del Curso:");
            curso.AsignarProfesor(CargarProfesor());

            Console.WriteLine("Ingrese los Datos de los Alumnos del Curso:");
            curso.InscribirAlumno(CargarAlumno());
            return curso;
        }

        private static Profesor CargarProfesor()
        {
            bool rep;
            Profesor profesor = new Profesor();
            do
            {
                CargarPersona(profesor);

                Console.WriteLine("Ingrese el Sueldo del Profesor: ");
                profesor.Sueldo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el Titulo del Profesor: ");
                profesor.Titulo = Console.ReadLine();
                Console.WriteLine("¿La informacion es correcta? (y/n)");
                rep = "n" == Console.ReadLine().ToLower();
            } while (rep);

            return profesor;
        }

        private static Alumno CargarAlumno() {
            bool repetir;
            Alumno alumno = new Alumno();
            do
            {
                CargarPersona(alumno);
                Console.WriteLine("Ingrese el Año del Alumno:");
                alumno.Año = Console.ReadLine();
            } while (repetir);
            return alumno;
        }

        private static void CargarPersona(Persona p) {
            Console.WriteLine("Ingrese el Nombre de la Persona: ");
            p.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido de la Persona: ");
            p.Apellido = Console.ReadLine();
        }

        private static void MostrarEscuela(Escuela escuela) {
            Console.WriteLine($"Nombre de la Escuela: {escuela.NombreEsc}");
            Console.WriteLine($"Ubicacion (Cuidad) de la Escuela: {escuela.Ciudad}");
        }

        static int MostrarMenu(string[] Opciones, string InitalText = "Seleccione una opción del menu:")
        {
            bool loop = true;
            int counter = 0;
            ConsoleKeyInfo Tecla;

            Console.CursorVisible = false; // Con esto hacemos que el cursor no se muestre en consola

            while (loop)
            {
                Console.Clear();
                Console.WriteLine(InitalText + System.Environment.NewLine);
                string SeleccionActual = string.Empty;
                int Destacado = 0;

                Array.ForEach(Opciones, element =>
                {
                    if (Destacado == counter)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(" > " + element + " < ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        SeleccionActual = element;
                    }
                    else
                    {
                        Console.WriteLine(element);
                    }
                    Destacado++;
                });

                Tecla = Console.ReadKey(true);
                if (Tecla.Key == ConsoleKey.Enter)
                {
                    loop = false;
                    break;
                }
                switch (Tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (counter < Opciones.Length - 1) counter++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (counter > 0) counter--;
                        break;
                    default:
                        break;
                }
            }
            return counter;
        }
    }
}
