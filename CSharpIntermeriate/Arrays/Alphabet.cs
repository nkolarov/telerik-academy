using System;

class Alphabet
{/*Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.*/
    static void Main()
    {
        char[] alphabet = new char[27];

        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)(i + 65);   
        }

        Console.WriteLine("Enter a word: ");
        
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            int currIndex = GetAlphabetIndex(alphabet, word[i]);
            if (currIndex >= 0)
            {
                Console.WriteLine("{0} = {1}", word[i], currIndex);
            }
            else
            {
                Console.WriteLine("{0} = Letter Not Found!", word[i], currIndex);
            }
            
        }
    }

    static int GetAlphabetIndex(char[] alphabet, char character)
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (character == alphabet[i])
            {
                return i+1;
            }
        }
        return -1;
    }
}