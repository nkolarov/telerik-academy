using System;

class BinarySort
{/*Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).*/
    //TODO: Read about Deferred detection of equality
    static void Main()
    {
        int elements = 0, key = 0;
        bool isInt;
        string line;

        Console.WriteLine("Please enter the number of elements N:");

        do
        {
            line = Console.ReadLine();
            isInt = int.TryParse(line, out elements);
            if (!isInt || elements < 0)
            {
                Console.WriteLine("Error!\nNot an Integer!\nPlease enter the number of elements N:");
            }
        }
        while (!isInt || elements < 0);

        Console.WriteLine("Please enter the key:");

        do
        {
            line = Console.ReadLine();
            isInt = int.TryParse(line, out key);
            if (!isInt)
            {
                Console.WriteLine("Error!\nNot an Integer!\nPlease enter the key:");
            }
        }
        while (!isInt);

        int[] input = new int[elements];

        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine("Enter element [{0}]:", i);
            input[i] = int.Parse(Console.ReadLine());
        }

        //int[] input = { 4, 3, 1, 4, 2, 5, 8 };

        if (input.Length == 0)
        {
            Console.WriteLine("Don`t mess with me!");
            return;
        }
        int result = RecursiveBinarySearch(input, key, input.Length, 0);
        int resultTwo = IterativeBinarySearch(input, key, input.Length, 0);

        if (result < 0)
        {
            Console.WriteLine("Value not Found!");
        }
        else
        {
            Console.WriteLine("[{0}] == {1}", result, key);
        }


        if (resultTwo < 0)
        {
            Console.WriteLine("ValueTwo not Found!");
        }
        else
        {
            Console.WriteLine("Two [{0}] == {1}", resultTwo, key);
        }


    }

    static int RecursiveBinarySearch(int[] input, int key, int imax, int imin)
    {
        if (imax < imin)
        {
            //Key Not found! Return Error!
            return -1;
        }
        else
        {
            int imid = (imax + imin) / 2;

            if (input[imid] > key)
            { //key is in lower subset
                return RecursiveBinarySearch(input, key, imid - 1, imin);
            }
            else if (input[imid] < key)
            { //key is in upper subset
                return RecursiveBinarySearch(input, key, imax, imid + 1);
            }
            else
            { //key has been found
                return imid;
            }
        }
    }

    static int IterativeBinarySearch(int[] input, int key, int imax, int imin)
    {
        while (imax >= imin)
        {
            /* calculate the midpoint for roughly equal partition */
            int imid = (imin + imax) / 2;

            // determine which subarray to search
            if (input[imid] < key)
            {
                // change min index to search upper subarray
                imin = imid + 1;
            }
            else if (input[imid] > key)
            {
                // change max index to search lower subarray
                imax = imid - 1;
            }
            else
            // key found at index imid
                return imid;
        }
        // Error! Key not found!
        return -1;
    }
}