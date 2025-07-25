global using projetoEstacionamento.Utils;
global using projetoEstacionamento.Services;

var servico = new EstacionamentoService();
bool executando = true;

while (executando)
{
    ConsoleHelper.LimparTela();
    Console.WriteLine("=== ESTACIONAMENTO SAMPAIO ===\n");
    Console.WriteLine("-> Preço inicial: R$ 5,00");
    Console.WriteLine("-> Preço por hora: R$ 2,00\n");
    Console.WriteLine("1 - Cadastrar Veículo");
    Console.WriteLine("2 - Remover Veículo");
    Console.WriteLine("3 - Listar Veículos");
    Console.WriteLine("4 - Encerrar");
    Console.Write("\nEscolha uma opção: ");
    string? opcao = Console.ReadLine();

    ConsoleHelper.LimparTela();

    switch (opcao)
    {
        case "1":
            servico.CadastrarVeiculo();
            break;
        case "2":
            servico.RemoverVeiculo();
            break;
        case "3":
            servico.ListarVeiculos();
            break;
        case "4":
            executando = false;
            Console.WriteLine("Agradecemos por usar nosso sistema! Volte sempre!\n\nEncerrando o sistema...");
            break;
        default:
            Console.WriteLine("Opção inválida! Por favor, escolha uma opção válida.");
            break;
    }

    if (executando)
    {
        ConsoleHelper.Pausar();
    }
}