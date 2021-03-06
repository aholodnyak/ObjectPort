﻿namespace ObjectPort.Benchmarks
{
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<SimpleSerializationBenchmarks>();
            BenchmarkRunner.Run<SimpleDeserializationBenchmarks>();
            BenchmarkRunner.Run<SimpleSerializationBenchmarksCore>();
            BenchmarkRunner.Run<SimpleDeserializationBenchmarksCore>();

            BenchmarkRunner.Run<ConcurrentSerializationBenchmark>();
            BenchmarkRunner.Run<ConcurrentSerializationBenchmarkCore>();
            BenchmarkRunner.Run<ConcurrentDeserializationBenchmark>();
        }
    }
}
