using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Primeiro arquivo que devemos criar para o projeto, onde serão criadas as representações dos veículos
// Este arquivo define a classe Veiculo, que representa um veículo no sistema de estacionamento
// A classe Veiculo possui duas propriedades: Placa e HoraEntrada, que armazenam a placa do veículo e a hora de entrada no estacionamento, respectivamente
// A classe é pública, permitindo que seja acessada de outras partes do sistema

namespace projetoEstacionamento.Models
{
    // Cria a classe pública "Veiculo", podendo ser acessada de qualquer parte do sistema
    public class Veiculo
    {
        // Identifica o veículo pela placa / get e set indicam possibilidade de leitura e escrita
        public string Placa { get; set; } = string.Empty;

        // Armazena data e hora que o veículo foi cadastrado no sistema / Será usado para calcular o valor a ser pago
        public DateTime HoraEntrada { get; set; }   
    }
}