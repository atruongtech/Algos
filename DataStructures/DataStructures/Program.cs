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
            GeneralAlgos.FibonacciSequence fib = new GeneralAlgos.FibonacciSequence();
            var output = fib.FibonacciOfN(50);

            var sorted = fib.pastValues.OrderBy(x => x.Key);
            foreach (KeyValuePair<int, int> pair in sorted)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            Console.ReadLine();
        }
    }
}
