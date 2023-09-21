using System.Collections.Generic;

namespace HistogramCodingTask
{
    /// <summary>
    /// Provides a contract for creating histograms.
    /// </summary>
    internal interface IHistogramBuilder
    {
        /// <summary>
        /// Creates a histogram based on the given values and boundaries.
        /// </summary>
        /// <param name="values">A collection of values to be categorized into groups.</param>
        /// <param name="boundaries">A collection of boundaries.</param>
        /// <returns>An instance of <see cref="IHistogram"/> representing the data distribution.</returns>
        IHistogram CreateHistogram(double[] values, IList<double> boundaries);
    }
}