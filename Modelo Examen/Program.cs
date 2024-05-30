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
            "Salir"
        };
        static void Main(string[] args)
        {
            List<Escuela> escuelas = new List<Escuela>();
            ImprimirMenuInicial();
            do
            {
                switch (MostrarMenu(MenuVerOCargar))
                {
                    case 0:
                        do
                        {
                            Console.Clear();
                            var escuela = CargarEscuela();
                            if (escuela != null) escuelas.Add(escuela);
                            else break;
                        } while (true);
                        break;
                    case 1:
                        MostrarEscuelas(escuelas);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
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

            private static Escuela CargarEscuela()
            {
                Escuela escuela = new Escuela();

                Console.WriteLine("Ingrese el Nombre de la Institución: ");
                escuela.NombreEsc = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(escuela.NombreEsc)) return null;

                Console.WriteLine("Ingrese la Cuidad Donde se Ubica: ");
                escuela.Ciudad = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("A Continuacion se Solicitara la Carga de los Cursos...");
                Console.ReadKey();
                Console.Clear();
                do
                {
                    var curso = CargarCurso(escuela);
                    if (curso != null)
                        escuela.Cursos.Add(curso);
                    else
                        break;
                } while (true);
                return escuela;
            }

            private static Curso CargarCurso(Escuela esc)
            {
                Curso curso = new Curso();
                curso.escuela = esc;

                Console.WriteLine("Ingrese el Nombre del Curso/Materia:");
                curso.Nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(curso.Nombre)) return null;

                Console.WriteLine("Ingrese los Datos del Profersor del Curso:");
                curso.AsignarProfesor(CargarProfesor());

                Console.WriteLine("Ingrese los Datos de los Alumnos del Curso:");
                do
                {
                    var alumno = CargarAlumno();
                    if (alumno != null) curso.InscribirAlumno(alumno);
                    else break;
                } while (true);
                return curso;
            }

            private static Profesor CargarProfesor()
            {
                Profesor profesor = new Profesor();
                CargarPersona(profesor);
                Console.WriteLine("Ingrese el Sueldo del Profesor: ");
                profesor.Sueldo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el Titulo del Profesor: ");
                profesor.Titulo = Console.ReadLine();
                return profesor;
            }

            private static Alumno CargarAlumno()
            {
                Alumno alumno = new Alumno();

                Console.WriteLine("Ingrese el Nombre del Alumno");
                alumno.Nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(alumno.Nombre)) return null;
                Console.WriteLine("Ingrese el Apellido del Alumno:");
                alumno.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el Año del Alumno:");
                alumno.Año = Console.ReadLine();
                return alumno;
            }

            private static void CargarPersona(Persona p)
            {
                Console.WriteLine("Ingrese el Nombre de la Persona: ");
                p.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el Apellido de la Persona: ");
                p.Apellido = Console.ReadLine();
            }

            private static void MostrarEscuelas(List<Escuela> escuelas)
            {
                foreach (var escuela in escuelas)
                {
                    Console.WriteLine($"Escuela: {escuela.NombreEsc}");
                    Console.WriteLine($" Ciudad: {escuela.Ciudad}");

                    Console.WriteLine("  Cursos:");
                    foreach (var curso in escuela.Cursos)
                    {
                        Console.WriteLine($"    {curso.Nombre}");
                        Console.WriteLine($"      Profesor: {curso.profesor.Nombre}, {curso.profesor.Apellido}");


                        foreach (var alumno in curso.alumnos)
                        {
                            Console.WriteLine($"        - {alumno.Nombre}, {alumno.Apellido}");
                        }
                    }
                    Console.WriteLine();
                }
            Console.ReadKey();
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
