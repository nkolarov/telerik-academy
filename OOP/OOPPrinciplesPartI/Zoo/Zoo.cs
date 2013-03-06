using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    class Zoo
    {
        static void Main()
        {
            //Initialize animals
            List<Animal> zoo = new List<Animal>()
            {
                new Animal("Buhlio", 2, "male"),
                new Animal("Gargamel", 5, "male"),
                new Tomcat("Lucky", 5),
                new Kitten("Mara",3),
                new Cat("Roshlio",4,"male"),
                new Frog("Jabcho",1,"male"),
                new Dog("Balkan",10,"male"),
                new Dog("Gosho",15,"male")
            };

            foreach (var animal in zoo)
            {
                //Use overrided methods
                Console.WriteLine(animal.ToString());
                animal.SayHi();
                Console.WriteLine();
            }
            
            //Calculate And Print Average Age
            Animal.PrintAverageAge(zoo);
        }
    }
}