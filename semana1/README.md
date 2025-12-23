# Curiosidades 

## 🔹 O que é `Main` em C#?

👉 **`Main` é o ponto de entrada do programa.**

É o **primeiro código que o .NET executa** quando você roda a aplicação.

---


# Semana 1 - Exemplos Básicos em C#

Este projeto demonstra conceitos fundamentais da linguagem C# usando exemplos práticos no arquivo `Program.cs`.

---

## Conteúdo do Código

### 1. Saída no Console

```csharp
Console.WriteLine("Hello, World!");
```
Exibe uma mensagem simples no console.

---

### 2. Tipos de Variáveis

- **Tipo explícito:**
    ```csharp
    int numero = 10;
    ```
- **Tipo implícito:**
    ```csharp
    var texto = "O número é ";
    ```

---

### 3. Estruturas de Decisão

- **if / else:**
    ```csharp
    if (numero == 10)
    {
            Console.WriteLine(texto + numero);
    }
    else
    {
            Console.WriteLine("Número diferente de 10");
    }
    ```

- **switch case:**
    ```csharp
    int dia = 4;
    switch(dia)
    {
            case 1:
                    Console.WriteLine("Segunda-feira");
                    break;
            case 2:
                    Console.WriteLine("Terça-feira");
                    break;
            case 3:
                    Console.WriteLine("Quarta-feira");
                    break;
            case 4:
                    Console.WriteLine("Quinta-feira");
                    break;
            case 5:
                    Console.WriteLine("Sexta-feira");
                    break;
            case 6:
                    Console.WriteLine("Sábado");
                    break;
            case 7:
                    Console.WriteLine("Domingo");
                    break;
            default:
                    Console.WriteLine("Dia inválido");
                    break;
    }
    ```

---

### 4. Estruturas de Repetição

- **for (incrementando +1):**
    ```csharp
    for (int i = 0; i < 5; i++)
    {
            Console.WriteLine(i);
    }
    ```

- **for (incrementando +2):**
    ```csharp
    for (int i = 0; i <= 10; i = i + 2)
    {
            Console.WriteLine(i);
    }
    ```

- **foreach (percorrendo array):**
    ```csharp
    string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
    foreach (string i in cars)
    {
            Console.WriteLine(i);
    }
    ```

---

## Resumo

O arquivo `Program.cs` apresenta exemplos de:

- Declaração de variáveis (explícita e implícita)
- Estruturas condicionais (`if/else`, `switch`)
- Estruturas de repetição (`for`, `foreach`)
- Manipulação de arrays
- Impressão de dados no console

Esses conceitos são essenciais para quem está começando a programar em C#.
---
