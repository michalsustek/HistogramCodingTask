using System.Collections.Generic;
using System.Linq;

namespace HistogramCodingTask
{
    /// <summary>
    /// Represents a histogram builder that utilizes LINQ.
    /// </summary>
    internal class HistogramBuilderLinq : IHistogramBuilder
    {
        /// <inheritdoc />
        public IHistogram CreateHistogram(double[] values, IList<double> boundaries)
        {
            HistogramHelper.EnsureFirstBoundaryIsZero(boundaries);

            var data = boundaries.Take(boundaries.Count - 1)
                                 .Select((boundary, index) => values.Count(value => value >= boundary && value < boundaries[index + 1]));

            return new Histogram(data);
        }
    }
}