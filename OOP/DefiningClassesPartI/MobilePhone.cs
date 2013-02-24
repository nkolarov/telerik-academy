using System;

class MobilePhone
{
    static void Main()
    {
        GSM iPhone = new GSM("iPhone4s", "Apple");

        Console.WriteLine(iPhone.ToString());
    }

}