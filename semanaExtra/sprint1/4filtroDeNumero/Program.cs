// See https://aka.ms/new-console-template for more information
var numeros = Enumerable.Range(1, 20).ToList(); // lista de 1 a 20

var impares = numeros
    .Where(n => n % 2 != 0 && n > 10)
    .Select(n => n * 2);

var listaImpar = impares.ToList();

for (int i = 0; i < listaImpar.Count;)
{
    if (i == 0)
    {
        Console.WriteLine("Lista de números impares maiores que 10 e menores que 20:");
        i += 1;
    }
    else
    {
        Console.WriteLine(listaImpar[i]);
        i += 1;
    }
}

