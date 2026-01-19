// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

interface IProdutoRepositorio
{
    void Adicionar(string nome, double preco);
    double? ObterPreco(string nome);
    double CalcularTotal();
    void MostrarProdutos();
    Task SalvarArquivo();
}

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly Dictionary<string, double> _produtos = new();

    public void Adicionar(string nome, double preco)
    {
        _produtos[nome] = preco;
    }

    public double? ObterPreco(string nome)
    {
        return _produtos.TryGetValue(nome, out var preco)
            ? preco
            : null;
    }

    public double CalcularTotal()
    {
        double total = 0;

        foreach (var preco in _produtos.Values)
        {
            total += preco;
        }

        return total;
    }

    public void MostrarProdutos()
    {
        foreach (var item in _produtos)
        {
            Console.WriteLine($"{item.Key} → {item.Value}");
        }
    }

    public async Task SalvarArquivo()
    {
        var linhas = new List<string>
        {
            "=== Produtos do carrinho ==="
        };

        foreach (var item in _produtos)
        {
            linhas.Add($"{item.Key} → {item.Value}");
        }

        await File.WriteAllLinesAsync("produtos.txt", linhas);
    }
}

record Produto()
{
    static void Main(string[] args)
    {
        IProdutoRepositorio carrinho = new ProdutoRepositorio();
        carrinho.Adicionar("pera", 5);
        carrinho.Adicionar("maçã", 3);
        carrinho.MostrarProdutos();
        Console.WriteLine($"O total é {carrinho.CalcularTotal()}");
        Console.WriteLine($"O preço da pera é: {carrinho.ObterPreco("pera")}");
        carrinho.SalvarArquivo();
    }
}
