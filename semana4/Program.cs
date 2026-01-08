// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;

/* ========== Uma interface ========== */
public interface IAnimal
{
    void AnimalSound();
}

class Pig : IAnimal
{
    public void AnimalSound()
    {
        Console.WriteLine("The pig says awe awe awe");
    }
}

/* ========== Múltiplas interfaces ========== */
public interface IVehicle
{
    void VehicleSound();
}

public interface ICatch
{
    string ObterVehicle(string vehicle);
}

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
            // condição ? se_sim : se_não
            ? $"{vehicle} custa {valor}"
            : "Veículo não encontrado";
    }

    public void VehicleSound()
    {
        Console.WriteLine("Vruuum!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IVehicle car = new VehicleStore();
        ICatch vehicle = new VehicleStore();
        car.VehicleSound();
        Console.WriteLine(vehicle.ObterVehicle("McLaren"));
    }
}