using System;

public static class Sinus
{
    public static void FloatSinus(float start, float end, float step)
    {
        for (float i = start; i <= end; i = i + step)
        {
            Math.Sin(i);
        }
    }

    public static void DoubleSinus(double start, double end, double step)
    {
        for (double i = start; i <= end; i = i + step)
        {
            Math.Sin(i);
        }
    }

    public static void DecimalSinus(decimal start, decimal end, decimal step)
    {
        for (decimal i = start; i <= end; i = i + step)
        {
            Math.Sin((double)i);
        }
    }
}