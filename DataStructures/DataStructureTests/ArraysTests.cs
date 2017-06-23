using System;
using System.Collections.Generic;
using NUnit.Framework;
using ArrayAlgos;

namespace DataStructureTests
{
    [TestFixture]
    public class ArraysTests
    {
        [Test]
        public void PairFinder_ReturnsEmptyList_WhenPassed_EmptyArray()
        {
            int[] inputs = new int[0];
            var output = PairsForSumInArray.FindSumPairs(inputs, 3);

            Assert.AreEqual(0, output.Count);
        }

        [Test]
        public void PairFinder_Returns_ListOfPairs()
        {
            int[] inputs = new int[5];
            inputs[0] = 1;
            inputs[1] = 4;
            inputs[2] = 3;
            inputs[3] = 3;
            inputs[4] = 6;

            var output = PairsForSumInArray.FindSumPairs(inputs, 7);
            Assert.AreEqual(3, output.Count);
        }

        [Test]
        public void FindDuplicate_Returns_AppropriateDuplicate()
        {
            int[] input = { 1, 2, 3, 4, 4, 5, 6, 7 };
            Assert.AreEqual(4, DuplicateFinder.FindDuplicate(input));
        }

        [Test]
        public void FindIndexWithMatchingValue_Returns_AppropriateValue()
        {
            int[] input = { -1, 1, 2, 3, 5 };
            Assert.AreEqual(2, IndexToValueMatcher.FindIndexWithMatchingValue(input));

            input = new int[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(-1, IndexToValueMatcher.FindIndexWithMatchingValue(input));
        }

        [Test]
        public void PathFinder_Returns_GreatestPathValue()
        {
            int[,] map = new int[3, 4];
            /*
             *  1 2 1 3
             *  2 4 2 1
             *  3 1 3 2
             */
            map[0, 0] = 1;
            map[0, 1] = 2;
            map[0, 2] = 1;
            map[0, 3] = 3;

            map[1, 0] = 2;
            map[1, 1] = 4;
            map[1, 2] = 2;
            map[1, 3] = 1;

            map[2, 0] = 3;
            map[2, 1] = 1;
            map[2, 2] = 3;
            map[2, 3] = 2;

            var finder = new PathFinder();

            Assert.AreEqual(14, finder.FindGreatestValuePath(map, 3, 4));
        }
    }
}
