## 1️⃣ Estrutura Geral do Programa

- Uso do **novo template de console app** (C# 9+ / .NET 5+)
- Declaração de **interface** para definir contrato do repositório
- Implementação concreta com `Dictionary<string, double>`
- Método assíncrono de salvamento em arquivo
- Uso de `record` apenas como container do `Main` (padrão recente, mas não obrigatório)

## 2️⃣ Interface – Definição do Contrato

**O que é**  
Contrato que define quais operações um repositório de produtos deve suportar.

**Para que serve**  
- Permite inversão de dependência  
- Facilita testes unitários (mocking)  
- Permite trocar implementação sem alterar o código consumidor

```csharp
interface IProdutoRepositorio
{
    void Adicionar(string nome, double preco);
    double? ObterPreco(string nome);
    double CalcularTotal();
    void MostrarProdutos();
    Task SalvarArquivo();
}
```

📌 **Boa prática** — Interfaces em C# costumam começar com `I` (convenção Microsoft)

## 3️⃣ Estrutura de Dados: Dictionary<string, double>

**Por que Dictionary?**  
- Acesso O(1) por chave (nome do produto)  
- Evita duplicatas automaticamente (chave única)  
- Ideal para lookup rápido de preço por nome

```csharp
private readonly Dictionary<string, double> _produtos = new();
```

**Métodos mais usados no exemplo**

| Operação               | Código                                      | Retorno / Efeito                          |
|------------------------|---------------------------------------------|--------------------------------------------|
| Adicionar / Atualizar  | `_produtos[nome] = preco;`                  | Insere ou sobrescreve                      |
| Buscar com fallback    | `_produtos.TryGetValue(nome, out var preco)`| `true` se encontrou, `false` se não       |
| Iterar valores         | `foreach (var preco in _produtos.Values)`   | Apenas preços                              |
| Iterar chave+valor     | `foreach (var item in _produtos)`           | `KeyValuePair<string, double>`             |

⚠️ **Atenção** — Chaves são **case-sensitive** por padrão. Use `StringComparer.OrdinalIgnoreCase` se quiser ignorar maiúsculas/minúsculas.

## 4️⃣ Métodos da Implementação – Destaques

**Adicionar**

```csharp
public void Adicionar(string nome, double preco)
{
    _produtos[nome] = preco;
}
```

**ObterPreco (com null safety)**

```csharp
public double? ObterPreco(string nome)
{
    return _produtos.TryGetValue(nome, out var preco)
        ? preco
        : null;
}
```

**CalcularTotal (acumulação simples)**

```csharp
public double CalcularTotal()
{
    double total = 0;
    foreach (var preco in _produtos.Values)
    {
        total += preco;
    }
    return total;
}
```

**Versão mais idiomática (LINQ)**

```csharp
public double CalcularTotal() => _produtos.Values.Sum();
```

**MostrarProdutos**

```csharp
public void MostrarProdutos()
{
    foreach (var item in _produtos)
    {
        Console.WriteLine($"{item.Key} → {item.Value}");
    }
}
```

**SalvarArquivo (assíncrono)**

```csharp
public async Task SalvarArquivo()
{
    var linhas = new List<string> { "=== Produtos do carrinho ===" };

    foreach (var item in _produtos)
    {
        linhas.Add($"{item.Key} → {item.Value}");
    }

    await File.WriteAllLinesAsync("produtos.txt", linhas);
}
```

🧠 **Versão mais limpa e moderna (C# 11+)**

```csharp
var linhas = new[]
{
    "=== Produtos do carrinho ===",
    .._produtos.Select(kv => $"{kv.Key} → {kv.Value}")
};

await File.WriteAllLinesAsync("produtos.txt", linhas);
```

## 5️⃣ Ponto de Entrada – Uso do record (padrão .NET 6+)

```csharp
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
        carrinho.SalvarArquivo();           // fire-and-forget (não await)
    }
}
```

⚠️ **Problema comum no exemplo**  
`carrinho.SalvarArquivo()` é chamado sem `await` → o programa pode terminar antes da escrita terminar.

**Correção recomendada**

```csharp
await carrinho.SalvarArquivo();
```

Ou tornar `Main` assíncrono:

```csharp
static async Task Main(string[] args)
```

## Cheat-sheet Rápido – C# Conceitos do Exemplo

```csharp
// Interface + injeção
IProdutoRepositorio repo = new ProdutoRepositorio();

// Dictionary – operações frequentes
dict[chave] = valor;                    // add ou update
dict.TryGetValue(chave, out var v);     // safe get
dict.ContainsKey(chave);
dict.Remove(chave);
dict.Keys, dict.Values, dict.Count

// LINQ úteis
dict.Values.Sum();
dict.Select(kv => $"{kv.Key}: {kv.Value:C}");
dict.Where(kv => kv.Value > 10);

// Arquivo assíncrono
await File.WriteAllLinesAsync("file.txt", linhas);
await File.AppendAllTextAsync("log.txt", texto + "\n");

// Nullables
double? preco = dict.TryGetValue("item", out var p) ? p : null;
double precoOuZero = preco ?? 0;
```

**Boas práticas destacadas**
- Sempre usar `readonly` em campos que não mudam após construtor
- Preferir `double?` quando o valor pode não existir
- Usar `TryGetValue` em vez de `ContainsKey` + indexador (mais eficiente)
- Evitar fire-and-forget em métodos `async` no `Main`
- Considerar `StringComparer.OrdinalIgnoreCase` para chaves case-insensitive