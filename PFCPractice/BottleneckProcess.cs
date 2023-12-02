using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCPractice
{
    internal class BottleneckProcess
    {
        
        public string GetLastItemWithLinq(string csvString)
        {
            var items = csvString.Split(",");
            var lastItem = items.LastOrDefault();
            return lastItem ?? string.Empty;
        }
        public string GetLastItemWithArray(string csvString)
        {
            var items = csvString.Split(",");
            return items[items.Length - 1] ?? string.Empty;
        }
        public int GetTotalBetween(int start, int end)
        {   int total = 0;
            for(int i = start; i <= end; i++)
            {
                total+=i;
            }
            return total;
        }
    }
}
