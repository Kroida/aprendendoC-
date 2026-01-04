## 1️⃣ 🔢 Processamento de listas com LINQ

### 🎯 Objetivo do exercício

A partir de uma lista de números:

* Filtrar apenas valores **maiores que 10**
* Transformar os valores (multiplicar por 2)
* Exibir o resultado

### 📌 Código-base

```csharp
var numeros = new List<int> { 7, 12, 3, 2, 41, 50, 100, 80, 5 };

var resultado = numeros
    .Where(n => n > 10)
    .Select(n => n * 2);

foreach (var n in resultado)
{
    Console.WriteLine(n);
}
```

---

### 🧠 Conceitos centrais

#### `Where`

* **Função:** filtrar elementos
* **Critério:** expressão booleana (`true` mantém, `false` descarta)

```csharp
.Where(n => n > 10)
```

📌 Mantém apenas números maiores que 10.

---

#### `Select`

* **Função:** transformar cada elemento
* **Resultado:** nova projeção dos dados

```csharp
.Select(n => n * 2)
```

📌 Multiplica cada número filtrado por 2.

---

### ⚙️ Fluxo de execução (mental)

```
Lista original
   ↓
Where (filtra)
   ↓
Select (transforma)
   ↓
foreach (executa)
```

⚠️ LINQ usa **execução tardia (deferred execution)**: nada acontece até a enumeração (`foreach`).

---

### 📋 Observações práticas

* LINQ **não modifica** a lista original
* `Where` sempre vem antes de `Select` quando o filtro depende do valor original
* Para materializar o resultado imediatamente, use `.ToList()`

---

## 2️⃣ 📚 Uso de `Dictionary<TKey, TValue>`

### 🎯 Objetivo do exercício

* Armazenar alunos e notas
* Buscar um aluno pelo nome
* Tratar o caso de aluno inexistente

---

### 📌 Código-base

```csharp
var alunos = new Dictionary<string, double>
{
    ["João"] = 6,
    ["Maria"] = 4,
    ["Enzo"] = 8
};

Console.Write("Digite o nome do aluno: ");
var entrada = Console.ReadLine();

Console.WriteLine("Buscando aluno...");
```

---

### 🔍 Acesso ao valor por chave

#### Forma direta (exige garantia)

```csharp
var nota = alunos[entrada];
```

⚠️ Lança `KeyNotFoundException` se a chave não existir.

---

#### Forma segura (recomendada)

```csharp
if (alunos.TryGetValue(entrada, out var nota))
{
    Console.WriteLine($"Aluno: {entrada}, nota: {nota}");
}
else
{
    Console.WriteLine("Aluno não encontrado.");
}
```

🧠 `TryGetValue`:

* Retorna `bool`
* Evita exceções
* É o padrão profissional para leitura de `Dictionary`

---

### ❌ Padrão a evitar (presente no código original)

```csharp
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
```

⚠️ Problemas:

* `foreach` desnecessário
* `ContainsKey` + indexador → dupla consulta
* Fluxo confuso

📌 O `Dictionary` **não precisa ser percorrido** para buscar uma chave.

---

## 3️⃣ 🧠 Modelos mentais importantes

### LINQ

```
Where  → decide SE entra
Select → decide COMO fica
```

### Dictionary

```
Chave existe? → TryGetValue
Valor garantido? → [key]
```

---

## 4️⃣ 📑 Cheat-sheet rápido

### LINQ

| Operação    | Método                |
| ----------- | --------------------- |
| Filtrar     | `Where`               |
| Transformar | `Select`              |
| Executar    | `foreach`, `ToList()` |

### Dictionary

| Situação             | Método        |
| -------------------- | ------------- |
| Buscar chave         | `TryGetValue` |
| Verificar existência | `ContainsKey` |
| Acesso direto        | `[key]`       |
