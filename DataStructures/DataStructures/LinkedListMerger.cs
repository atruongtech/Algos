using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class LinkedListNode
    {
        public int Value;
        public LinkedListNode Next;

        public LinkedListNode(int value)
        {
            this.Value = value;
        }
    }

    public class LinkedListMerger
    {
        // merge two sorted linked lists
        public static LinkedListNode MergeLinkedLists(LinkedListNode firstRoot, LinkedListNode secondRoot, bool copy)
        {
            LinkedListNode newRoot = null;
            LinkedListNode newLinkedList;
            LinkedListNode firstFollower = firstRoot;
            LinkedListNode secondFollower = secondRoot;

            if (firstRoot == null && secondRoot == null)
                return null;
            if (firstRoot == null)
                return secondRoot;
            if (secondRoot == null)
                return firstRoot;
            
            if (firstFollower.Value <= secondFollower.Value)
            {
                newLinkedList = new LinkedListNode(firstFollower.Value);
                firstFollower = firstFollower.Next;
            }
            else
            {
                newLinkedList = new LinkedListNode(secondFollower.Value);
                secondFollower = secondFollower.Next;
            }

            newRoot = newLinkedList;

            bool looping = true;
            while (looping)
            {
                if (copy)
                    looping = assignNodes_NewCopy(ref newLinkedList, ref firstFollower, ref secondFollower);
                else
                    looping = assignNodes_Reference(ref newLinkedList, ref firstFollower, ref secondFollower);
            }

            return newRoot;
        }

        private static bool assignNodes_Reference(ref LinkedListNode newList, ref LinkedListNode firstFollower, ref LinkedListNode secondFollower)
        {
            if (firstFollower == null && secondFollower == null)
                return false;
            else if (firstFollower == null || (secondFollower != null && secondFollower.Value <= firstFollower.Value))
            {
                newList.Next = secondFollower;
                secondFollower = secondFollower.Next;
                newList = newList.Next;
                return true;
            }
            else
            {
                newList.Next = firstFollower;
                firstFollower = firstFollower.Next;
                newList = newList.Next;
                return true;
            }
        }

        private static bool assignNodes_NewCopy(ref LinkedListNode newList, ref LinkedListNode firstFollower, ref LinkedListNode secondFollower)
        {
            if (firstFollower == null && secondFollower == null)
                return false;
            else if (firstFollower == null)
            {
                newList.Next = new LinkedListNode(secondFollower.Value);
                secondFollower = secondFollower.Next;
                newList = newList.Next;
                return true;
            }
            else if (secondFollower == null)
            {
                newList.Next = new LinkedListNode(firstFollower.Value);
                firstFollower = firstFollower.Next;
                newList = newList.Next;
                return true;
            }
            else if (firstFollower.Value <= secondFollower.Value)
            {
                newList.Next = new LinkedListNode(firstFollower.Value);
                firstFollower = firstFollower.Next;
                newList = newList.Next;
                return true;
            }
            else if (secondFollower.Value < firstFollower.Value)
            {
                newList.Next = new LinkedListNode(secondFollower.Value);
                secondFollower = secondFollower.Next;
                newList = newList.Next;
                return true;
            }

            return false;
        }
        
    }
}
