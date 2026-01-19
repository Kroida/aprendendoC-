### 📌 Mapa Geral do que foi Estudado em C#

| Semana / Bloco              | Principais Tópicos Estudados                                                                 | Nível Aproximado |
|-----------------------------|-----------------------------------------------------------------------------------------------|------------------|
| Básico – Semana 1           | Sintaxe inicial, variáveis, condicionais, repetições, arrays, console                        | Iniciante        |
| Coleções + LINQ + Exceções  | List<T>, Dictionary, foreach, LINQ (Where/Select), try/catch                                 | Iniciante/Intermediário |
| Interfaces e Polimorfismo   | Definição e uso de interfaces, múltipla implementação, polimorfismo via interface            | Intermediário    |
| async / await + Task        | Modelo assíncrono, IO assíncrono vs paralelismo, Task, WhenAll/WhenAny, erros comuns         | Intermediário    |
| Boas práticas & Semântica   | class × record × struct, mutabilidade/imutabilidade, init, readonly, ref/out/in, semântica   | Intermediário    |

---

### 1. Fundamentos Básicos (Semana 1)

- Ponto de entrada: `static void Main()` (ou variações modernas `Top-level statements`)
- Saída no console: `Console.WriteLine()`
- Declaração de variáveis:
  - Explícita: `int idade = 25;`
  - Implícita com `var`: `var nome = "Kroida";`
- Estruturas de decisão:
  - `if / else`
  - `switch` (com `case`, `break`, `default`)
- Estruturas de repetição:
  - `for` (contador simples e com incremento personalizado)
  - `foreach` (ideal para coleções e arrays)
- Arrays simples: `string[] cars = { ... };`

---

### 2. Coleções Genéricas + LINQ + Tratamento de Erros

**List<T>**
- Lista dinâmica e ordenada
- Métodos principais: `.Add()`, `.Remove()`, `.Clear()`
- Percorrimento comum: `foreach`

**Dictionary<TKey, TValue>**
- Mapeamento chave → valor
- Acesso rápido via hash
- Métodos seguros: `.TryGetValue(key, out var valor)`
- Inicialização com collection initializer

**LINQ básico**
- Namespace: `System.Linq`
- Execução tardia (lazy evaluation)
- Operadores mais usados:
  - `.Where()` → filtro
  - `.Select()` → projeção / transformação
  - `.ToList()` → materialização
- Exemplo clássico:
  ```csharp
  var paresDobrados = numeros
      .Where(n => n % 2 == 0)
      .Select(n => n * 2)
      .ToList();
  ```

**Tratamento de exceções**
- Bloco `try / catch`
- Captura específica: `catch (FormatException)`, `catch (OverflowException)`
- Regra: capturar exceções específicas, nunca usar exceções para controle de fluxo normal

---

### 3. Interfaces e Polimorfismo

- Interface = **contrato** (só declara métodos, sem implementação)
- Uma classe pode implementar **múltiplas interfaces**
- Polimorfismo via interface:
  ```csharp
  IVehicle veiculo = new VehicleStore();
  veiculo.VehicleSound();
  ```
- Vantagem principal: **desacoplamento** (código depende de abstração, não de implementação concreta)
- Boas práticas observadas:
  - Interfaces pequenas e coesas
  - Responsabilidades bem separadas
  - Evitar lógica complexa dentro de interfaces

---

### 4. Programação Assíncrona (async / await)

**Conceitos centrais**
- `async` + `await` → **esperar sem bloquear** a thread
- Foco principal: **IO assíncrono** (arquivo, HTTP, banco de dados)
- **NÃO** é paralelismo por padrão

**Task e Task<T>**
- `Task` = promessa de trabalho futuro
- `Task.Run()` → para trabalho **CPU-bound** (paralelismo real)
- Retornos recomendados:
  - `async Task`     → sem retorno
  - `async Task<T>`  → com retorno
  - `async void`     → **apenas** eventos (evitar sempre que possível)

**Padrões importantes**
```csharp
string texto = await File.ReadAllTextAsync("dados.txt");
string html  = await httpClient.GetStringAsync(url);
await Task.WhenAll(tarefa1, tarefa2, tarefa3);
```

**Erros comuns que você aprendeu a evitar**
- Usar `.Result` / `.Wait()` → deadlock em contextos com SynchronizationContext
- Usar `Task.Run` para operações de IO
- Esquecer `await`
- Usar `async void` em métodos normais

---

### 5. Semântica, Imutabilidade e Boas Práticas Modernas

**Escolha de tipo**

| Tipo     | Quando usar                                      | Igualdade padrão     | Mutabilidade padrão |
|--------|--------------------------------------------------|----------------------|----------------------|
| `class`  | Entidades, identidade, comportamento rico       | Por referência       | Mutável             |
| `record` | DTOs, Value Objects, dados imutáveis             | Por valor            | Imutável            |
| `struct` | Dados pequenos, performance crítica, sem identidade | Por valor         | Mutável (cuidado)   |

**Imutabilidade (prioridade alta nos estudos)**

- `record` → imutável por padrão + sintaxe `with`
- `init`-only properties (C# 9+)
- Campos `readonly`
- Vantagens: segurança, previsibilidade, thread-safety, testes mais fáceis

**Passagem de parâmetros**
- `ref` → modifica original (precisa estar inicializado)
- `out` → retorna valor (não precisa inicializar)
- `in` → passagem por referência somente leitura (performance + segurança)

---

### Resumo Final – O que você já internalizou

Você já estudou e comparou:

- Código **síncrono vs assíncrono**
- **IO assíncrono** vs **paralelismo CPU**
- **Abstração via interface** vs implementação concreta
- **Coleções** mais usadas no dia a dia
- **LINQ** como forma declarativa de trabalhar com dados
- Diferença semântica profunda entre `class`, `record` e `struct`
- Importância da **imutabilidade** e como implementá-la
- Tratamento seguro de exceções
- Evitar armadilhas clássicas de async (deadlock, async void, .Result)