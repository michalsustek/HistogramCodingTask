
namespace HistogramCodingTask
{
    /// <summary>
    /// Specifies the algorithms available for generating histograms.
    /// </summary>
    public enum HistogramAlgorithm
    {
        /// <summary>
        /// Algorithm that utilizes a nested loop for optimal performance.
        /// </summary>
        Iterations,

        /// <summary>
        /// Implementation based on LINQ.
        /// </summary>
        Linq
    }
}