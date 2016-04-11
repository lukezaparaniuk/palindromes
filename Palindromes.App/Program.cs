using Palindromes.Core.Services;
using System;
using System.Linq;

namespace Palindromes.App
{
    class Program
    {
        const string DEFAULT_TEXT = "LXsR6Bc585P4EEFr3zLQb8m04Y41fk0P";

        static void Main(string[] args)
        {
            PrintHeader();

            PrintInstructions();

            string text;

            while ((text = Console.ReadLine()).ToUpper() != "EXIT")
            {
                if (string.IsNullOrEmpty(text))
                {
                    text = DEFAULT_TEXT;
                }

                var service = new UniqueStringPalindromeService();

                var palindromes = service.GetPalindromes(text, top: 3);

                if (palindromes.Any())
                {
                    var iterations = 0;

                    foreach (var palindrome in palindromes)
                    {
                        if (iterations > 0)
                        {
                            Console.Write(Environment.NewLine);
                        }
                        Console.WriteLine($"Text: {palindrome.Value}, Index: {palindrome.Index}, Length: {palindrome.Length}");
                    }
                }
                else
                {
                    Console.WriteLine("No palindromes :(");
                }

                PrintInstructions();
            }
        }

        static void PrintHeader()
        {
            Console.WriteLine(new string('*', 79));
            const string TITLE = "Palindromes finder by Luke Zapraniuk";
            Console.WriteLine(new string(' ', (80 - TITLE.Length) / 2) + TITLE);
            Console.WriteLine(new string('*', 79));
        }

        static void PrintInstructions()
        {
            Console.WriteLine(Environment.NewLine);
            Console.Write($"Text to search ({DEFAULT_TEXT}) or exit: ");
        }
    }
}
