using System;

public static class Substraction
{
    public static void SubstractInt(int start, int end, int step)
    {
        while (start > end)
        {
            start -= step;
        }
    }

    public static void SubstractLong(long start, long end, long step)
    {
        while (start > end)
        {
            start -= step;
        }
    }

    public static void SubstractFloat(float start, float end, float step)
    {
        while (start > end)
        {
            start -= step;
        }
    }

    public static void SubstractDouble(double start, double end, double step)
    {
        while (start > end)
        {
            start -= step;
        }
    }

    public static void SubstractDecimal(decimal start, decimal end, decimal step)
    {
        while (start > end)
        {
            start -= step;
        }
    }
}
