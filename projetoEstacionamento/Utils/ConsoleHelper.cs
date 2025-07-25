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

        // Função para permitir voltar ao menu principal pressionando ESC
        // Testar depois
        public static bool VerificaEsc(string mensagem = "\nPressione ESC para sair ou qualquer outra tecla para continuar...")
        {
            Console.WriteLine(mensagem);

            var tecla = Console.ReadKey(intercept: true).Key;

            if (tecla == ConsoleKey.Escape)
            {
                Console.Clear();
                return true;
            }

            return false;
        }
    }
}