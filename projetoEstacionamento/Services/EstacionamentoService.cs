using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetoEstacionamento.Models; // Importa o modelo 'Veiculo', pois vamos instanciar um objeto do tipo 'Veiculo'
using projetoEstacionamento.Data;   // Importa o "banco de dados" em memória, onde salvaremos o novo veículo
using projetoEstacionamento.Utils; // Importa a classe 'ValidadorPlaca', que contém a lógica de validação das placas dos veículos

// Será a camada de serviço do nosso projeto, orquestrando as regras de negócio para as operações do estacionamento: cadastrar, remover, listar, etc.

namespace projetoEstacionamento.Services
{
    public class EstacionamentoService  // Clase pública, acessível por 'Program.cs', que agrupa todas as funções relacionadas à lógica do estacionamento
    {
        // Variáveis constantes, do tipo decimal, restrita apenas à classe 'EstacionamentoService'
        private const decimal PrecoInicial = 5.00m;
        private const decimal PrecoPorHora = 2.00m; 

        // Método que será chamado quando o usuário escolher a opção de cadastrar um veículo   
        public void CadastrarVeiculo()
        {
            Console.Write("Digite a placa do veículo: ");

            // Lê a placa do veículo, usando '?.ToUpper()' para transformar em maiúsculo / O operador '?' evita erro caso 'ReadLine()' retorne null
            // 'string?' permite que a variável seja nula, evitando erros caso o usuário não digite nada
            string? placaEntrada = Console.ReadLine()?.ToUpper(); 

            // Verifica se a placa é válida, chamando o método 'PlacaValida' da classe 'ValidadorPlaca'
            if (!ValidadorPlaca.PlacaValida(placaEntrada, out string placaFormatada))
            {
                Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                return;
            }

            // Criação de um objeto 'Veiculo' com as propriedades Placa e HoraEntrada
            var veiculo = new Veiculo
            {
                // Instancia um novo veículo com a placa fornecida
                Placa = placaFormatada, 
                // Registra a hora de entrada com 'DateTime.Now'
                HoraEntrada = DateTime.Now
            };

            // Armazena o novo veículo na lista estática do nosso "Banco de dados"
            EstacionamentoDb.Veiculos.Add(veiculo);
            // Confirma ao usuário que o processo foi concluído
            Console.WriteLine($"Veículo {veiculo.Placa} cadastrado com sucesso!");
        }

        // Método que será chamado quando o usuário escolher a opção de remover um veículo
        public void RemoverVeiculo()    
        {
            // Entrada da placa do veículo a ser removido
            Console.Write("Digite a placa do veículo a ser removido: ");
            // Lê a placa do veículo, usando '?.ToUpper()' para transformar em maiúsculo
            string? placa = Console.ReadLine()?.ToUpper();  //'string?' permite que a variável seja nula, evitando erros caso o usuário não digite nada

            // Tenta encontrar o primeiro veículo cuja placa seja igual à placa passada como parâmetro, se não encontrar, retorna null
            // 'FirstOrDefault' retorna o primeiro elemento que satisfaz a condição ou null se nenhum elemento for encontrado
            // 'v => v.Placa == placa' é uma expressão lambda: para cada veículo 'v', compara a placa desse veículo (convertida para maiúsculas) com a variável 'placa'
            var veiculo = EstacionamentoDb.Veiculos.FirstOrDefault(v => v.Placa == placa);

            // Verificar se o veículo está estacionado
            // Se o veículo não for encontrado, exibe mensagem de erro e sai da função
            if (veiculo == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }

            // Calcula o tempo total que o carro ficou estacionado
            // 'DateTime.Now' retorna a data e hora atual / 'veiculo.HoraEntrada' é a hora de entrada do veículo
            // 'TimeSpan' representa a diferença entre duas datas / 'TotalHours' retorna o total de horas como fração, como 1.5
            // 'Math.Ceiling' arredonda para cima, garantindo que mesmo 1 minuto conte como 1 hora
            TimeSpan tempoEstacionado = DateTime.Now - veiculo.HoraEntrada;
            int horas = (int)Math.Ceiling(tempoEstacionado.TotalHours);

            // Calcula o valor total a ser pago
            decimal valorTotal = PrecoInicial + (horas * PrecoPorHora);

            // Remove o veículo da lista e exibe um resumo do tempo e valor cobrado
            // '[valorTotal:F2]' formata o valor para duas casas decimais, padrão monetário
            EstacionamentoDb.Veiculos.Remove(veiculo);
            Console.WriteLine($"Veículo {veiculo.Placa} removido. Tempo estacionado: {horas} hora(s).Valor a pagar: R$ {valorTotal:F2}.");
        }

        // Método que será chamado quando o usuário escolher a opção de listar os veículos estacionados
        public void ListarVeiculos()
        {
            // Verifica se há veículos estacionados
            // 'EstacionamentoDb.Veiculos' é a lista de veículos estacionados
            // 'Any()' verificar se existe pelo menos um item na lista
            // O operador '!' inverte o resultado, ou seja, se não houver nenhum veículo, ele entra no bloco if
            if (!EstacionamentoDb.Veiculos.Any())
            {
                // Se não houver veículos, exibe mensagem e sai da função
                Console.WriteLine("Nenhum veículo estacionado no momento.");
                return;
            }

            // Exibe um cabeçalho antes de listar os veículos
            Console.WriteLine("Veículos estacionados:\n");
            // Percorre cada veículo na lista 'Veiculos' e joga cada veículo na variável 'veiculo'
            foreach (var veiculo in EstacionamentoDb.Veiculos)
            {
                // Para cada veículo encontrado, exibe a placa e a hora de entrada formatada
                Console.WriteLine($"Placa: {veiculo.Placa} | Entrada: {veiculo.HoraEntrada:HH:mm:ss}");
            }
        }
    }
}