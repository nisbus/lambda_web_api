using System;
using System.Linq;

namespace BookWormApi.Services
{
    /// <summary>
    /// A service for sorting text according to the given sort type
    /// </summary>
    public static class TextSortingService
    {        
        /// <summary>
        /// Sorts the incoming text according to the sort type
        /// </summary>
        /// <param name="text">The text to sort</param>
        /// <param name="sortType">The type of sorting to apply</param>
        /// <returns></returns>
        public static string SortText(string text, SortType sortType)
        {
            var calculated = TextStatisticsService.CalculateStatistics(text);
            switch (sortType)
            {
                case SortType.Alphabetical:
                    if (calculated.SentenceCount == 1)
                        return string.Join(' ', calculated.Words.OrderBy(x => x));
                    return string.Join(' ', calculated.Sentences.OrderBy(x => x));                    
                case SortType.Length:
                    if (calculated.SentenceCount == 1)
                        return string.Join(' ', calculated.Words.OrderBy(x => x.Length));
                    return string.Join(' ', calculated.Sentences.OrderBy(x => x.Length));
                case SortType.Reverse:
                    if (calculated.SentenceCount == 1)
                        return string.Join(' ', calculated.Words.Reverse());
                    return string.Join(' ', calculated.Sentences.Reverse());
                default:
                    throw new NotImplementedException($"{sortType} sorting is not implemented by this service.");
            }
        }
    }
}
