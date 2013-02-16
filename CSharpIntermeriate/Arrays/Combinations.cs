using System;

class Combinations
{/*Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}*/
    static int n, k;
    static int[] output;

    static void Main()
    {
        bool isInt;
        string line;

        //Read N
        Console.WriteLine("Please enter N:");

        do
        {
            line = Console.ReadLine();
            isInt = int.TryParse(line, out n);
            if (!isInt || n <= 0)
            {
                Console.WriteLine("Error!\nNot an Integer!\nPlease enter N:");
            }
        }
        while (!isInt || n <= 0);

        Console.WriteLine("Please enter K:");

        do
        {
            line = Console.ReadLine();
            isInt = int.TryParse(line, out k);
            if (!isInt || k <= 0)
            {
                Console.WriteLine("Error!\nNot an Integer!\nPlease enter K:");
            }
        }
        while (!isInt || k <= 0);

        output = new int[k];

        Combine(1, 0);
    }

    static void Print(int length)
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write((output[i]) + " ");
        }
        Console.WriteLine();
    }

    static void Combine(int index, int next)
    {
        int i;

        if (index > k)
        {
            return;
        }
        else
        {
            for (i = next + 1; i <= n; i++)
            {
                output[index - 1] = i;

                if (index == k)
                {
                    Print(k);
                }

                Combine(index + 1, i);
            }
        }
    }
}