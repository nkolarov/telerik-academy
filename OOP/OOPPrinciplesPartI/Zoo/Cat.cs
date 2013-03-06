using System;

namespace Zoo
{
    class Cat : Animal
    {
        //Contructors
        public Cat(string name, int age, string sex) : base(name, age,sex)
        {
        }

        //Methods
        public override void SayHi()
        {
            Console.WriteLine("HHHHHhhhh....");
        }
    }
}