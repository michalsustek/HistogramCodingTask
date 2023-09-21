using System.Collections.Generic;

namespace HistogramCodingTask
{
    /// <summary>
    /// Provides shared functionality for histogram operations.
    /// </summary>
    internal static class HistogramHelper
    {
        /// <summary>
        /// Ensures the initial item of the collection is set to 0.0.
        /// </summary>
        /// <param name="boundaries">The list of boundary values.</param>
        public static void EnsureFirstBoundaryIsZero(IList<double> boundaries)
        {
            if (boundaries[0] != 0d) boundaries.Insert(0, 0d);
        }
    }
}