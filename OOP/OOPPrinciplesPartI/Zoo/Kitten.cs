using System;

namespace Zoo
{
    class Kitten : Cat
    {
        //Contructors
        public Kitten(string name, int age) : base(name, age, "female")
        {
        }

        //Methods
        public override void SayHi()
        {
            Console.WriteLine("Myrrrr...");
        }
    }
}