using System;

public static class Mutltiplication
{
    public static void MultiplicateInt(int start, int end, int step)
    {
        while (start < end)
        {
            start *= step;
        }
    }

    public static void MultiplicateLong(long start, long end, long step)
    {
        while (start < end)
        {
            start *= step;
        }
    }

    public static void MultiplicateFloat(float start, float end, float step)
    {
        while (start < end)
        {
            start *= step;
        }
    }

    public static void MultiplicateDouble(double start, double end, double step)
    {
        while (start < end)
        {
            start *= step;
        }
    }

    public static void MultiplicateDecimal(decimal start, decimal end, decimal step)
    {
        while (start < end)
        {
            start *= step;
        }
    }
}
