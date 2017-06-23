using System;
using NUnit.Framework;
using LinkedLists;
using System.Collections.Generic;

namespace DataStructureTests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void MergeLinkedLists_Copy_Returns_CorrectlyMergedLists()
        {
            LinkedListNode list1 = new LinkedListNode(1);
            list1.Next = new LinkedListNode(3);
            list1.Next.Next = new LinkedListNode(5);

            LinkedListNode list2 = new LinkedListNode(2);
            list2.Next = new LinkedListNode(4);
            list2.Next.Next = new LinkedListNode(6);

            LinkedListNode merged = LinkedListMerger.MergeLinkedLists(list1, list2, true);

            int count = 0;
            LinkedListNode follower = merged;
            while (follower != null)
            {
                count++;
                follower = follower.Next;
            }

            Assert.AreEqual(6, count);
            Assert.AreEqual(list2.Value, merged.Next.Value);
        }

        [Test]
        public void MergeLinkedLists_Reference_Returns_CorrectlyMergedLists()
        {
            LinkedListNode list1 = new LinkedListNode(1);
            list1.Next = new LinkedListNode(3);
            list1.Next.Next = new LinkedListNode(5);

            LinkedListNode list2 = new LinkedListNode(2);
            list2.Next = new LinkedListNode(4);
            list2.Next.Next = new LinkedListNode(6);

            LinkedListNode merged = LinkedListMerger.MergeLinkedLists(list1, list2, false);

            int count = 0;
            LinkedListNode follower = merged;
            while (follower != null)
            {
                count++;
                follower = follower.Next;
            }

            Assert.AreEqual(6, count);
            Assert.AreEqual(list2, merged.Next);
        }

        [Test]
        public void PairwiseSwapper_Returns_SwappedList()
        {
            List<LinkedListNode> listOfNodes = new List<LinkedListNode>();
            for (int i = 0; i < 6; i++)
            {
                listOfNodes.Add(new LinkedListNode(i));
                if (i > 0)
                {
                    listOfNodes[i - 1].Next = listOfNodes[i];
                }
            }

            LinkedListNode newHead = PairWiseSwapper.Swap(listOfNodes[0]);

            Assert.AreEqual(newHead, listOfNodes[1]);
            Assert.AreEqual(newHead.Next, listOfNodes[0]);

            LinkedListNode twoDown = newHead.Next.Next;

            Assert.AreEqual(twoDown, listOfNodes[3]);
            Assert.AreEqual(twoDown.Next, listOfNodes[2]);
        }
    }
}
