using System;

public static class Sqrt
{
    public static void FloatSqrt(float start, float end, float step)
    {
        for (float i = start; i <= end; i = i + step)
        {
            Math.Sqrt(i);
        }
    }

    public static void DoubleSqrt(double start, double end, double step)
    {
        for (double i = start; i <= end; i = i + step)
        {
            Math.Sqrt(i);
        }
    }

    public static void DecimalSqrt(decimal start, decimal end, decimal step)
    {
        for (decimal i = start; i <= end; i = i + step)
        {
            Math.Sqrt((double)i);
        }
    }
}