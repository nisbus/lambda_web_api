using BookWormApi.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookWormApi.Services
{
    /// <summary>
    /// A service to filter text into sentences, words and letters
    /// </summary>
    public static class TextStatisticsService
    {
        #region Fields

        static readonly Regex _SentenceRegex = new Regex(@"(?<=['""A-Za-z0-9][\.\!\?\;\/\-])\s+(?=[A-Z])", RegexOptions.IgnorePatternWhitespace);
        static readonly Regex _WordRegex = new Regex(@"(\W+)", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        static readonly Regex _LetterRegex = new Regex(@"^[a-zA-Z0-9]+$", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        #endregion

        #region API

        /// <summary>
        /// Applies regexes on the incoming text to split it into letters, words and sentences
        /// </summary>
        /// <param name="text">The text to analyze</param>
        /// <returns><see cref="TextStatistics"/>Statistics about the text</returns>
        public static TextStatistics CalculateStatistics(string text)
        {
            var stats = new TextStatistics();
            if (string.IsNullOrWhiteSpace(text))
                return stats;
            var letters = text.ToCharArray();            
            stats.Letters = letters;
            stats.Sentences = _SentenceRegex.Split(text).Where(sentence => !string.IsNullOrWhiteSpace(sentence));
            var words = _WordRegex.Split(text);
            stats.Words = words.Where(word =>
            {
                var isValid = IsValidWord(word);
                return !string.IsNullOrWhiteSpace(word) && !word.Contains('\n') && isValid;
            });
                
            return stats;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Filtering to remove invalid words, i.e. '.' '. ' etc.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns>Whether the word given is a valid word (only letters and numbers)</returns>
        private static bool IsValidWord(string word)
        {
            return _LetterRegex.IsMatch(word);
        }

        #endregion
    }
}
