using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    public class DuplicateRemover
    {
        public static string RemoveDuplicates(string input)
        {
            HashSet<char> visited = new HashSet<char>();
            string output = "";
            foreach (char c in input)
            {
                if (!visited.Contains(c))
                {
                    visited.Add(c);
                    output += c;
                }
            }
            return output;
        }
    }

    public class Anagrammer
    {
        public static bool AreAnagrams(string input1, string input2)
        {
            if (input1.Length != input2.Length)
                return false;

            Dictionary<char, int> counts1 = new Dictionary<char, int>();
            Dictionary<char, int> counts2 = new Dictionary<char, int>();

            for (int i = 0; i < input1.Length; i++)
            {
                Anagrammer.addKeyIfNullElseIncrement(counts1, input1[i]);
                Anagrammer.addKeyIfNullElseIncrement(counts2, input2[i]);
            }

            foreach(KeyValuePair<char, int> kvp in counts1)
            {
                if (!counts2.ContainsKey(kvp.Key) || counts2[kvp.Key] != kvp.Value)
                    return false;
            }

            return true;
        }

        private static void addKeyIfNullElseIncrement(Dictionary<char, int> counter, char c)
        {
            if (!counter.ContainsKey(c))
                counter.Add(c, 1);
            else
                counter[c]++;
        }
    }

    public class StringReverser
    {
        public static string IterateReverse(string input)
        {
            string reversed = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }
            return reversed;
        }

        public static string RecurseReverse(string input)
        {
            return sliceAndReverse(input);
        }

        private static string sliceAndReverse(string input)
        {
            if (input.Length <= 1)
                return input;

            return sliceAndReverse(input.Substring(1)) + input[0];
        }
    }

    public class StringMerger
    {
        public static string MergeWhiteSpaceZip(string input)
        {
            List<char> chararray = input.ToCharArray().ToList();
            List<char> whitespacearray = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                whitespacearray.Add(' ');
            }

            var generator = chararray.Zip(whitespacearray, (first, second) => first + second);
            string output = "";
            foreach (var item in generator)
                output += item;

            return output;
        }

        public static string MergeWhiteSpaceIterate(string input)
        {
            string output = "";
            foreach(char c in input)
            {
                output += c;
                output += ' ';
            }
            return output.TrimEnd(' ');
        }
    }

    public class Substringer
    {
        public static List<string> GetSubstrings(string input, HashSet<string> dict)
        {
            List<string> output = new List<string>();
            List<string> holders = new List<string>();
            foreach(char c in input)
            {
                holders.Add("");
                for (int i = 0; i < holders.Count; i ++)
                {
                    holders[i] += c;
                    if (dict.Contains(holders[i]))
                        output.Add(holders[i]);
                }
            }

            return output;
        }
    }
}
