## 1️⃣ O que é uma Interface (no contexto do código)

Uma **interface** define **quais métodos uma classe é obrigada a implementar**, sem dizer *como*.

📌 No código, a interface é usada para **padronizar comportamentos** entre classes diferentes.

```csharp
public interface IAnimal
{
    void AnimalSound();
}
```

🧠 A interface **não executa lógica** e **não armazena estado** — apenas declara métodos.

---

## 2️⃣ Interface + Classe (implementação direta)

A classe **assume o compromisso** de implementar todos os métodos da interface.

```csharp
class Pig : IAnimal
{
    public void AnimalSound()
    {
        Console.WriteLine("The pig says awe awe awe");
    }
}
```

📌 Se a classe **não implementar todos os métodos**, o código **não compila**.

Fluxo mental:

```
Interface → regra
Classe → implementação da regra
```

---

## 3️⃣ Múltiplas Interfaces (caso mais comum na prática)

Uma classe pode implementar **mais de uma interface**, agregando responsabilidades diferentes.

### Interfaces declaradas

```csharp
public interface IVehicle
{
    void VehicleSound();
}

public interface ICatch
{
    string ObterVehicle(string vehicle);
}
```

📌 Cada interface tem **um papel claro**:

| Interface  | Responsabilidade          |
| ---------- | ------------------------- |
| `IVehicle` | Comportamento do veículo  |
| `ICatch`   | Consulta/retorno de dados |

---

## 4️⃣ Classe implementando múltiplas interfaces

```csharp
public class VehicleStore : IVehicle, ICatch
{
    private readonly Dictionary<string, double> _vehicles = new()
    {
        ["McLaren"] = 10000,
        ["Kawasaki"] = 6000
    };

    public string ObterVehicle(string vehicle)
    {
        return _vehicles.TryGetValue(vehicle, out var valor)
            ? $"{vehicle} custa {valor}"
            : "Veículo não encontrado";
    }

    public void VehicleSound()
    {
        Console.WriteLine("Vruuum!");
    }
}
```

🧠 Pontos importantes:

* A classe **cumpre todos os contratos**
* Cada método vem de uma interface diferente
* A classe mantém **estado interno** (`Dictionary`)

---

## 5️⃣ Estrutura de dados usada (`Dictionary`)

```csharp
private readonly Dictionary<string, double> _vehicles
```

📌 Usado para **associar nome do veículo ao preço**.

Vantagens nesse cenário:

* Busca rápida por chave
* Código simples
* Leitura clara

---

## 6️⃣ Fluxo de execução do método `ObterVehicle`

```csharp
_vehicles.TryGetValue(vehicle, out var valor)
    ? "existe"
    : "não existe"
```

Fluxo lógico:

```
Recebe nome → procura no Dictionary
        ↓
Se existir → retorna preço
Se não → mensagem de erro
```

📌 Uso de **operador ternário** deixa o código mais enxuto.

---

## 7️⃣ Uso de interface no `Main` (parte mais importante)

```csharp
IVehicle car = new VehicleStore();
ICatch vehicle = new VehicleStore();
```

🧠 Aqui acontece o **polimorfismo via interface**:

* A variável conhece **só o contrato**
* Não conhece a implementação concreta

```csharp
car.VehicleSound();
Console.WriteLine(vehicle.ObterVehicle("McLaren"));
```

📌 O código depende da **interface**, não da classe.

---

## 8️⃣ Diagrama mental do relacionamento

```
        IVehicle        ICatch
            ↑             ↑
            └──── VehicleStore ────┐
                                   ↓
                              Dictionary
```

---

## 9️⃣ Boas práticas observadas

* 📌 Interfaces pequenas e coesas
* 📌 Responsabilidades bem separadas
* 📌 Uso correto de `readonly`
* 📌 Lógica simples e legível

---

## ⚠️ Erros comuns (evitados no código)

* ❌ Interface com atributos
* ❌ Interface com lógica complexa
* ❌ Classe gigante com múltiplas responsabilidades

---

## 🔟 Cheat‑sheet rápido

```csharp
// Interface
public interface IExample
{
    void DoSomething();
}

// Implementação
public class Example : IExample
{
    public void DoSomething() { }
}

// Uso
IExample ex = new Example();
```

---

## 🧠 Regra de ouro

> **Interface define o que existe.**
> **Classe define como funciona.**
