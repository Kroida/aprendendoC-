// See https://aka.ms/new-console-template for more information

// Versão com class
// class Produto
// {
//     string Nome {get; init;}
//     string Categoria {get; init;}
//     double Preco {get; init;}

//     static void Main(string[] args)
//     {
//         Produto produto = new Produto
//         {
//             Nome = "Maçã", 
//             Categoria = "Fruta", 
//             Preco = 4
//         };

//         Produto produto1 = new Produto
//         {
//             Nome = "Abacaxi", 
//             Categoria = "Fruta", 
//             Preco = 7
//         };

//         Console.WriteLine(produto == produto1);
//     }
// }

// Versão com record
// record Produto(string Nome, string Categoria, double Preco)
// {
//     static void Main(string[] args)
//     {
//         var produto = new Produto("Maçã", "Fruta", 4);
//         var produto1 = new Produto("Tomate", "Vegetal", 3);

//         Console.WriteLine(produto == produto1);
//     }
// }


/* ========== SEMANA 2 - PARTE 2 DO EXERCÍCIO ========== */
using System.Globalization;

class ContaBancaria
{
    private double saldo;
    public void Depositar()
    {
        Console.Write("Faça seu depósito: ");
        double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double deposito);
        
        saldo += deposito;
        
        Console.WriteLine($"Saldo atual: {saldo}");
    }
    public void Sacar()
    {
        Console.Write("Faça seu saque: ");
        double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double saque);

        if (saldo <= 0)
        {
            Console.WriteLine("Saldo insuficiente.");
        }
        else if(saque > saldo)
        {
            Console.WriteLine("Saque maior do que o saldo.");
        }
        else
        {
            saldo -= saque;
            Console.WriteLine("Saque efetuado.");
            Console.WriteLine($"Valor do saque: {saque}");
            Console.WriteLine($"Saldo atual: {saldo}");
        }
    } 
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria luis = new ContaBancaria();
        int resposta;

        while (true) // 🔁 loop infinito controlado
        {
            Console.WriteLine("\n1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Encerrar");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out resposta))
            {
                Console.WriteLine("Entrada inválida.");
                continue; // volta para o início do loop
            }

            switch (resposta)
            {
                case 1:
                    luis.Depositar();
                    break;

                case 2:
                    luis.Sacar();
                    break;

                case 3:
                    Console.WriteLine("Encerrando o programa...");
                    return; // 🚪 sai do Main → encerra o programa

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}