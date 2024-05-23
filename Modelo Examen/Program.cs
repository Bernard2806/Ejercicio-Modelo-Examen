using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Examen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Escuela> escuelas = new List<Escuela>();
            ImprimirMenuInicial();
            CargarEscuela(Escuela)
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
        }
    }
}
