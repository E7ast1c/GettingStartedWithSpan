using BenchmarkDotNet.Running;
using System;

namespace GettingStartedWithSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ConcateString>();
        }
    }
}
