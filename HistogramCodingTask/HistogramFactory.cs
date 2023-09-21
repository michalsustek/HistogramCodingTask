using System;
using System.Collections.Generic;
using System.Linq;

namespace HistogramCodingTask
{
    /// <summary>
    /// Factory that generates histograms using different algorithms.
    /// </summary>
    public class HistogramFactory
    {
        #region fields
        private readonly Dictionary<HistogramAlgorithm, IHistogramBuilder> _instanceCache = new();
        private readonly object _lock = new();
        #endregion

        #region public methods
        /// <summary>
        /// Creates a histogram based on the given values, boundaries, and specified algorithm.
        /// </summary>
        /// <param name="values">A collection of values to be categorized into groups.</param>
        /// <param name="boundaries">A collection of boundaries.</param>
        /// <param name="algorithm">The algorithm to be used for creating the histogram.</param>
        /// <returns>An instance of IHistogram representing the data distribution.</returns>
        public IHistogram CreateHistogram(IEnumerable<double> values, IEnumerable<double> boundaries, HistogramAlgorithm algorithm)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (boundaries == null) throw new ArgumentNullException(nameof(boundaries));

            var boundariesList = boundaries.ToList();
            if (boundariesList.Count == 0) return new Histogram(new int[0]);

            var valuesArray = values.ToArray();
            if (valuesArray.Length == 0) return new Histogram(new int[boundariesList.Count]);

            var builder = GetBuilderInstance(algorithm);
            return builder.CreateHistogram(valuesArray, boundariesList);
        }
        #endregion

        #region non-public methods
        /// <summary>
        /// Gets or creates an instance of <see cref="IHistogramBuilder"/>.
        /// </summary>
        /// <remarks>
        /// This method is thread-safe.
        /// </remarks>
        private IHistogramBuilder GetBuilderInstance(HistogramAlgorithm algorithm)
        {
            lock (_lock)
            {
                if (!_instanceCache.TryGetValue(algorithm, out IHistogramBuilder instance))
                {
                    instance = CreateBuilderInstance(algorithm);
                    _instanceCache.Add(algorithm, instance);
                }
                return instance;
            }
        }

        /// <summary>
        /// Creates new instance of <see cref="IHistogramBuilder"/> based on the specified algorithm.
        /// </summary>
        private static IHistogramBuilder CreateBuilderInstance(HistogramAlgorithm algorithm)
        {
            return algorithm switch
            {
                HistogramAlgorithm.Iterations => new HistogramBuilderIterations(),
                HistogramAlgorithm.Linq => new HistogramBuilderLinq(),
                _ => throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null)
            };
        }
        #endregion
    }
}