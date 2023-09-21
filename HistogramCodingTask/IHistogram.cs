using System.Collections.Generic;

namespace HistogramCodingTask
{
    /// <summary>
    /// Represents a data structure for storing and accessing values distributed across histogram groups.
    /// </summary>
    public interface IHistogram
    {
        /// <summary>
        /// Retrieves the values representing the count for each group in the histogram.
        /// </summary>
        /// <returns>A list of counts for each histogram group.</returns>
        IList<int> GetValues();

        /// <summary>
        /// Retrieves the count for the specified group in the histogram by index.
        /// </summary>
        /// <param name="boundaryIdx">The index of the group whose count is to be retrieved.</param>
        /// <returns>The count of items in the specified group.</returns>
        int GetGroup(int boundaryIdx);
    }
}