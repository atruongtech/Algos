using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralAlgos
{
    public class FibonacciSequence
    {
        public Dictionary<int, int> pastValues = new Dictionary<int, int>();

        public int FibonacciOfN(int n)
        {
            if (n == 1 || n == 2)
                return 1;

            if (this.pastValues.ContainsKey(n))
                return this.pastValues[n];

            int retVal = FibonacciOfN(n - 2) + FibonacciOfN(n - 1);
            this.pastValues.Add(n, retVal);

            return retVal;
        }

    }
}
