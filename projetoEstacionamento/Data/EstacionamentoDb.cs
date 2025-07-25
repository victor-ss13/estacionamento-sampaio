using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetoEstacionamento.Models;

// Esse arquivo tem o papel de armazenar, temporariamente, os veículos que estão no estacionamento durante a execução do programa

namespace projetoEstacionamento.Data
{
    // É uma classe estática, ou seja, não precisa ser instanciada / Permite acesso de qualquer lugar do projeto utilizando 'EstacionamentoDb.Veiculos'
    public static class EstacionamentoDb
    {
        // Representa a coleção de veículos estacionados no momento / 'static' define que é única e compartilhada em todo o programa / 'get' permite ler a lista e modificar o conteúdo (sem substituí-la) / 'new List<Veiculos>()' inicia a lista vazia
        public static List<Veiculo> Veiculos { get; } = new List<Veiculo>();  

        // Usar uma classe estática como "banco" simplifica o acesso, reduz acoplamento desnecessário, imita o funcionamento de um banco de dados real com uma lista em memória e é ideal para um projeto console simples e didático.
    }
}

// Como será usada na prática:

// Cadastrar: EstacionamentoDb.Veiculos.Add(novoVeiculo);
// Remover: EstacionamentoDb.Veiculos.Remove(veiculo);
// Listar: var todos = EstacionamentoDb.Veiculos;