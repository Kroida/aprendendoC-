// See https://aka.ms/new-console-template for more information

/* ===== PRIMEIRO EXERCÍCIO ===== */
// Dada uma lista de números:

// - Filtre apenas os maiores que 10
// - Multiplique por 2
// - Exiba o resultado

// 📌 **Regras**

// - Use LINQ
// - Não use `foreach` para filtrar

var numeros = new List<int> { 7, 12, 3, 2, 41, 50, 100, 80, 5};

var resultado = numeros
    .Where(n => n > 10)
    .Select(n => n * 2);

foreach (var n in resultado)
{
    Console.WriteLine(n);
}

/* ===== SEGUNDO EXERCÍCIO ===== */
// Crie um `Dictionary<string, double>`:

// - Chave: nome do aluno
// - Valor: nota

// Depois:

// - Busque um aluno pelo nome
// - Trate o caso de aluno inexistente

// 📌 **Use**

// - `TryGetValue`
// - `try/catch` apenas se fizer sentido

var alunos = new Dictionary<string, double>
{
    ["João"] = 6,
    ["Maria"] = 4,
    ["Enzo"] = 8
};

Console.Write("Digite o nome do aluno: ");
var entrada = Console.ReadLine();

Console.WriteLine("Buscando aluno...");

foreach (var aluno in alunos)
{
    if (alunos.ContainsKey(entrada))
    {
        Console.WriteLine($"Aluno: {entrada}, nota: {alunos[entrada]}");
        break;
    }
    else
    {
        Console.WriteLine("Aluno não encontrado.");
        break;
    }
}