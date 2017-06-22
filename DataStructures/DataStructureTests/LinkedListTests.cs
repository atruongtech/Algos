using System;
using NUnit.Framework;
using LinkedLists;

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
    }
}
