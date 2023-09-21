using System;
using System.Collections.Generic;
using System.Linq;

namespace HistogramCodingTask
{
    /// <inheritdoc />
    public class Histogram : IHistogram
    {
        #region fields
        private readonly int[] _data;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Histogram"/> class.
        /// </summary>
        /// <param name="data">A collection of the histogram values.</param>
        public Histogram(IEnumerable<int> data)
        {
            _data = data?.ToArray() ?? throw new ArgumentNullException(nameof(data));
        }
        #endregion

        #region public methods
        /// <inheritdoc />
        public IList<int> GetValues() => _data.ToList();

        /// <inheritdoc />
        public int GetGroup(int boundaryIdx)
        {
            if (boundaryIdx < 0 || boundaryIdx >= _data.Length) throw new ArgumentOutOfRangeException(nameof(boundaryIdx), "Invalid boundary index");

            return _data[boundaryIdx];
        }
        #endregion
    }
}