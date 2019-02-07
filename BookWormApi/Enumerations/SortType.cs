using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWormApi
{
    /// <summary>
    /// Defines the type of sorting to be applied to the text
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// Sorts the text with words alphabetically
        /// </summary>
        Alphabetical,
        /// <summary>
        /// Reverses the word order in the text
        /// </summary>
        Reverse,
        /// <summary>
        /// Sorts the text by the length of the lines in the text
        /// </summary>
        Length
    }
}
