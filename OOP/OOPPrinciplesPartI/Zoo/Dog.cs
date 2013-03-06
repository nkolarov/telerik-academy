using System;

namespace Zoo
{
    class Dog:Animal
    {
        //Contructors
        public Dog(string name, int age, string sex)
            : base(name, age, sex)
        {
        }

        //Methods
        public override void SayHi()
        {
            Console.WriteLine("Bau, Bau, Bau ....");
        }
    }
}
