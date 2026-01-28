// See https://aka.ms/new-console-template for more information
int.TryParse(Console.ReadLine(), out int numero);

for (int i = 0; i < 10;)
{
    if (numero % 2 == 0 && i < 10)
    {
        i += 2;
        Console.WriteLine($"{numero} X {i} = {numero * i}");
    }
    else if (numero % 2 != 0 && i < 1)
    {
        i = 1;
        Console.WriteLine($"{numero} X {i} = {numero * i}");
        i += 2;
    }
    else
    {
        Console.WriteLine($"{numero} X {i} = {numero * i}");
        i += 2;
    }
}
