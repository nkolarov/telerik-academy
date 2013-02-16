using System;

class CompareLexicographically
{/*Write a program that compares two char arrays lexicographically (letter by letter).*/
    static void Main()
    {
        uint elementsOne = 0, elementsTwo = 0;
        bool isUint;
        string line;


        Console.WriteLine("Please enter the number of elements for array One:");

        do
        {
            line = Console.ReadLine();
            isUint = uint.TryParse(line, out elementsOne);
            if (!isUint)
            {
                Console.WriteLine("Error!\nNot an Integer!\nPlease enter the number of elements for array One:");
            }
        } while (!isUint);

        Console.WriteLine("Please enter the number of elements for array Two:");

        do
        {
            line = Console.ReadLine();
            isUint = uint.TryParse(line, out elementsTwo);
            if (!isUint)
            {
                Console.WriteLine("Error!\nNot an Integer!\nPlease enter the number of elements for array Two:");
            }
        } while (!isUint);

        char[] firstArr = new char[elementsOne];
        char[] secondArr = new char[elementsTwo];

        ReadArray(firstArr, 1);
        ReadArray(secondArr, 2);

        Compare(firstArr, secondArr);
    }

    static void ReadArray(char[] arr, int arrayNumber)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Enter element [{0}] for Array Number {1}:", i, arrayNumber == 1 ? "One" : "Two");
            arr[i] = char.Parse(Console.ReadLine());
        }
    }

    static void Compare(char[] first, char[] second)
    {
        int minLength;
        int result = 0;

        if (first.Length != second.Length)
        {
            minLength = first.Length > second.Length ? second.Length : first.Length;
        }
        else
        {
            minLength = first.Length;
        }

        for (int i = 0; i < minLength; i++)
        {
            if (first[i] != second[i])
            {
                if (first[i] < second[i])
                {
                    Console.WriteLine("First is before second!");
                    result = 1;
                    break;
                }
                else
                {
                    Console.WriteLine("Second is before first!");
                    result = 2;
                    break;
                }
            }
        }
        if (result == 0)
        {
            Console.WriteLine("{0} is before {1}!", first.Length < second.Length ? "First" : "Second", first.Length < second.Length ? "Second" : "First");
        }
    }

    static void PrintArray(char[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine("Array[{0}]={1}", i, input[i]);
        }
    }
}
