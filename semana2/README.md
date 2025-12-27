# 📘 Resumo Didático: Organização, Semântica, Imutabilidade e Boas Práticas em C#

Este documento sintetiza os principais conceitos sobre **organização de código, tipos, mutabilidade/imutabilidade e semântica** em C#, com foco em **boas práticas de engenharia de software, clareza arquitetural e prevenção de bugs**.

---

## 🗂 Organização e Estrutura do Código

Em C#, o código é organizado em **tipos** (`class`, `record`, `struct`) e **métodos**.
O ponto de entrada da aplicação é o método `Main`.

Boas práticas:

* Separar responsabilidades em diferentes classes
* Um tipo principal por arquivo
* Nomes claros, semânticos e consistentes
* Evitar lógica de negócio no `Main`
* Modelar tipos de acordo com **intenção**, não apenas conveniência

---

## 🧱 Tipos Fundamentais

### 🔹 `class`

`class` é um **tipo por referência**, usado quando **identidade, comportamento e ciclo de vida** importam.

É indicada para:

* Entidades de domínio
* Objetos com estado mutável
* Classes com regras de negócio
* Integração com ORMs (ex: Entity Framework)

```csharp
class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}
```

✔️ Suporta herança, polimorfismo e encapsulamento
❌ Comparação padrão é por referência
❌ Pode gerar efeitos colaterais se mal controlada

---

### 🔹 `record`

`record` é um tipo voltado para **dados e significado**, introduzido para facilitar modelos imutáveis.

Características:

* Igualdade por valor
* Imutabilidade por padrão
* Menos código boilerplate
* Excelente para DTOs e Value Objects

```csharp
public record Produto(string Nome, decimal Preco);
```

📌 **Regra de ouro**:

> Se dois objetos com os mesmos dados devem ser considerados iguais → use `record`
> Se identidade e comportamento importam → use `class`

---

### 🔹 `struct`

`struct` é um **tipo por valor**, copiado ao ser atribuído ou passado como parâmetro.

Indicado para:

* Dados pequenos
* Estruturas simples
* Tipos sem identidade
* Uso intensivo em performance

```csharp
struct Ponto
{
    public int X;
    public int Y;
}
```

✔️ Evita alocação no heap
❌ Pode gerar custo de cópia se for grande ou complexo

---

## 🔒 Mutabilidade e Imutabilidade

Imutabilidade significa que **o estado do objeto não pode ser alterado após sua criação**.
Isso aumenta:

* Segurança
* Previsibilidade
* Facilidade de testes
* Confiabilidade em ambientes concorrentes

---

### ❌ Exemplo de objeto mutável (`set`)

```csharp
class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

var p = new Produto { Nome = "Teclado", Preco = 200 };
p.Preco = 100; // estado alterado em qualquer momento
```

⚠️ `set` permite alteração **a qualquer momento**, o que pode violar invariantes do sistema.

---

### ✅ Imutabilidade com `record`

```csharp
public record Produto(string Nome, decimal Preco);

var p1 = new Produto("Teclado", 200);
var p2 = p1 with { Preco = 100 }; // novo objeto
```

✔️ Nenhum estado é modificado
✔️ Ideal para dados, eventos, mensagens e DTOs

---

### ✅ Imutabilidade com `class` + `init`

O modificador `init` permite atribuição **somente durante a criação do objeto**.

```csharp
class Produto
{
    public string Nome { get; init; }
    public decimal Preco { get; init; }
}
```

Uso:

```csharp
var p = new Produto
{
    Nome = "Teclado",
    Preco = 200
};

// p.Preco = 100; ❌ erro de compilação
```

📌 `init` é ideal quando:

* Você quer usar `class`
* Precisa de object initializers
* Deseja impedir alterações após a construção

---

### 🔁 Diferença semântica entre `set` e `init`

| Aspecto             | `set`              | `init`                  |
| ------------------- | ------------------ | ----------------------- |
| Quando pode alterar | A qualquer momento | Apenas na criação       |
| Mutabilidade        | Total              | Controlada              |
| Segurança de estado | Menor              | Maior                   |
| Ideal para          | Entidades mutáveis | DTOs, configs, comandos |
| Introduzido em      | Versões antigas    | C# 9+                   |

---

### ✅ Campos `readonly`

Outra forma de garantir imutabilidade é usando campos `readonly`.

```csharp
class Produto
{
    public readonly string Nome;
    public readonly decimal Preco;

    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}
```

✔️ Forte garantia de imutabilidade
❌ Menos flexível que `init`

---

📌 **Quando preferir imutabilidade**:

* DTOs
* Value Objects
* Configurações
* Eventos
* Retornos de API
* Dados compartilhados

---

## 🔁 Tipos por Valor vs Tipos por Referência

### 🟦 Tipos por Valor

`int`, `double`, `bool`, `struct`, `enum`

São **copiados** ao serem atribuídos.

```csharp
int a = 10;
int b = a;
b = 20; // a permanece 10
```

---

### 🟧 Tipos por Referência

`class`, `record`, `array`, `object`, `string`

Compartilham a **mesma referência na memória**.

```csharp
class Caixa { public int Valor; }

var c1 = new Caixa { Valor = 10 };
var c2 = c1;
c2.Valor = 20; // c1.Valor agora é 20
```

📌 **Nota importante**:
`string` é tipo por referência, mas **imutável**.

---

## 🔧 Passagem de Parâmetros (`ref`, `out`, `in`)

* **`ref`**: modifica a variável original (precisa estar inicializada)

```csharp
void Incrementar(ref int valor) { valor++; }
```

* **`out`**: usado para retornar múltiplos valores

```csharp
void ObterValores(out int x, out int y)
{
    x = 1;
    y = 2;
}
```

* **`in`**: passagem por referência somente leitura (performance + segurança)

```csharp
void Exibir(in int valor)
{
    Console.WriteLine(valor);
}
```

---

## 📌 Conclusão

* Use `class` para entidades com identidade e comportamento
* Use `record` para dados e value objects
* Prefira imutabilidade sempre que possível
* Use `init` quando quiser segurança sem perder flexibilidade
* Entender **valor vs referência** evita bugs sutis
* Semântica e intenção do modelo são tão importantes quanto sintaxe