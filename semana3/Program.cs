// See https://aka.ms/new-console-template for more information

/* Nesta primeira parte da aula veremos List e Dictinary */
var nomes = new List<string> {"Luís", "Gustavo", "Neopomoceno"};

nomes.Add("Da Silva");
nomes.Remove("Gustavo");

foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}

var usuarios = new Dictionary<int, string>
{
    [1] = "Maria",
    [2] = "João",
    [3] = "Gustanuk"
};

usuarios[4] = "Xandão";

if (usuarios.TryGetValue(2, out var name))
{
    Console.WriteLine(name);
}

/* Segunda parte: LINQ */
var numeros = new List<int> {1, 2, 3, 4, 5, 6};

var pares = numeros
    .Where(n => n % 2 == 0)
    .Select(n => n * 10);

foreach (var n in pares)
{
    Console.WriteLine(n);
}

// se quiser conservar o resultado
var resultado = pares.ToList();

string texto = "123";

try
{
    var valor = int.Parse(texto);
}
// catch
// {
//     Console.WriteLine("Num deu");
// }
catch (FormatException)
{
    Console.WriteLine("Formato inválido!");
}
catch (OverflowException)
{
    Console.WriteLine("Número fora do limite!");
}