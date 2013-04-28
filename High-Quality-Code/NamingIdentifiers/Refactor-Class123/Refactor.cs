using System;

/// <summary>
/// Shows correct naming
/// </summary>
public class Refactor
{
    /// <summary>
    /// Stupid and unused constant.
    /// </summary>
    public const int MaxCount = 6;

    /// <summary>
    /// Fun starts here.
    /// </summary>
    public static void Main()
    {
        Refactor.Printer instance = new Refactor.Printer();
        instance.Print(true);
    }

    /// <summary>
    /// Inner class for printing boolean variable to the console.
    /// </summary>
    private class Printer
    {
        /// <summary>
        /// Print <paramref name="isStupidCode"/> to the Console
        /// </summary>
        /// <param name="isStupidCode">Some boolean variable.</param>
        public void Print(bool isStupidCode)
        {
            string isStupidCodeAsString = isStupidCode.ToString();
            Console.WriteLine(isStupidCodeAsString);
        }
    }
}