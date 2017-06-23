using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgos
{
    public class MergeSorter
    {
        public static List<int> MergeSort(List<int> input)
        {
            return recurseMerge(input);
        }

        private static List<int> recurseMerge(List<int> input)
        {
            if (input.Count == 0 || input.Count == 1)
            {
                return input;
            }

            int firstHalf;
            int secondHalf;
            if (input.Count % 2 == 0)
            {
                firstHalf = secondHalf = input.Count / 2;
            }
            else
            {
                firstHalf = input.Count / 2 + 1;
                secondHalf = input.Count / 2;
            }
                        
            var halfOne = recurseMerge(input.Take(firstHalf).ToList());
            var halfTwo = recurseMerge(input.Skip(firstHalf).Take(secondHalf).ToList());

            var returnValue = new List<int>();

            while (halfOne.Count > 0 || halfTwo.Count > 0)
            {
                if (halfOne.Count == 0)
                {
                    returnValue.Add(halfTwo[0]);
                    halfTwo = halfTwo.GetRange(1, halfTwo.Count - 1);
                }
                else if (halfTwo.Count == 0)
                {
                    returnValue.Add(halfOne[0]);
                    halfOne = halfOne.GetRange(1, halfOne.Count - 1);
                }
                else if (halfOne[0] > halfTwo[0])
                {
                    returnValue.Add(halfTwo[0]);
                    halfTwo = halfTwo.GetRange(1, halfTwo.Count - 1);
                }
                else
                {
                    returnValue.Add(halfOne[0]);
                    halfOne = halfOne.GetRange(1, halfOne.Count - 1);
                }
            }

            return returnValue;
        }
    }

    public class PairsForSumInArray
    {
        public static List<Tuple<int, int>> FindSumPairs(int[] values, int sum)
        {
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();

            Dictionary<int, List<int>> indexes = new Dictionary<int, List<int>>();
            for (int i = 0; i < values.Length; i ++)
            {
                if (!indexes.ContainsKey(values[i]))
                    indexes.Add(values[i], new List<int>());
                indexes[values[i]].Add(i);
            }

            for (int i = 0; i < values.Length; i ++)
            {
                int partner = sum - values[i];
                if (!indexes.ContainsKey(partner))
                    continue;

                foreach (int index in indexes[partner])
                {
                    if (index > i)
                        results.Add(new Tuple<int, int>(i, index));
                }
            }

            return results;
        }        
    }

    public class DuplicateFinder
    {

        // given a sorted array of length n+1 where values range from 1 to n, find the duplicate pair
        // Assumptions: contiguous, sorted array with only one duplicate pair.
        public static int FindDuplicate(int[] values)
        {
            return recurseHalfArray(values, 0, values.Length - 1);
        }

        private static int recurseHalfArray(int[] values, int startIndex, int endIndex)
        {
            int startValue = values[startIndex];
            int endValue = values[endIndex];

            if (startValue == endValue && values.Length > 1)
                return startValue;
            else if (startValue == endValue && (values.Length == 0 || values.Length == 1))
                return -1;

            int midIndex = ((endIndex - startIndex)/2) + startIndex;
            int middleValue = values[midIndex];

            int count = 0;
            for (int i = startIndex; i <= endIndex; i ++)
            {
                if (values[i] <= middleValue)
                    count++;
            }

            if (count > midIndex + 1)
                return recurseHalfArray(values, startIndex, count - 1);
            else
                return recurseHalfArray(values, count, endIndex);

        }

    }

    public class IndexToValueMatcher
    {
        public static int FindIndexWithMatchingValue(int[] values)
        {
            if (values.Length == 0)
                return -1;

            return recurseSearch(values, 0, values.Length - 1);
        }

        private static int recurseSearch(int[] values, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                if (values[startIndex] == startIndex)
                    return startIndex;
                else
                    return -1;
            }                

            int middleIndex = ((endIndex - startIndex) / 2) + startIndex;

            if (values[middleIndex] == middleIndex)
                return middleIndex;
            else if (values[middleIndex] > middleIndex)
                return recurseSearch(values, startIndex, middleIndex);
            else
                return recurseSearch(values, middleIndex + 1, endIndex);
        }
    }

    public class PathFinder
    {
        public struct PathHead
        {
            public int value;
            public int x;
            public int y;

            public PathHead(int value, int x, int y)
            {
                this.value = value;
                this.x = x;
                this.y = y;
            }
        }

        private Dictionary<Tuple<int, int>, int> maxValues = new Dictionary<Tuple<int, int>, int>();
        private Queue<PathHead> visitQueue = new Queue<PathHead>();

        public int FindGreatestValuePath(int[,] map, int n, int m)
        {            
            this.visitQueue.Enqueue(new PathHead(map[0, 0], 0, 0));

            while(visitQueue.Count > 0)
            {
                PathHead current = visitQueue.Dequeue();
                int x = current.x;
                int y = current.y;

                PathHead right;
                PathHead down;

                if (x + 1 <= n - 1)
                    right = new PathHead(current.value + map[x + 1, y], x + 1, y);
                else
                    right = new PathHead(-1, 0, 0);

                if (y + 1 <= m - 1)
                    down = new PathHead(current.value + map[x, y + 1], x, y + 1);
                else
                    down = new PathHead(-1, 0, 0);

                enqueueIfGreater(right);
                enqueueIfGreater(down);
            }

            return this.maxValues[new Tuple<int, int>(n - 1, m - 1)];
        }

        private void enqueueIfGreater(PathHead path)
        {
            if (path.value > 0)
            {
                var tupleLocation = new Tuple<int, int>(path.x, path.y);

                if (!maxValues.ContainsKey(tupleLocation))
                    maxValues.Add(tupleLocation, path.value);
                if (maxValues[tupleLocation] <= path.value)
                {
                    maxValues[tupleLocation] = path.value;
                    this.visitQueue.Enqueue(path);
                }
            }
        }
    }

    public class MaxHeap
    {

        private List<int> _values;
        public List<int> Values { get { return this._values; } }

        public MaxHeap()
        {
            this._values = new List<int>();
        }

        public MaxHeap(IEnumerable<int> values) : base()
        {
            this._values = values.ToList();
            Heapify();
        }

        // heapify
        // compare with children
        // if more extreme than a child,
        // heapify child,
        // then swap with child

        public void Heapify()
        {
            for (int i = _values.Count; i >= 0; i --)
            {
                heapRecurse(i, _values.Count - 1);
            }
        }

        public void Print()
        {
            printRecurse(0, 0);
        }

        public List<int> Sort()
        {
            List<int> returnValue = new List<int>();

            int lastHeapIndex = _values.Count - 1;
            int temp;
            while (lastHeapIndex >= 0)
            {
                returnValue.Add(_values[0]);
                temp = _values[0];
                _values[0] = _values[lastHeapIndex];
                _values[lastHeapIndex] = temp;
                lastHeapIndex--;
                heapRecurse(0, lastHeapIndex);
            }

            Heapify();
            return returnValue;
        }

        private void printRecurse(int index, int level)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            Console.WriteLine(new String('-', level) + _values[index].ToString());

            if (leftChildIndex >= _values.Count)
                return;

            printRecurse(leftChildIndex, level + 1);
            printRecurse(rightChildIndex, level + 1);
        }

        private void heapRecurse(int index, int endIndex)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex > endIndex || rightChildIndex > endIndex)
                return;

            int holder;
            if (_values[index] < _values[leftChildIndex])
            {
                holder = _values[index];
                _values[index] = _values[leftChildIndex];
                _values[leftChildIndex] = holder;
                heapRecurse(leftChildIndex, endIndex);                
            }
            if (_values[index] < _values[rightChildIndex])
            {
                holder = _values[index];
                _values[index] = _values[rightChildIndex];
                _values[rightChildIndex] = holder;
                heapRecurse(rightChildIndex, endIndex);                
            }
        }
    }
}
