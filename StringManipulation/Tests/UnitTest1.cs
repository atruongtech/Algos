using System;
using NUnit.Framework;
using System.Collections.Generic;
using StringManipulation;

namespace Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void RemoveDuplicates_Returns_StringWithNoDuplicates(
            [Values("Csharpstar", "Google", "Yahoo", "CNN")] string input)
        {
            HashSet<char> visited = new HashSet<char>();
            foreach(char c in DuplicateRemover.RemoveDuplicates(input)) {
                if (visited.Contains(c))
                    Assert.Fail();
                visited.Add(c);
            }
        }

        [Test]
        public void Anagrammer_Returns_True_If_Anagram()
        {
            string input;
            string input2;

            input = "testing";
            input2 = "nottrue";

            Assert.IsFalse(Anagrammer.AreAnagrams(input, input2));

            input = "testing";
            input2 = "testing";
            Assert.IsTrue(Anagrammer.AreAnagrams(input, input2));

            input = "testing";
            input2 = "esttign";
            Assert.IsTrue(Anagrammer.AreAnagrams(input, input2));

            input = "alan truong";
            input2 = "nata rulong";
            Assert.IsTrue(Anagrammer.AreAnagrams(input, input2));
        }

        [Test]
        public void ReverseString_Returns_ReversedString()
        {
            string input;
            string output;

            input = "testing";
            output = "gnitset";

            Assert.AreEqual(output, StringReverser.IterateReverse(input));
            Assert.AreEqual(output, StringReverser.RecurseReverse(input));

            input = "";
            output = "";

            Assert.AreEqual(output, StringReverser.IterateReverse(input));
            Assert.AreEqual(output, StringReverser.RecurseReverse(input));
        }

        [Test]
        public void FindAllSubstrings_Returns_ListOfSubstrings()
        {
            HashSet<string> dict = new HashSet<string>();
            dict.Add("hi");
            dict.Add("ship");
            dict.Add("pict");
            dict.Add("testing");

            List<string> results = Substringer.GetSubstrings("shipictit", dict);
            Assert.AreEqual(3, results.Count);
            Assert.Contains("hi", results);
            Assert.Contains("pict", results);
            Assert.Contains("ship", results);

        }
    }
}
