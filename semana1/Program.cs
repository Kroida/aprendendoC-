// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Tipo explícito
int numero = 10;

// Tipo implícito
var texto = "O número é ";

// if e else
if (numero == 10)
{
    Console.WriteLine(texto + numero);
}
else
{
    Console.WriteLine("Número diferente de 10");
}

// switch case
int dia = 4;

switch(dia)
{
    case 1:
        Console.WriteLine("Segunda-feira");
        break;
    case 2:
        Console.WriteLine("Terça-feira");
        break;
    case 3:
        Console.WriteLine("Quarta-feira");
        break;
    case 4:
        Console.WriteLine("Quinta-feira");
        break;
    case 5:
        Console.WriteLine("Sexta-feira");
        break;
    case 6:
        Console.WriteLine("Sábado");
        break;
    case 7:
        Console.WriteLine("Domingo");
        break;
    default:
        Console.WriteLine("Dia inválido");
        break;
}

