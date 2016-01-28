using System;
using System.Linq;
using System.Text;

namespace WordCounter
{
    /// <summary>
    /// Pre-processes a given sentence, preparing it for consumption by WordCounter.
    /// Removes all punctuation and merges whitespaces together.
    /// </summary>
    public sealed class SentencePreprocessor
    {
        private readonly string _sentence;
        public SentencePreprocessor(string sentence)
        {
            _sentence = sentence;
        }

        /// <summary>
        /// Lowercases the source sentence and removes excess whitespaces and punctuation from it.
        /// </summary>
        /// <returns>A lowercased sentence without punctuation or excess whitespaces.</returns>
        public string Process()
        {
            if (String.IsNullOrEmpty(_sentence))
                return String.Empty;

            var loweredString = _sentence.ToLower();

            var sb = new StringBuilder();
            foreach (var c in loweredString)
            {
                var charToAppend = c;
                
                if (Char.IsPunctuation(charToAppend))
                    charToAppend = ' ';

                sb.Append(charToAppend);
            }

            return sb.ToString().Trim();
        }
    }
}
