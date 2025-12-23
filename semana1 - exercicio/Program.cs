// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("=== Parte 1 do exercício ===");

// Repare que sem o Line a linha não é pulada 
Console.Write("Coloque aqui seu número inteiro: ");
// pega a entrada
var entrada = Console.ReadLine();
// Tenta converter a string 'entrada' em um número inteiro.
// Se a conversão for bem-sucedida, retorna true e armazena o valor convertido na variável 'numero'.
// Se falhar (entrada inválida), retorna false e 'numero' recebe 0, sem lançar exceção.
int.TryParse(entrada, out int numero);

if (numero > 0)
{
    Console.WriteLine("Número positivo");
}
else if (numero < 0)
{
    Console.WriteLine("Número negativo");
}
else
{
    Console.WriteLine("Número zero");
}

if (numero % 2 == 0)
{
    Console.WriteLine("Número par");
}
else
{
    Console.WriteLine("Número ímpar");
}

Console.WriteLine("=== Parte 2 do exercício ===");

Console.Write("Primeiro número: ");
// Tenta converter o valor digitado em um double, aceitando vários formatos numéricos e usando ponto como separador decimal, sem gerar exceção se falhar.
double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double n1);

Console.Write("Segundo número: ");
double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double n2);

Console.Write("1 = somar | 2 = subtrair | 3 = sair: ");
int.TryParse(Console.ReadLine(), out int opcao);

switch (opcao)
{
    case 1:
        Console.WriteLine($"Resultado: {n1 + n2}");
        break;

    case 2:
        Console.WriteLine($"Resultado: {n1 - n2}");
        break;

    case 3:
        Console.WriteLine("Saindo...");
        break;

    default:
        Console.WriteLine("Opção inválida!");
        break;
}