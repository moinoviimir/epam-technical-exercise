using System;
using System.Runtime.InteropServices;
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
        public void ProcessHandlesASentenceFullOfPunctuationMarksProperly()
        {
            string sentence = @",:;";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual(String.Empty, cut.Process());
        }

        [Test]
        public void ProcessRemovesEveryPunctuationMarkProperly()
        {
            string sentence = @"!""#%&'()*,-./:;?@[\]_{}";
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
        public void ProcessHandlesUppercaseInput()
        {
            var sentence = "TEST";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("test", cut.Process());
        }

        [Test]
        public void ProcessRemovesPunctuationAtTheBeginnging()
        {
            var sentence = "?hello world";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello world", cut.Process());
        }

        [Test]
        public void ProcessRemovesPunctuationInTheMiddle()
        {
            var sentence = "hello, world";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello world", cut.Process());
        }

        [Test]
        public void ProcessRemovesPunctuationInTheEnd()
        {
            var sentence = "hello world!";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello world", cut.Process());
        }

        [Test]
        public void ProcessRemovesPunctuationEverywhere()
        {
            var sentence = "?hello, world!";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello world", cut.Process());
        }

        [Test]
        public void ProcessHandlesAnAllWhitespaceStringProperly()
        {
            var sentence = "                  ";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual(String.Empty, cut.Process());
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
            var sentence = "  hello    world  ";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello world", cut.Process());
        }

        [Test]
        public void ProcessBothRemovesPunctuationAndLowercasesWords()
        {
            var sentence = "&Hello, World!";
            var cut = new SentencePreprocessor(sentence);

            Assert.AreEqual("hello world", cut.Process());
        }

        [Test]
        public void ProcessHandlesAReasonablyLargeStringProperly()
        {
            var sentence =
                @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?";
            var cut = new SentencePreprocessor(sentence);
            var expectedResult =
                "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt neque porro quisquam est qui dolorem ipsum quia dolor sit amet consectetur adipisci velit sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem ut enim ad minima veniam quis nostrum exercitationem ullam corporis suscipit laboriosam nisi ut aliquid ex ea commodi consequatur quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur vel illum qui dolorem eum fugiat quo voluptas nulla pariatur";

            Assert.AreEqual(expectedResult, cut.Process());
        }
    }
}
