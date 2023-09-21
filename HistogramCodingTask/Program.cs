using System;
using System.Diagnostics;

namespace HistogramCodingTask
{
    class Program
    {
        private static readonly double[] Values = { 1.28, 2.46, 4.97, 0.15, 3.24, 1.94, 4.58, 0.87, 2.51, 3.36, 4.12, 1.77, 2.89, 0.63, 3.05, 1.01, 4.70, 0.44, 2.26, 3.98, 1.50, 4.32, 0.28, 2.72, 3.64, 4.82, 1.09, 0.94, 2.14, 3.42, 1.23, 4.06, 0.78, 3.89, 2.54, 1.64, 4.28, 0.05, 3.18, 2.79, 0.50, 3.51, 1.30, 4.95, 2.01, 3.74, 0.32, 1.88, 4.45, 2.37, 3.11, 1.14, 0.66, 2.68, 4.14, 3.57, 1.42, 4.60, 0.91, 2.21, 3.29, 4.08, 1.53, 0.20, 2.93, 3.46, 1.67, 4.85, 0.55, 2.10, 3.92, 4.34, 1.26, 0.72, 2.48, 3.78, 1.06, 4.23, 0.39, 2.86, 1.35, 4.50, 0.81, 3.17, 2.30, 4.03, 1.19, 0.58, 2.64, 3.54, 0.98, 3.76, 2.21, 1.49, 4.72, 3.06, 0.35, 2.62, 1.21, 4.15 };
        private static readonly double[] Boundaries = { 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0 };

        static void Main(string[] args)
        {
            ConsoleOutput();
            //PerformanceTest();
        }

        /// <summary>
        /// Output to the console.
        /// </summary>
        private static void ConsoleOutput()
        {
            var factory = new HistogramFactory();
            var histogram = factory.CreateHistogram(Values, Boundaries, HistogramAlgorithm.Iterations);
            var result = histogram.GetValues();

            for (int i = 0; i < Boundaries.Length; i++)
            {
                Console.WriteLine($"{(i > 0 ? Boundaries[i - 1] : 0d):F1}-{Boundaries[i]:F1}: {result[i]}");
            }
        }

        /// <summary>
        /// Performance testing.
        /// </summary>
        private static void PerformanceTest()
        {
            var factory = new HistogramFactory();
            const int iterations = 100_000;

            Console.WriteLine($"Executing a test with {iterations:N0} iterations using all available algorithms:");

            foreach (HistogramAlgorithm algorithm in Enum.GetValues<HistogramAlgorithm>())
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < iterations; i++)
                {
                    factory.CreateHistogram(Values, Boundaries, algorithm);
                }
                sw.Stop();

                Console.WriteLine($"Algorithm '{algorithm}' finished in {sw.Elapsed.TotalMilliseconds:F0}ms");
            }

            Console.WriteLine("Finished testing...");
        }
    }
}
