using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputs = new List<int>();
            inputs.Add(3);
            inputs.Add(35);
            inputs.Add(21);
            inputs.Add(10);
            inputs.Add(1);

            List<int> sorted = ArrayAlgos.MergeSorter.MergeSort(inputs);
            foreach(int number in sorted)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
