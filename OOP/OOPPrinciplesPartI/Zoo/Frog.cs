using System;

namespace Zoo
{
    class Frog:Animal
    {
        //Contructors
        public Frog(string name, int age, string sex)
            : base(name, age, sex)
        {
        }

        //Methods
        public override void SayHi()
        {
            Console.WriteLine("Rebbet, rebbet, rebbet ...");
        }
    }
}
