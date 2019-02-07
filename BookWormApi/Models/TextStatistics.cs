using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BookWormApi.Models
{
    /// <summary>
    /// Data contract for returning statistics from a text
    /// </summary>
    public class TextStatistics
    {
        #region Properties

        /// <summary>
        /// A collection of the words from the incoming text
        /// </summary>
        [JsonIgnore]
        public IEnumerable<string> Words { get; set; }

        /// <summary>
        /// A collection of all the letters in the incoming text
        /// </summary>
        [JsonIgnore]
        public IEnumerable<char> Letters { get; set; }

        /// <summary>
        /// A collection of all the sentences in the incoming text
        /// </summary>
        [JsonIgnore]
        public IEnumerable<string> Sentences { get; set; }

        /// <summary>
        /// The number of words in the incoming text
        /// </summary>
        public int WordCount { get => Words?.Count() ?? 0; }

        /// <summary>
        /// The number of spaces in the incoming text
        /// </summary>
        public int SpaceCount { get => Letters?.Where(letter => letter == ' ').Count() ?? 0; }

        /// <summary>
        /// The number of letters in the incoming text
        /// </summary>
        public int LetterCount { get => Letters?.Count() ?? 0; }

        /// <summary>
        /// The number of hyphens in the incoming text
        /// </summary>
        public int HyphenCount { get => Letters?.Where(letter => letter == '(' || letter == ')').Count() ?? 0; }

        /// <summary>
        /// The number of sentences in the incoming text
        /// </summary>
        public int SentenceCount { get => Sentences?.Count() ?? 0; }

        #endregion
    }
}
