using Microsoft.AspNetCore.Mvc;
using BookWormApi.Models;
using BookWormApi.Services;
using System;
using Amazon.S3;

namespace BookWormApi.Controllers
{
    /// <summary>
    /// Web API Controller for running text manipulation/statistics.
    /// </summary>
    [Route("api/Text")]
    public class TextParsingController : Controller
    {
        #region Fields

        readonly S3Persistence _Persister;

        #endregion

        #region CTOR

        /// <summary>
        /// The controller to start up for service requests
        /// </summary>
        /// <param name="s3Client">This client should save the requests and 
        /// responses to S3 Http enabled bucket but I didn't have time to finish it</param>
        public TextParsingController(IAmazonS3 s3Client)
        {
            _Persister = new S3Persistence(s3Client);
        }

        #endregion

        #region Routes

        /// <summary>
        /// Takes a text and sorts it according to the sort type given.
        /// If the text contains only one sentence it will sort the words in 
        /// the sentence.
        /// Otherwise it will sort the sentences.
        /// </summary>
        /// <param name="input"><see cref="TextParsingInput"/>The input text to sort</param>
        /// <param name="sortType"><see cref="SortType"/>The type of sorting to apply</param>
        /// <returns>The original text sorted according to the sort type</returns>
        [HttpPost]
        [Route("Sort/{sortType}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        public IActionResult Post([FromBody]TextParsingInput input, SortType sortType)
        {
            try
            {
                var result = TextSortingService.SortText(input.Text, sortType);
                //await persister.SaveRequest(new PersistedRequestResponse(input, result));
                return Ok(result);
            }
            catch (Exception e)
            {                
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Calculates some basic statistics about the given text.
        /// </summary>
        /// <param name="input"><see cref="TextParsingInput"/>The input text to analyze</param>
        /// <returns><see cref="TextStatistics"/>Basic statistics about the text provided</returns>
        [HttpPost]
        [Route("Statistics")]
        [ProducesResponseType(typeof(TextStatistics), 200)]
        [ProducesResponseType(typeof(Exception), 500)]        
        public IActionResult Post([FromBody]TextParsingInput input)
        {
            try
            {
                var result = TextStatisticsService.CalculateStatistics(input.Text);
                //await persister.SaveRequest(new PersistedRequestResponse(input, result));
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
