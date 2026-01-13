// See https://aka.ms/new-console-template for more information
/* ========== Parte  1 ========== */
// Crie um método que:

// - Aguarde 2 segundos
// - Exiba uma mensagem

// Depois:

// - Chame ele de forma **assíncrona**

/* ========== Parte  2 ========== */
// Leia um arquivo de texto:

// - De forma assíncrona
// - Exiba o conteúdo

using System.Threading.Tasks;

class Assincrono
{
    public async Task MensagemAssincrona()
    {
        await Task.Delay(2000);
        Console.WriteLine("Hello C#");
    }

    public async Task ArquivoAssincrono()
    {
        var arquivo = await File.ReadAllTextAsync("arquivo.txt");
        Console.WriteLine(arquivo);
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Assincrono mensagem = new Assincrono();
        await mensagem.ArquivoAssincrono();
        await mensagem.MensagemAssincrona();
    }
}
