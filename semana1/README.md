## 🔹 O que é `Main` em C#?

👉 **`Main` é o ponto de entrada do programa.**

É o **primeiro código que o .NET executa** quando você roda a aplicação.

---

## 🔹 O que ele faz?

- Inicia o programa
- Diz ao runtime **por onde começar**
- Orquestra a execução (não faz o trabalho pesado)

---

## 🔹 Forma clássica

```csharp
static void Main(string[] args)
{
    Console.WriteLine("Olá!");
}

```

---

## 🔹 C# moderno (top-level statements)

```csharp
Console.WriteLine("Olá!");

```

✔️ O `Main` **existe**, mas o compilador cria automaticamente.

---

## 🔹 Regra de ouro

> Só existe um Main por aplicação
> 
> 
> **O `Main` coordena, não executa lógica complexa**
> 

---

## 🔹 Pense assim

```
Main = porta de entrada
Métodos = ações
Classes = organização

```

---

## 🔹 `var` vs tipo explícito em C#

### 📌 A verdade principal

> var NÃO é tipagem dinâmica
> 
> 
> O tipo é definido **em tempo de compilação**.
> 

---

## 🔹 Tipo explícito

```csharp
int idade = 30;

```

### ✔️ Vantagens

- Tipo visível imediatamente
- Melhor para quem está aprendendo
- Ajuda em APIs públicas

### ❌ Desvantagens

- Código mais verboso
- Pode repetir informação óbvia

---

## 🔹 `var`

```csharp
var idade = 30; // continua sendo int

```

### ✔️ Vantagens

- Código mais limpo
- Reduz redundância
- Excelente com LINQ

```csharp
var pares = numeros.Where(n => n % 2 == 0);

```

### ❌ Desvantagens

- Pode esconder o tipo
- Prejudica leitura se mal usado

---

## 🔹 Comparação direta

| Situação | Melhor escolha |
| --- | --- |
| Tipo óbvio (`new Cliente()`) | `var` |
| LINQ | `var` |
| Tipos primitivos isolados | tipo explícito |
| APIs públicas | tipo explícito |
| Tipo não óbvio | tipo explícito |

---

## 🔹 O que `var` NÃO faz

❌ Não torna o código dinâmico

❌ Não muda performance

❌ Não adia decisão de tipo

---

## 🔹 Regra de ouro (nível profissional)

> Use var quando o tipo é óbvio pela direita da atribuição.
> 
> 
> **Use tipo explícito quando a clareza ganha da concisão.**
> 

---

## 🔹 Mini-check mental

Pergunta rápida:

> Se eu remover o nome da variável, o tipo ainda fica claro?
> 
- ✔️ Sim → `var`
- ❌ Não → tipo explícito

---


Aqui vai um **resumo direto, limpo e profissional** sobre **estrutura de arquivos em projetos C#** — ideal pra Notion 👇

---

## 🧱 Estrutura de Arquivos em Projetos C#

### 🎯 Ideia central

> **Um projeto C# é composto por vários arquivos `.cs`, mas apenas um ponto de entrada.**

---

## 🚪 Ponto de entrada

* Toda aplicação C# possui **um único ponto de entrada**
* Esse ponto é o método **`Main`**
* No C# moderno, o `Main` pode estar **implícito** (top-level statements)

```csharp
// Program.cs
Console.WriteLine("Hello World");
```

📌 O compilador gera o `Main` automaticamente.

---

## 📂 Organização típica de arquivos

```
/Projeto
 ├── Program.cs        ← ponto de entrada
 ├── Models/
 │    └── Produto.cs
 ├── Services/
 │    └── PedidoService.cs
 ├── Infrastructure/
 │    └── Repositorio.cs
```

* `Program.cs`: inicialização da aplicação
* Outros arquivos `.cs`: **classes, métodos e tipos**
* Pastas ajudam na **separação de responsabilidades**

---

## ✅ O que é permitido

✔️ Vários arquivos `.cs` no mesmo projeto
✔️ Um único `Program.cs` executável
✔️ Classes espalhadas por arquivos diferentes
✔️ Organização por domínio ou camada

---

## ❌ O que não é permitido

❌ Dois arquivos com código executável direto
❌ Mais de um `Main` no mesmo projeto
❌ Lógica de negócio pesada dentro do `Program.cs`

---

## 🧠 Regra de ouro

```
Program.cs → coordena
Outros arquivos → executam o trabalho
```

---

## 🏗️ Boa prática profissional

* `Program.cs` deve ser **curto**
* Cada arquivo deve ter **uma responsabilidade clara**
* Um arquivo ≠ uma aplicação
* Um projeto = uma aplicação

---

## 📌 Pensamento de engenheiro

> Se eu trocar a interface (console → API),
> **meus arquivos continuam válidos?**

Se sim, a estrutura está correta ✅
