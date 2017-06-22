using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgos
{
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
}
