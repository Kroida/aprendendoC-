# 📘 C# Console – Coleções, LINQ e Tratamento de Erros

> **Objetivo:** resumo didático para aprendizado rápido, revisão e uso como *cheat-sheet* no Notion
> **Público:** iniciantes em C#
> **Base:** arquivo `Program.cs`

---

## 1️⃣ List<T> — Lista Genérica

### 🔹 O que é?

`List<T>` é uma **coleção dinâmica**:

* Armazena vários valores do **mesmo tipo**
* Cresce ou diminui automaticamente
* Mantém **ordem dos elementos**

📦 Namespace: `System.Collections.Generic`

---

### ✍️ Exemplo prático

```csharp
var nomes = new List<string> { "Luís", "Gustavo", "Neopomoceno" };
```

📌 Aqui criamos uma lista de `string` já com valores iniciais.

---

### ➕ Adicionando elementos

```csharp
nomes.Add("Da Silva");
```

* Insere o valor **no final da lista**

---

### ➖ Removendo elementos

```csharp
nomes.Remove("Gustavo");
```

* Remove a **primeira ocorrência** do valor informado

---

### 🔁 Percorrendo a lista (`foreach`)

```csharp
foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}
```

🧠 O `foreach`:

* Itera automaticamente sobre a coleção
* Evita erros comuns de índice
* É ideal quando **não precisamos do índice**

---

## 2️⃣ Dictionary<TKey, TValue> — Dicionário

### 🔹 O que é?

`Dictionary<TKey, TValue>` armazena **pares chave → valor**.

| Conceito         | Significado         |
| ---------------- | ------------------- |
| Chave (`TKey`)   | Identificador único |
| Valor (`TValue`) | Dado associado      |

📌 Acesso rápido (baseado em hash)

---

### ✍️ Criando um Dictionary

```csharp
var usuarios = new Dictionary<int, string>
{
    [1] = "Maria",
    [2] = "João",
    [3] = "Gustanuk"
};
```

📌 Cada número (`int`) aponta para um nome (`string`).

---

### ➕ Adicionando novo par

```csharp
usuarios[4] = "Xandão";
```

* Se a chave **não existir**, ela é criada
* Se existir, o valor é sobrescrito

---

### 🔍 Buscando valores com segurança

```csharp
if (usuarios.TryGetValue(2, out var name))
{
    Console.WriteLine(name);
}
```

🧠 Por que usar `TryGetValue`?

* Evita exceções (`KeyNotFoundException`)
* Retorna `true` ou `false`
* Código mais seguro e legível

---

## 3️⃣ LINQ — Language Integrated Query

### 🔹 O que é LINQ?

LINQ permite **consultar coleções** usando uma sintaxe expressiva e funcional.

💡 Ideal para:

* Filtrar dados
* Transformar coleções
* Escrever código mais declarativo

📦 Namespace: `System.Linq`

---

### ✍️ Coleção base

```csharp
var numeros = new List<int> { 1, 2, 3, 4, 5, 6 };
```

---

### 🔎 Filtrando com `Where`

```csharp
.Where(n => n % 2 == 0)
```

📌 Significado:

* `n` → cada elemento da lista
* `=>` → expressão lambda
* `n % 2 == 0` → condição (número par)

---

### 🔄 Transformando com `Select`

```csharp
.Select(n => n * 10)
```

📌 Cada número par é multiplicado por 10.

---

### 🧩 LINQ completo

```csharp
var pares = numeros
    .Where(n => n % 2 == 0)
    .Select(n => n * 10);
```

🧠 Importante:

* LINQ usa **execução tardia** (*lazy execution*)
* Nada é executado até alguém **iterar** sobre o resultado

---

### 🔁 Executando a consulta

```csharp
foreach (var n in pares)
{
    Console.WriteLine(n);
}
```

---

### 💾 Materializando o resultado

```csharp
var resultado = pares.ToList();
```

📌 Converte o resultado em uma nova lista concreta.

---

## 4️⃣ Tratamento de Erros — `try / catch`

### 🔹 O que é?

Tratamento de exceções serve para **lidar com erros inesperados** sem quebrar o programa.

---

### ✍️ Exemplo base

```csharp
string texto = "123";

try
{
    var valor = int.Parse(texto);
}
```

📌 `int.Parse` pode lançar exceções.

---

### ❌ Erro de formato

```csharp
catch (FormatException)
{
    Console.WriteLine("Formato inválido!");
}
```

📌 Ocorre quando a string **não representa um número válido**.

---

### ❌ Erro de estouro

```csharp
catch (OverflowException)
{
    Console.WriteLine("Número fora do limite!");
}
```

📌 Ocorre quando o número é **maior ou menor que o limite do tipo `int`**.

---

### 🧠 Boas práticas

* Use exceções para **situações excepcionais**, não para controle de fluxo
* Capture exceções **específicas**
* Mensagens claras ajudam na depuração

---

## 5️⃣ Fluxo geral do programa 🔄

```text
Início
 ├─ Criar List
 ├─ Manipular List
 ├─ Criar Dictionary
 ├─ Buscar dados com segurança
 ├─ Aplicar LINQ
 ├─ Executar consulta
 ├─ Tratar exceções
Fim
```

---

## 6️⃣ Resumo rápido (cheat-sheet) ⚡

| Conceito                  | Para que serve              |
| ------------------------- | --------------------------- |
| `List<T>`                 | Lista dinâmica ordenada     |
| `Dictionary<TKey,TValue>` | Mapeamento chave → valor    |
| `foreach`                 | Percorrer coleções          |
| `LINQ`                    | Filtrar e transformar dados |
| `Where`                   | Filtrar elementos           |
| `Select`                  | Transformar elementos       |
| `try/catch`               | Tratar erros                |