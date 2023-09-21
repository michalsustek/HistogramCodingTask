using System.Collections.Generic;

namespace HistogramCodingTask
{
    /// <summary>
    /// Represents a histogram builder that utilizes a nested loop approach.
    /// </summary>
    internal class HistogramBuilderIterations : IHistogramBuilder
    {
        /// <inheritdoc />
        public IHistogram CreateHistogram(double[] values, IList<double> boundaries)
        {
            HistogramHelper.EnsureFirstBoundaryIsZero(boundaries);

            var data = new int[boundaries.Count - 1];

            foreach (double value in values)
            {
                for (int i = 0; i < boundaries.Count - 1; i++)
                {
                    var lowerBoundary = boundaries[i];
                    var upperBoundary = boundaries[i + 1];

                    if (value >= lowerBoundary && value < upperBoundary)
                    {
                        data[i]++;
                        break;
                    }
                }
            }

            return new Histogram(data);
        }
    }
}