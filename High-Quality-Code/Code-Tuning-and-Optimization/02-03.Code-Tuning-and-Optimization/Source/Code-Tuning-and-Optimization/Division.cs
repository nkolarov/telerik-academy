using System;

public static class Division
{
    public static void DevideInt(int start, int end, int step)
    {
        while (start > end)
        {
            start /= step;
        }
    }

    public static void DevideLong(long start, long end, long step)
    {
        while (start > end)
        {
            start /= step;
        }
    }

    public static void DevideFloat(float start, float end, float step)
    {
        while (start > end)
        {
            start /= step;
        }
    }

    public static void DevideDouble(double start, double end, double step)
    {
        while (start > end)
        {
            start /= step;
        }
    }

    public static void DevideDecimal(decimal start, decimal end, decimal step)
    {
        while (start > end)
        {
            start /= step;
        }
    }
}