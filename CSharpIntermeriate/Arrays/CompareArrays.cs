using System;

class CompareArrays
{/*Write a program that reads two arrays from the console and compares them element by element*/
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

        int[] firstArr = new int[elementsOne];
        int[] secondArr = new int[elementsTwo];

        ReadArray(firstArr, 1);
        ReadArray(secondArr, 2);

        Compare(firstArr, secondArr);
    }

    static void ReadArray(int[] arr, int arrayNumber) {
        for (int i = 0; i < arr.Length; i++)
			{
            Console.WriteLine("Enter element [{0}] for Array Number {1}:", i, arrayNumber == 1 ?"One":"Two");
			    arr[i] = int.Parse(Console.ReadLine());
			}
    }

    static void Compare(int[] first, int[] second) {
        uint differences = 0;
        if (first.Length != second.Length)
        {
            Console.WriteLine("The arrays have different Lenght! They are not the same!");
        }
        else
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    Console.WriteLine("ArrayOne[{0}] = {1} != ArrayTwo[{0}] = {2}",i,first[i], second[i]);
                    differences += 1;
                }
            }
            if (differences == 0)
            {
                Console.WriteLine("The arrays are the same!");
            }
            else
            {
                Console.WriteLine("The arrays are different!");
            }
        }
    }
}