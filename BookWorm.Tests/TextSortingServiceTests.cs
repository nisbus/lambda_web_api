using BookWormApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookWormApi.Tests
{
    public class TextSortingServiceTests
    {
        [Fact]
        public void TestAlphabetizingSortOfWords()
        {
            
            var sorted = TextSortingService.SortText("This is a sample text to sort", SortType.Alphabetical);
            Assert.Equal("a is sample sort text This to", sorted);
        }

        [Fact]
        public void TestAlphabetizingSortOfSentences()
        {            
            var sorted = TextSortingService.SortText("This is a sample text to sort. And another one would be this.", SortType.Alphabetical);
            Assert.Equal("And another one would be this. This is a sample text to sort.", sorted);
        }

    }
}
