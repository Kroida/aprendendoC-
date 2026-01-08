## 1️⃣ Interface como Contrato de Comportamento

### O que é  
Uma **interface** define **o que uma classe deve fazer**, sem definir **como**.

### Para que serve  
Permitir que diferentes implementações sejam usadas de forma intercambiável, sem alterar o código que as consome.

```csharp
interface INotificador
{
    void Notificar(string mensagem);
}
```

📌 A interface:

* Não tem estado
* Não tem lógica
* Define apenas o **contrato**

---

## 2️⃣ Implementações Concretas da Interface

Duas classes diferentes **cumprindo o mesmo contrato**, cada uma com seu comportamento específico.

```csharp
class EmailNotificator : INotificador
{
    public void Notificar(string mensagem)
    {
        Console.WriteLine($"Email: {mensagem}");
    }
}
```

```csharp
class SmsNotificator : INotificador
{
    public void Notificar(string mensagem)
    {
        Console.WriteLine($"SMS: {mensagem}");
    }
}
```

### 🧠 Conceito central:

> **Mesmo método, comportamentos diferentes**

---

## 3️⃣ Abstração de Serviço (`AlertService`)

### O que é

Uma classe que **depende da interface**, não da implementação concreta.

```csharp
class AlertService
{
    private readonly INotificador _notificador;

    public AlertService(INotificador notificador)
    {
        _notificador = notificador;
    }

    public void Enviar(string mensagem)
    {
        _notificador.Notificar(mensagem);
    }
}
```

### Para que serve

* Centralizar regras de negócio
* Permitir crescimento sem modificar código existente
* Desacoplar o serviço da implementação concreta

📌 Aqui ocorre **Injeção de Dependência via construtor**.

---

## 4️⃣ Fluxo de Execução no `Main`

```csharp
INotificador email = new EmailNotificator();
var alertaEmail = new AlertService(email);
alertaEmail.Enviar("Olá por email");

INotificador sms = new SmsNotificator();
var alertaSms = new AlertService(sms);
alertaSms.Enviar("Olá por SMS");
```

### Fluxo mental

```
Main
 └─ cria implementação concreta
     └─ injeta no AlertService
         └─ chama Enviar()
             └─ executa Notificar()
```

* 🧠 O `AlertService` **não sabe** se é email ou SMS.

---

## 5️⃣ Por que isso parece redundante (e está tudo bem)

Para um console app pequeno, **realmente é redundante**:

```csharp
new EmailNotificator().Notificar("Olá");
```

vs

```csharp
new AlertService(new EmailNotificator()).Enviar("Olá");
```

⚠️ Nenhum ganho visível **agora**.

📌 Importante:

> Interfaces **não existem para código pequeno**
> Elas existem para **código que muda**

---

## 6️⃣ Problema Real que Esse Padrão Resolve

Quando surgem novos requisitos:

* WhatsApp
* Push
* Log em banco
* Múltiplos canais
* Testes sem envio real

### Sem interface ❌

```csharp
if (tipo == "email") ...
else if (tipo == "sms") ...
```

### Com interface ✅

```csharp
class WhatsAppNotificator : INotificador
{
    public void Notificar(string mensagem) { }
}
```

* 📌 Nenhuma mudança no `AlertService`.

---

## 7️⃣ Boas Práticas Evidentes no Código

* 📌 Dependência por abstração
* 📌 Construtor explícito
* 📌 Classes com responsabilidade única
* 📌 Código aberto para extensão, fechado para modificação

---

## ⚠️ Quando NÃO usar Interface

Não use quando:

* Código pequeno
* Script simples
* Não há variação
* Não há expectativa de crescimento

👉 Neste exemplo, o uso é **didático**, não prático.

---

## 8️⃣ Diagrama Mental

```
        INotificador
        /           \
EmailNotificator   SmsNotificator
        \           /
         AlertService
                |
              Main
```

---

## 9️⃣ Cheat-Sheet Rápido

```csharp
// Interface
interface IExample
{
    void Do();
}

// Implementação
class Example : IExample
{
    public void Do() { }
}

// Injeção
var service = new Service(new Example());
```

---

## 🔟 Regra de Ouro

```
Código pequeno → simples
Código que muda → interface
Código que cresce → abstração
```