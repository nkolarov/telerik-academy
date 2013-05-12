using System;
using System.Diagnostics;

class JustAnotherTest
{
    static void Main()
    {
        Stopwatch watch = new Stopwatch();

        // SQRT
        Console.WriteLine("SQRT:");
        watch.Restart();
        Sqrt.FloatSqrt(1f, 10000000f, 1f);
        watch.Stop();
        Console.WriteLine("Float: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Sqrt.DoubleSqrt(1d, 10000000d, 1d);
        watch.Stop();
        Console.WriteLine("Double: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Sqrt.DecimalSqrt(1m, 10000000m, 1m);
        watch.Stop();
        Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);

        // Sinus
        Console.WriteLine("Sinus:");
        watch.Restart();
        Sinus.FloatSinus(1f, 10000000f, 1f);
        watch.Stop();
        Console.WriteLine("Float: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Sinus.DoubleSinus(1d, 10000000d, 1d);
        watch.Stop();
        Console.WriteLine("Double: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Sinus.DecimalSinus(1m, 10000000m, 1m);
        watch.Stop();
        Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);

        // Logarithm
        Console.WriteLine("Logarithm:");
        watch.Restart();
        Logarithm.FloatLogarithm(1f, 10000000f, 1f);
        watch.Stop();
        Console.WriteLine("Float: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Logarithm.DoubleLogarithm(1d, 10000000d, 1d);
        watch.Stop();
        Console.WriteLine("Double: " + watch.ElapsedMilliseconds);

        watch.Restart();
        Logarithm.DecimalLogarithm(1m, 10000000m, 1m);
        watch.Stop();
        Console.WriteLine("Decimal: " + watch.ElapsedMilliseconds);
    }
}