// See https://aka.ms/new-console-template for more information
/* ========== Async e await ========== */

// Código síncrono
// var texto = File.ReadAllText("arquivo.txt");
// Console.WriteLine(texto);

// Código assíncrono
var texto = await File.ReadAllTextAsync("arquivo.txt");
Console.WriteLine(texto);

/* ========== Task ========== */
Task tarefa = Task.Delay(1000); // espera 1 segundo
Task<int> soma = Task.Run(() => 2 + 2);

