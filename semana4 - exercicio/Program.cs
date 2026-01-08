// See https://aka.ms/new-console-template for more information
interface INotificador
{
    void Notificar(string mensagem);
}

class EmailNotificator : INotificador
{
    public void Notificar(string mensagem)
    {
        Console.WriteLine($"Email: {mensagem}");
    }
}

class SmsNotificator : INotificador
{
    public void Notificar(string mensagem)
    {
        Console.WriteLine($"SMS: {mensagem}");
    }
}

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

class Program
{
    static void Main(string[] args)
    {
        INotificador email = new EmailNotificator();
        var alertaEmail = new AlertService(email);
        alertaEmail.Enviar("Olá por email");

        INotificador sms = new SmsNotificator();
        var alertaSms = new AlertService(sms);
        alertaSms.Enviar("Olá por SMS");
    }
}
