using System;

namespace Zoo
{
    class Tomcat : Cat
    {
        //Contructors
        public Tomcat(string name, int age) : base(name, age, "male")
        {
        }

        //Methods
        public override void SayHi()
        {
            Console.WriteLine("Miauuiii, Miauuiii, Miauuiii....");
        }
    }
}