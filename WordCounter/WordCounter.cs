using System;
using System.Collections.Generic;

namespace WordCounter
{
    /// <summary>
    /// Counts occurrences of distinct words in a sentence
    /// </summary>
    public sealed class WordCounter
    {
        private readonly SentencePreprocessor _preprocessor;
        private readonly string _sentence;

        public WordCounter(string sentence)
        {
            _sentence = sentence;

            // This is a bit of tight coupling here:
            // we would probably use a factory to abstract away creation logic
            // if this were an enterprise setting.
            // It would, though, add considerable complexity,
            // and that seems uncalled for in an app of this size
            _preprocessor = new SentencePreprocessor(sentence);
        }

        /// <summary>
        /// Counts words in the provided sentence
        /// </summary>
        /// <returns>A Dictionary of distinct words in the sentence and their occurrences</returns>
        public Dictionary<string, int> CountWords()
        {
            var result = new Dictionary<string, int>();
            if (_sentence == String.Empty)
                return result;

            var preprocessedString = _preprocessor.Process();
            var words = preprocessedString.Split(' ');

            foreach (var word in words)
            {
                if (result.ContainsKey(word))
                    result[word]++;
                else
                    result.Add(word, 1);
            }
            return result;
        }
    }
}