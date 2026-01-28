// See https://aka.ms/new-console-template for more information
List<string> lista = new();
Dictionary<string, bool> tarefasConcluidas = new();

for (int i = 0; i < 5; i++)
{
    Console.Write("Digite sua tarefa: ");
    string tarefa = Console.ReadLine() ?? ""; // Se vier null = string vazia
    lista.Add(tarefa);
}

foreach (var tarefa in lista)
{
    Console.Write($"Tarefa {tarefa} concluída? Sim(1) Não(0): ");
    string entrada = Console.ReadLine() ?? ""; // Se vier null = string vazia

    bool condicao = entrada == "1";
    tarefasConcluidas[tarefa] = condicao;
}

Console.Write($"Você deseja consultar uma tarefa? Sim(1) Não(0): ");
string entrada1 = Console.ReadLine() ?? ""; // Se vier null = string vazia
bool condicao1 = entrada1 == "1";

if (condicao1)
{
    Console.Write("Qual tarefa? ");
    string tarefa = Console.ReadLine() ?? "";

    if (tarefasConcluidas.TryGetValue(tarefa, out bool concluida))
    {
        Console.WriteLine(concluida ? $"Tarefa concluída" : "Tarefa pendente");
    }
    else
    {
        Console.WriteLine("Tarefa não encontrada.");
    }
}

foreach (var item in tarefasConcluidas)
{
    Console.WriteLine($"Tarefa {item.Key} → {item.Value}");
}

