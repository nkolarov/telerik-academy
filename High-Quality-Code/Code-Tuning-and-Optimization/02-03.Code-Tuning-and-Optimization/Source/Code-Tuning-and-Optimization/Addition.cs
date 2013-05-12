using System;

public static class Addition
{
    public static void AddInt(int start, int end, int step)
    {
        while (start < end)
        {
            start += step;
        }
    }

    public static void AddLong(long start, long end, long step)
    {
        while (start < end)
        {
            start += step;
        }
    }

    public static void AddFloat(float start, float end, float step)
    {
        while (start < end)
        {
            start += step;
        }
    }

    public static void AddDouble(double start, double end, double step)
    {
        while (start < end)
        {
            start += step;
        }
    }

    public static void AddDecimal(decimal start, decimal end, decimal step)
    {
        while (start < end)
        {
            start += step;
        }
    }
}
