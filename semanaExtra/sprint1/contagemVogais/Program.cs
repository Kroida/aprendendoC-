// See https://aka.ms/new-console-template for more information
string[] vogais = {"a", "e", "i", "o", "u"};

Console.Write("Digite sua palavra: ");
string palavra = Console.ReadLine().ToLower();

int encontrada = 0;

foreach (char letra in palavra)
{
    if (vogais.Contains(letra.ToString())) // Tratamento de erro ToString
    {
        Console.Write($"{letra}, ");
        encontrada += 1;
    }
}

Console.WriteLine($"\nA palavra possui {encontrada} vogais.");
