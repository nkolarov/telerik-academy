// ********************************
// <copyright file="DictionaryDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SampleMongoDictionary
{
    using System;
    using System.Linq;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// Represents a sample mongo db dictionary.
    /// </summary>
    public class DictionaryDemo
    {
        /* 01. Write a simple "Dictionary" application in C# or JavaScript to perform the following in MongoDB:
         * Add a dictionary entry (word + translation)
         * List all words and their translations
         * Find the translation of given word
         * The UI of the application is up to you (it could be Web-based, GUI or console-based).
         * You may use MongoDB-as-a-Service@ MongoLab.
         * You may install the "Official MongoDB C# Driver" from NuGet or download it from its publisher: */
        public static MongoCollection<Word> words;

        /// <summary>
        /// Mains this instance.
        /// </summary>
        static void Main()
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var dictionaryDb = mongoServer.GetDatabase("Dictionary");
            words = dictionaryDb.GetCollection<Word>("Words");

            AddWord("pesho", "ninja developper");
            AddWord("pesho_zlia", "ninja developper");
            Translate("pesho");
            RemoveWord("pesho");
            Console.WriteLine("Words:");
            ListAllWords();
        }

        /// <summary>
        /// Lists all words.
        /// </summary>
        public static void ListAllWords() 
        {
            var dictionary = words.FindAllAs<Word>();
            foreach (var word in dictionary)
            {
                Console.WriteLine(word);
            }
        }

        /// <summary>
        /// Adds a word to the dictionary.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="translation">The translation.</param>
        public static void AddWord(string word, string translation)
        {
            Word newWord = new Word(word.ToLower(), translation.ToLower());

            int countWords = words.AsQueryable<Word>().Where(w => w.Value == newWord.Value).Count();
            if (countWords == 0)
            {
                words.Insert<Word>(newWord);
            }
            else
            {
                Console.WriteLine("Error! The world already exists!");
            }
        }

        /// <summary>
        /// Finds a translation for given word.
        /// </summary>
        /// <param name="word">The word.</param>
        public static void Translate(string word)
        {
            var searchedWord = words.AsQueryable<Word>().FirstOrDefault(w => w.Value == word.ToLower());
            if (searchedWord != null)
            {
                Console.WriteLine("Word: {0}\nTranslation: {1}", searchedWord.Value, searchedWord.Translation);
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }

        /// <summary>
        /// Removes a word from the dictionary.
        /// </summary>
        /// <param name="word">The word to be removed.</param>
        public static void RemoveWord(string word)
        {
            var removedWord = words.AsQueryable<Word>().FirstOrDefault(w => w.Value == word.ToLower());
            if (removedWord != null)
            {
                var query = Query.EQ("_id", removedWord.Id);
                words.Remove(query);
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }
    }
}
