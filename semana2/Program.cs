// See https://aka.ms/new-console-template for more information

// Exemplo 1: definindo uma classe e criando objetos.
// class Book
// { 
//     static void Main(string[] args)
//     {
//         Book myObj = new Book();
//         Book myObj2 = new Book();
//         Console.WriteLine(myObj.tittle);
//         Console.WriteLine(myObj2.tittle);
//     }
// }

// Exemplo 2: definindo uma classe com field público, criando outra classe, instanciando um objeto e chamando tittle.
// class Book
// { 
//     public string tittle = "Aedra and Daedra";
// }
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         Book myObj = new Book();
//         Console.WriteLine(myObj.tittle);
//         myObj.price();
//     }
// }

// Exemplo 3: definindo class members de uma classe, criando outra classe, instanciando um objeto e chamando o método da classe.
// class Book
// {
//     string color = "yellow"; // field
//     string tittle = "Aedra and Daedra"; // field
//     int cost = 20;
//     public void price() // method
//     {
//         Console.WriteLine("The yellow book are on the lowest price.");
//     }
// }
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         Book myObj = new Book();
//         myObj.price();
//     }
// }

// Exemplo 4: Crindo uma classe com fields vazios, instanciando um objeto e modificando os fields em branco. Isso é útil quando se é necessário criar múltiplos objetos de uma classe.
class Book
{
    string color; // field
    string tittle; // field
    int cost;
    static void Main(string[] args)
    {
        Book book = new Book();
        book.color = "blue";
        book.tittle = "Mistery of Talara";
        book.cost = 50;
        Console.WriteLine(book.color);
        Console.WriteLine(book.tittle);
        Console.WriteLine(book.cost);
    }
}