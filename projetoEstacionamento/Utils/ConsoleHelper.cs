using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoEstacionamento.Utils
{
    public static class ConsoleHelper
    {
        public static void LimparTela()
        {
            Console.Clear();
        }

        public static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }   
    }
}