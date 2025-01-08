using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using _2;

class Program
{
    public static void Main(string[] args) {

    List<Animal> animals = new List<Animal>();
    animals.Add(new Animal() { Name = "Hormiga", Color = "Rojo" });
    animals.Add(new Animal() { Name = "Lobo", Color = "Gris" });
    animals.Add(new Animal() { Name = "Elefante", Color = "Gris" });
    animals.Add(new Animal() { Name = "Pantegra", Color = "Negro" });
    animals.Add(new Animal() { Name = "Gato", Color = "Negro" });
    animals.Add(new Animal() { Name = "Iguana", Color = "Verde" });
    animals.Add(new Animal() { Name = "Sapo", Color = "Verde" });
    animals.Add(new Animal() { Name = "Camaleon", Color = "Verde" });
    animals.Add(new Animal() { Name = "Gallina", Color = "Blanco" });

    var query = new LinqAnimals{Animals = animals};
    
    PrintValues(query.QueryGreenColorAndStartsWithVowel());
    
    PrintValues(query.AnimalsOrderByName());

    PrintAnimalsGroupingByColor(query.AnimalsGroupByColor());
   
  }
  private static void PrintValues(List<Animal> animals)
    {
        Console.WriteLine("{0, -20} {1, 9}\n","NAME" ,"COLOR");
        animals.ToList().ForEach(p => Console.WriteLine("{0, -20} {1, 9}", 
                                        p.Name, p.Color));
    }

    private static void PrintAnimalsGroupingByColor(IEnumerable<IGrouping<string?, Animal>> group)
    {
        foreach(var itemGroup in group)
        {
          Console.WriteLine("--------------------------------");
          Console.WriteLine($"Color: {itemGroup.Key}");
          Console.WriteLine("--------------------------------");
          Console.WriteLine("NAME:");
          foreach(var item in itemGroup)
          {
            Console.WriteLine($"{item.Name}");
          }
        }
    }

  


}
