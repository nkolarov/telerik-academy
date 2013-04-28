// ****************************************************************
// <copyright file="StringExtensions.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************
namespace Telerik.StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Defines additional extension methods for <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Calculates MD5 hash of a string.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The 128-bit hash of the string.</returns>
        /// <example>
        /// How to use the <see cref="ToMD5Hash"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "Just a string";
        ///         Console.WriteLine(someString.ToMD5Hash());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks if the input string can be used as a boolean value <see cref="System.Boolean"/>
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>True if the input string can be converted to a <see cref="System.Boolean"/> with value TRUE.</returns>
        /// <example>
        /// How to use the <see cref="ToBoolean"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "да";
        ///         Console.WriteLine(someString.ToBoolean()); // Prints "true"
        ///     }
        /// }
        /// </code>
        /// </example>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the input string to <see cref="System.Int16"/>.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The converted value as <see cref="System.Int16"/></returns>
        /// <example>
        /// How to use the <see cref="ToShort"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "12";
        ///         Console.WriteLine(someString.ToShort());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the input string to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The converted value as <see cref="System.Int32"/></returns>
        /// <example>
        /// How to use the <see cref="ToInteger"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "2147483647";
        ///         Console.WriteLine(someString.ToInteger());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the input string to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The converted value as <see cref="System.Int64"/></returns>
        /// <example>
        /// How to use the <see cref="ToLong"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "9223372036854775807";
        ///         Console.WriteLine(someString.ToLong());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the input string to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The converted value as <see cref="System.DateTime"/></returns>
        /// <example>
        /// How to use the <see cref="ToDateTime"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "2013/01/01 00:00:01";
        ///         Console.WriteLine(someString.ToDateTime());
        ///     }
        /// }
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the input string.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>A string with capitalized first letter.</returns>
        /// <example>
        /// How to use the <see cref="ToDateTime"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "pesho is the best!";
        ///         Console.WriteLine(someString.CapitalizeFirstLetter()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Finds the string between <paramref name="startString"/> and <paramref name="endString"/> starting at <paramref name="startFrom"/>.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <param name="startString">The starting string.</param>
        /// <param name="endString">The ending string.</param>
        /// <param name="startFrom">Starting index to search.</param>
        /// <returns>Returns the string between <paramref name="startString"/> and <paramref name="endString"/> starting at <paramref name="startFrom"/>.</returns>
        /// <example>
        /// How to use the <see cref="GetStringBetween"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "pesho is the best!";
        ///         Console.WriteLine(someString.GetStringBetween("pesho", "best"));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts cyrillic letters to their latin representation.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The converted text with latin letters.</returns>
        /// <example>
        /// How to use the <see cref="ConvertCyrillicToLatinLetters"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "Аз пиша на кирилица!";
        ///         Console.WriteLine(someString.ConvertCyrillicToLatinLetters()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts latin letters to their cyrillic representation.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The converted text with cyrillic letters.</returns>
        /// <example>
        /// How to use the <see cref="ConvertLatinToCyrillicKeyboard"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "Az pisha na kirilica!";
        ///         Console.WriteLine(someString.ConvertLatinToCyrillicKeyboard()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts cyrillic letters to their latin representation.
        /// Removes all non-alphanumeric characters (excluding the period ".").
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>A string with cyrillic letters converted to their latin representation and removed all non-alphanumeric characters (excluding the period ".").</returns>
        /// <example>
        /// How to use the <see cref="ToValidUsername"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "байIvan";
        ///         Console.WriteLine(someString.ToValidUsername()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts cyrillic letters to their latin representation.
        /// Replaces all spaces with hyphens.
        /// Removes all non-alphanumeric characters (excluding the period "." and hyphen "-").
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>A string with cyrillic letters converted to their latin representation, all spaces replaced with hyphens and removed all non-alphanumeric characters (excluding the period "." and hyphen "-").</returns>
        /// <example>
        /// How to use the <see cref="ToValidLatinFileName"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "странен документ с гадно име.txt";
        ///         Console.WriteLine(someString.ToValidLatinFileName()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a substring which starts from the beginning of the string and ends at the lesser of <paramref name="charsCount"/> or the length of the string.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <param name="charsCount">Number of needed characters.</param>
        /// <returns>A substring with the first characters.</returns>
        /// <example>
        /// How to use the <see cref="GetFirstCharacters"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "странен документ с гадно ";
        ///         Console.WriteLine(someString.GetFirstCharacters(10)); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the file extension of the string.
        /// </summary>
        /// <param name="fileName">This instance.</param>
        /// <returns>The file extension of the string.</returns>
        /// <example>
        /// How to use the <see cref="GetFileExtension"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "pesho.doc";
        ///         Console.WriteLine(someString.GetFileExtension()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the corresponding type (MIME) for the current file extension.
        /// </summary>
        /// <param name="fileExtension">This instance.</param>
        /// <returns>The file extension of the string.</returns>
        /// <example>
        /// How to use the <see cref="ToContentType"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "docx";
        ///         Console.WriteLine(someString.ToContentType()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the input string to a sequence of bytes.
        /// </summary>
        /// <param name="input">This instance.</param>
        /// <returns>The input string converted as a sequence of bytes.</returns>
        /// <example>
        /// How to use the <see cref="ToByteArray"/> method:
        /// <code>
        /// class Test
        /// {
        ///     static void Main()
        ///     {
        ///         string someString = "Just a test.";
        ///         Console.WriteLine(someString.ToByteArray()); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
