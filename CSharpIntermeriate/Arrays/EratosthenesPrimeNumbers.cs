using System;
using System.Text;

class EratosthenesPrimeNumbers
{
    //Recursion OR Iteration count
    static int counter = 0;

    static void Main()
    {
        int n = 0;
        bool isInt;
        string line;
        DateTime startTime, endTime;
        StringBuilder primeNumbers = new StringBuilder();
        Console.WriteLine("Please enter N:");
        
        //Read n
        do
        {
            line = Console.ReadLine();
            isInt = int.TryParse(line, out n);
            if (!isInt || n < 0)
            {
                Console.WriteLine("Error!\nNot an Integer!\nPlease enter  N:");
            }
        }
        while (!isInt || n < 0);

        int[] numbers = new int[n];

        // Filling the array; Prime numbers must be greater than 1, so we start from 2!
        for (int i = 2; i < n; i++)
        {
            numbers[i] = i;
        }

        ////Call recursion
        //Mark(numbers, n, 2);

        int start = 2;
        startTime = DateTime.Now;

        while (start < n)
        {
            counter++;
            if (start >= n)
            {//Bottom
                break;
            }

            int count = n / start;
            int nextStart = 0;
            //Fix for odd numbers
            if (n % start > 0)
            {
                count++;
            }

            for (int i = 2; i < count; i++)
            {
                numbers[i * start] = 0;
            }

            for (int i = start + 1; i < n; i++)
            {
                if (numbers[i] != 0)
                {
                    nextStart = i;
                    break;
                }
            }

            if (nextStart == 0)
            {//Another recursion bottom
                break;
            }
            else
            {
                start = nextStart;
            }
            //Mark(numbers, n, nextStart);
        }

        endTime = DateTime.Now;
        

        for (int i = 0; i < n; i++)
        {
            if (numbers[i] != 0)
            {
                primeNumbers.Append(numbers[i]);
                primeNumbers.Append(',');
            }
        }
        //Remove last comma
        primeNumbers.Remove(primeNumbers.Length-1,1);

        //Console.WriteLine(primeNumbers);
        Console.WriteLine("Calculation Time: " + (endTime - startTime));
        Console.WriteLine("Count: " + counter);
    }

    ////Stack overflow for n > 350 000
    //static void Mark(int[] numbers, int n, int start)
    //{ // !!!! start>=2 !!!!
    //    counter++;
    //    if (start >= n)
    //    {//Recursion Bottom
    //        return;
    //    }


    //    int count = n / start;
    //    int nextStart = 0;
    //    //Fix for odd numbers
    //    if (n % start > 0)
    //    {
    //        count++;
    //    }

    //    for (int i = 2; i < count; i++)
    //    {
    //        numbers[i * start] = 0;
    //    }

    //    for (int i = start + 1; i < n; i++)
    //    {
    //        if (numbers[i] != 0)
    //        {
    //            nextStart = i;
    //            break;
    //        }
    //    }

    //    if (nextStart == 0)
    //    {//Another recursion bottom
    //        return;
    //    }

    //    Mark(numbers, n, nextStart);
    //}
}