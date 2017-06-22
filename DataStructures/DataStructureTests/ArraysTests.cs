using System;
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
    }
}
