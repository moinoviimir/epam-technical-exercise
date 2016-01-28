using System;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class SentencePreprocessorTests
    {
        [Test]
        public void ProcessDoesNotChangeAnEmptySentence()
        {
            var sentence = String.Empty;
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual(String.Empty, cut.Process());
        }

        [Test]
        public void ProcessReturnsAnEmptyStringOnANullSentence()
        {
            string sentence = null;
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual(String.Empty, cut.Process());
        }

        [Test]
        public void ProcessDoesNotMangleASingleLowercaseWordWithoutPunctuation()
        {
            var sentence = "test";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual(sentence, cut.Process());
        }

        [Test]
        public void ProcessMakesACapitalizedWordIntoLowercase()
        {
            var sentence = "Test";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("test", cut.Process());
        }

        [Test]
        public void ProcessRemovesPunctuationEverywhere()
        {
            var sentence = "?hello, world!";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello  world", cut.Process());
        }

        [Test]
        public void ProcessReplacesPunctuationWithEmptySpaces()
        {
            var sentence = "hello,world";
            var cut = new SentencePreprocessor(sentence);
            
            Assert.AreEqual("hello world", cut.Process());
        }

        [Test]
        public void ProcessMergesSeveralWhiteSpacesIntoOne()
        {
            var sentence = "  hello  world  ";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello  world", cut.Process());
        }

        [Test]
        public void ProcessBothRemovesPunctuationAndLowercasesWords()
        {
            var sentence = "&Hello, World!";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello  world", cut.Process());
        }
    }
}
