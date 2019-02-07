namespace BookWormApi.Models
{
    /// <summary>
    /// Data contract for sending requests to the application
    /// </summary>
    public class TextParsingInput
    {
        /// <summary>
        /// The text to analyze
        /// </summary>
        public string Text { get; set; }
    }
}
