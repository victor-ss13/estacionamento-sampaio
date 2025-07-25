using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;   // Necessário para usar Regex, mecanismo de expressões regulares que usamos para validar as placas

namespace projetoEstacionamento.Utils
{
    public static class ValidadorPlaca
    {
        // Define o padrão a ser seguido para as placas antigas de veículos
        // '^' - Define o início da string
        // '[A-Z]{3}' - Três letras maiúsculas
        // '[0-9]{4}' - Quatro números
        // '$' - Define o final da string
        private static readonly Regex padraoAntigo = new(@"^[A-Z]{3}[0-9]{4}$");

        // Define o padrão a ser seguido para as placas do modelo Mercosul
        // '^' - Define o início da string
        // '[A-Z]{3}' - Três letras maiúsculas
        // '[0-9]{1}' - Um número
        // '[A-Z]{1}' - Uma letra maiúscula
        // '[0-9]{2}' - Dois números
        // '$' - Define o final da string
        private static readonly Regex padraoMercosul = new(@"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$");

        // Recebe uma string 'placa' e retorna true se válida e false se inválida
        public static bool PlacaValida(string placa, out string placaFormatada)
        {
            placaFormatada = string.Empty;

            // Verifica se a placa tem valor nulo, vazia ou se possui apenas espaços em branco, retornando false para qualquer um desses casos
            if (string.IsNullOrWhiteSpace(placa))
            {
                return false;
            }

            // ToUppper - transforma letras em maiúsculas
            // Trim - remove espaços em branco no início e no final da string
            placa = placa.ToUpper().Replace("-", "").Trim();


            if (padraoAntigo.IsMatch(placa))
            {
                placaFormatada = placa.Insert(3, "-");
                return true;
            }
            
            if (padraoMercosul.IsMatch(placa))
            {
                placaFormatada = placa;
                return true;
            }

            return false;
        }
    }
}