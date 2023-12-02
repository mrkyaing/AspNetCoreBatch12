using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCPractice
{
    [MemoryDiagnoser]
    public class BottleneckProcessBenchmark
    {
        private const string csvString = "C";
        private const string csvString2 = ",";
        private static readonly BottleneckProcess process = new BottleneckProcess();

        [Benchmark]
        public void GetLastItemWithLinq()
        {
            process.GetLastItemWithLinq(csvString);
        }
        [Benchmark]
        public void GetLastItemWithArray()
        {
            process.GetLastItemWithArray(csvString2);
        }
        [Benchmark]
        public void GetTotalBetween1To5()
        {
            process.GetTotalBetween(1, 5);
        }
        [Benchmark]
        public void GetTotalBetween1To50()
        {
            process.GetTotalBetween(1, 5);
        }
    }
}
