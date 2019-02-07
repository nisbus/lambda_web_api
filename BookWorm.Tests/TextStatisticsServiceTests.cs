using BookWorm.Tests;
using BookWormApi.Models;
using BookWormApi.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace BookWormApi.Tests
{
    public class TextStatisticsServiceTests
    {
        private readonly ITestOutputHelper output;

        public TextStatisticsServiceTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GenerateQuery()
        {
            var f = File.OpenRead("../netcoreapp2.1/SampleRequests/republic.mb.txt");
            StreamReader sr = new StreamReader(f);
            TextParsingInput input = new TextParsingInput { Text = sr.ReadToEnd() };
            var json = JsonConvert.SerializeObject(input);
            output.WriteLine(json);
        }


        [Theory]
        [MemberData(nameof(SentanceCountSamples))]
        public void TestSentenceCount(string text, int expectedCount)
        {
            var stats = TextStatisticsService.CalculateStatistics(text);
            output.WriteLine(JsonConvert.SerializeObject(stats));
            Assert.Equal(expectedCount, stats.SentenceCount);
        }

        [Theory]
        [MemberData(nameof(WordCountSamples))]
        public void TestWordCount(string text, int expectedCount)
        {
            var stats = TextStatisticsService.CalculateStatistics(text);
            output.WriteLine(JsonConvert.SerializeObject(stats));
            Assert.Equal(expectedCount, stats.WordCount);
        }


        public static IEnumerable<object[]> SentanceCountSamples =>
            new List<object[]>
            {
                 new object[] { "", 0 },
                 new object[] { null, 0 },
                 new object[] { @"Provided by The Internet Classics Archive.
See bottom for copyright. Available online at
    http://classics.mit.edu//Plato/republic.html

The Republic
By Plato


Translated by Benjamin Jowett

----------------------------------------------------------------------

THE INTRODUCTION

The Republic of Plato is the longest of his works with the exception
of the Laws, and is certainly the greatest of them. There are nearer
approaches to modern metaphysics in the Philebus and in the Sophist;
the Politicus or Statesman is more ideal; the form and institutions
of the State are more clearly drawn out in the Laws; as works of art,
the Symposium and the Protagoras are of higher excellence. But no
other Dialogue of Plato has the same largeness of view and the same
perfection of style; no other shows an equal knowledge of the world,
or contains more of those thoughts which are new as well as old, and
not of one age only but of all.", 5},
                 new object[] { BookSample.TheRepublic(), 5397}

            };

        public static IEnumerable<object[]> WordCountSamples() =>
            new List<object[]>
            {
                 new object[] { "", 0 },
                 new object[] { null, 0 },
                 new object[] { @"Provided by The Internet Classics Archive.
See bottom for copyright. Available online at
    http://classics.mit.edu//Plato/republic.html

The Republic
By Plato


Translated by Benjamin Jowett

----------------------------------------------------------------------

THE INTRODUCTION

The Republic of Plato is the longest of his works with the exception
of the Laws, and is certainly the greatest of them. There are nearer
approaches to modern metaphysics in the Philebus and in the Sophist;
the Politicus or Statesman is more ideal; the form and institutions
of the State are more clearly drawn out in the Laws; as works of art,
the Symposium and the Protagoras are of higher excellence. But no
other Dialogue of Plato has the same largeness of view and the same
perfection of style; no other shows an equal knowledge of the world,
or contains more of those thoughts which are new as well as old, and
not of one age only but of all.", 151},    
                 new object[] { BookSample.TheRepublic(), 125264}
            };
    }
}
