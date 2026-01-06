// See https://aka.ms/new-console-template for more information
/* ========== Uma interface ========== */
using System;
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
