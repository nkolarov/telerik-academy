using System;
using System.Text;
using System.Collections.Generic;

namespace Zoo
{
    public class Animal : ISound
    {
        //Fields
        private int age;
        private string name;
        private string sex;

        //Properties
        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                if (value != "male")
                {
                    if (value != "female")
                    {
                        throw new ArgumentOutOfRangeException("Sex must be male OR female!");
                    }
                }
                this.sex = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative!");
                }
                this.age = value;
            }
        }

        //Contructor
        public Animal(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        //Methods
        public virtual void SayHi()
        {
            Console.WriteLine("I am: " + this.GetType());
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name: " + this.Name);
            result.AppendFormat("\nAge: " + this.Age);
            result.AppendFormat("\nSex: " + this.Sex);
            return result.ToString();
        }

        public static Dictionary<string, double> CalculateAverageAge(List<Animal> animals)
        {
            //Sum ages
            Dictionary<string, double> ages = new Dictionary<string, double>();
            //Count Animals
            Dictionary<string, double> animalCounters = new Dictionary<string, double>();
            //Calculate Average
            Dictionary<string, double> result = new Dictionary<string, double>();

            foreach (var animal in animals)
            {
                string key = animal.GetType().ToString();
                if (!ages.ContainsKey(key))
                {
                    //Initialize Animal
                    ages.Add(key, animal.Age);
                    //Initialize count
                    animalCounters.Add(key, 1);
                }
                else
                {
                    //Add age
                    ages[key] = ages[key] + animal.Age;
                    //Increment count
                    animalCounters[key]++;
                }
            }

            //Find average and save to result
            foreach (var animal in ages)
            {
                //Calculate average age
                result.Add(animal.Key, (animal.Value / animalCounters[animal.Key]));
            }

            return result;
        }

        public static void PrintAverageAge(List<Animal> animals)
        {
            foreach (var animal in CalculateAverageAge(animals))
            {
                Console.WriteLine("Type: {0} | Average Age: {1}", animal.Key.ToString().PadRight(10), animal.Value);
            }
        }
    }
}