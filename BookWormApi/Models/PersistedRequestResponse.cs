﻿using Newtonsoft.Json;

namespace BookWormApi.Models
{
    /// <summary>
    /// Class for holding the incoming request to the controller and it's
    /// response.
    /// Should be used to save the request/response pairs somewhere
    /// </summary>
    public class PersistedRequestResponse
    {
        #region Properties

        public TextParsingInput Request { get; set; }
        public TextStatistics Statistics { get; set; }
        public string Response { get; set; }

        #endregion

        #region CTOR

        /// <summary>
        /// Creates a new Request/Response pair
        /// </summary>
        /// <param name="input">The request received by the application</param>
        /// <param name="output">The response generated by the application</param>
        public PersistedRequestResponse(TextParsingInput input, TextStatistics output)
        {
            Request = input;
            Statistics = output;
        }

        /// <summary>
        /// Creates a new Request/Response pair
        /// </summary>
        /// <param name="input">The request received by the application</param>
        /// <param name="output">The response generated by the application</param>
        public PersistedRequestResponse(TextParsingInput input, string output)
        {
            Request = input;
            Response = output;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion
    }
}