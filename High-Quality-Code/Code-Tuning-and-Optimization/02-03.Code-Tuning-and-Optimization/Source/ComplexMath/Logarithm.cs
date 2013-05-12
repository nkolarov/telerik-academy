using System;

public static class Logarithm
{
    public static void FloatLogarithm(float start, float end, float step)
    {
        for (float i = start; i <= end; i = i + step)
        {
            Math.Log(i);
        }
    }

    public static void DoubleLogarithm(double start, double end, double step)
    {
        for (double i = start; i <= end; i = i + step)
        {
            Math.Log(i);
        }
    }

    public static void DecimalLogarithm(decimal start, decimal end, decimal step)
    {
        for (decimal i = start; i <= end; i = i + step)
        {
            Math.Log((double)i);
        }
    }
}