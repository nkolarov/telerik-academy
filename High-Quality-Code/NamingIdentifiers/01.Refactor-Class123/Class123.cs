using System;

class Class123
{
    const int MaxCount = 6;

    class InClassClass123
    {
        public void ConvertToString(bool isStupidCode)
        {
            string isStupidCodeAsString = isStupidCode.ToString();
            Console.WriteLine(isStupidCodeAsString);
        }
    }


    static void Main(string[] args)
    {
        Class123.InClassClass123 instance = new Class123.InClassClass123();
        instance.ConvertToString(true);

    }
}