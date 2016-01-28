using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class WordCounterTests
    {
        [Test]
        public void CountWordsReturnsAnEmptyDictionaryForEmptyInput()
        {
            var emptySentence = String.Empty;
            var cut = new WordCounter(emptySentence);
            var expectedResult = new Dictionary<string, int>();

            Assert.AreEqual(expectedResult, cut.CountWords());
        }

        [Test]
        public void CountWordsReturnsAnEmptyDictionaryForNullInput()
        {
            string nullSentence = null;
            var cut = new WordCounter(nullSentence);
            var expectedResult = new Dictionary<string, int>();

            Assert.AreEqual(expectedResult, cut.CountWords());
        }

        [Test]
        public void CountWordsProcessesFindsAWordInASingleWordSentence()
        {
            var sentence = "Test";
            var cut = new WordCounter(sentence);

            Assert.AreEqual(1, cut.CountWords().Count);
        }
        
        [Test]
        public void CountWordsFindsAWordInASingleWordSentenceWithPunctuation()
        {
            var sentence = "Test!";
            var cut = new WordCounter(sentence);

            Assert.AreEqual(1, cut.CountWords().Count);
        }

        [Test]
        public void CountWordsFindsTwoWordsInASimpleTwoWordSentence()
        {
            var sentence = "hello world";
            var cut = new WordCounter(sentence);

            Assert.AreEqual(2, cut.CountWords().Count);
        }

        [Test]
        public void CountWordsFindsADuplicateWordInATwoWordSentence()
        {
            var sentence = "hello hello";
            var cut = new WordCounter(sentence);
            var result = cut.CountWords();
            var expectedResult = new Dictionary<string, int> {{"hello", 2}};

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CountWordsFindsADuplicateWordInATwoWordSentenceWithDifferentCases()
        {
            var sentence = "hello Hello";
            var cut = new WordCounter(sentence);
            var result = cut.CountWords();
            var expectedResult = new Dictionary<string, int> {{"hello", 2}};

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CountWordsFindsADuplicateWordSurroundedByPunctuation()
        {
            var sentence = "hello,world,hello!";
            var cut = new WordCounter(sentence);
            var result = cut.CountWords();
            var expectedResult = new Dictionary<string, int> {{"hello", 2}, {"world", 1}};

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ClientProvidedExampleTest()
        {
            var sentence = "This is a statement, and so is this.";
            var cut = new WordCounter(sentence);
            var result = cut.CountWords();

            var expectedResult = new Dictionary<string, int>
            {
                {"this", 2},
                {"is", 2},
                {"a", 1},
                {"statement", 1},
                {"and", 1},
                {"so", 1}
            };


            Assert.AreEqual(expectedResult, result);
        }
    }
}
