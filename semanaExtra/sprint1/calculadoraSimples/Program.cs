// See https://aka.ms/new-console-template for more information

Console.Write("Qual conta você deseja fazer (+, -, *, /)? ");
string escolha = Console.ReadLine();

string[] operacoes = { "+", "-", "*", "/" };

if (!operacoes.Contains(escolha))
{
    Console.WriteLine("Operador inválido!");
}
else
{
    Console.Write("Escolha seu primeiro número: ");
    int.TryParse(Console.ReadLine(), out int numero1);

    Console.Write("Escolha seu segundo número: ");
    int.TryParse(Console.ReadLine(), out int numero2);

    if (numero2 == 0)
    {
        Console.WriteLine("Divisão por zero não é permitida.");
    }
    else
    {
        switch (escolha)
        {
            case "+":
                Console.WriteLine($"Resultado: {numero1 + numero2}");
                break;
            case "-":
                Console.WriteLine($"Resultado: {numero1 - numero2}");
                break;
            case "*":
                Console.WriteLine($"Resultado: {numero1 * numero2}");
                break;
            case "/":
                Console.WriteLine($"Resultado: {numero1 / numero2}");
                break;
        }
    }
}

