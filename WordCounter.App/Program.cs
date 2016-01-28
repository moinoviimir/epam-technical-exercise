using System;

namespace WordCounter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = String.Empty;
            if (args.Length != 0)
            {
                sentence = args[0];
                Console.WriteLine(sentence);
            }
            else
            {
                Console.WriteLine("Please enter the sentence");
                sentence = Console.ReadLine();
            }

            var result = new WordCounter(sentence).CountWords();

            Console.WriteLine();
            foreach (var key in result.Keys)
            {
                Console.WriteLine("{0} - {1}", key, result[key]);
            }
            Console.ReadKey();
        }
    }
}
