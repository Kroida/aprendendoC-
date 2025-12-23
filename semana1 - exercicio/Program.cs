// See https://aka.ms/new-console-template for more information

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

Console.Write("Coloque aqui seu número: ");
var entrada = Console.ReadLine();
double.TryParse(entrada, out double numero);

