using System;
using System.Diagnostics;

class JustTest
{
    static void Main()
    {
        
        Stopwatch watch = new Stopwatch();

        // Addition
        Console.WriteLine("Addition:");
        watch.Restart();
        Addition.AddInt(0, 10000000, 2);
        watch.Stop();
        Console.WriteLine("Int: "+watch.ElapsedMilliseconds);

        watch.Restart();
        Addition.AddLong(0L, 10000000L, 2L);
        watch.Stop();
        Console.WriteLine("Long: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Addition.AddFloat(0f, 10000000f, 2f);
        watch.Stop();
        Console.WriteLine("Float: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Addition.AddDouble(0d, 10000000d, 2d);
        watch.Stop();
        Console.WriteLine("Double: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Addition.AddDecimal(0m, 10000000m, 2m);
        watch.Stop();
        Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);

        // Substraction
        Console.WriteLine("Substraction:");
        watch.Restart();
        Substraction.SubstractInt(10000000, 0, 2);
        watch.Stop();
        Console.WriteLine("Int: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Substraction.SubstractLong(10000000L, 0L, 2L);
        watch.Stop();
        Console.WriteLine("Long: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Substraction.SubstractFloat(10000000f, 0f, 2f);
        watch.Stop();
        Console.WriteLine("Float: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Substraction.SubstractDouble(10000000d, 0d, 2d);
        watch.Stop();
        Console.WriteLine("Double: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Substraction.SubstractDecimal(10000000m, 0m, 2m);
        watch.Stop();
        Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);


        // Multiplication
        Console.WriteLine("Multiplication:");
        watch.Restart();
        Mutltiplication.MultiplicateInt(1, 10000000, 2);
        watch.Stop();
        Console.WriteLine("Int: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Mutltiplication.MultiplicateLong(1L, 10000000L, 2L);
        watch.Stop();
        Console.WriteLine("Long: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Mutltiplication.MultiplicateFloat(1f, 10000000f, 2f);
        watch.Stop();
        Console.WriteLine("Float: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Mutltiplication.MultiplicateDouble(1d, 10000000d, 2d);
        watch.Stop();
        Console.WriteLine("Double: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Mutltiplication.MultiplicateDecimal(1m, 10000000m, 2m);
        watch.Stop();
        Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);

        // Division
        Console.WriteLine("Division:");
        watch.Restart();
        Division.DevideInt(10000000, 0, 2);
        watch.Stop();
        Console.WriteLine("Int: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Division.DevideLong(10000000L, 0L, 2L);
        watch.Stop();
        Console.WriteLine("Long: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Division.DevideFloat(10000000f, 0f, 2f);
        watch.Stop();
        Console.WriteLine("Float: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Division.DevideDouble(10000000d, 0d, 2d);
        watch.Stop();
        Console.WriteLine("Double: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Division.DevideDecimal(10000000m, 0m, 2m);
        watch.Stop();
        Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);
       
    }
}