using System;

namespace WordCounter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the sentence");
            var sentence = Console.ReadLine();
            var result = new WordCounter(sentence).CountWords();

            foreach (var key in result.Keys)
            {
                Console.WriteLine("{0} - {1}", key, result[key]);
            }
            Console.ReadKey();
        }
    }
}
