using Xunit;

namespace GradeBook.Tests
{
    public class StatisticsTests
    {
        [Fact]
        public void CreatesNewStatisticsObject()
        {
            var stats = new GradeBook.Statistics();

            Assert.Equal(double.MinValue, stats.High);
            Assert.Equal(double.MaxValue, stats.Low);
            Assert.Equal(0, stats.Average);
            Assert.Equal(0, stats.Total);
            Assert.Equal(0, stats.Count);

        }

        [Fact]
        public void GradeAdd()
        {
            var stats = new GradeBook.Statistics();
            stats.AddGradeToStatistics(34.2);

            Assert.Equal(34.2, stats.High);
            Assert.Equal(34.2, stats.Low);
            Assert.Equal(34.2, stats.Average);
            Assert.Equal(34.2, stats.Total);
            Assert.Equal(1, stats.Count);
        }

        [Theory]
        [InlineData("38.2", "19.4", "33.9", 30.5, 38.2, 19.4, 91.5)]
        [InlineData("0", "0", "0", 0, 0, 0, 0)]
        [InlineData("1.111", "2.222", "3.333", 2.222, 3.333, 1.111, 6.666)]
        public void GradeAddMultiple(string val1, string val2, string val3, double expectedAverage, double expectedHigh, double expectedLow, double expectedTotal)
        {
            var stats = new GradeBook.Statistics();
            stats.AddGradeArrayToStatistics(new string[] { val1, val2, val3 });

            Assert.Equal(expectedHigh, stats.High);
            Assert.Equal(expectedLow, stats.Low);
            Assert.Equal(expectedAverage, stats.Average);
            Assert.Equal(expectedTotal, stats.Total);
            Assert.Equal(3, stats.Count);
        }

        [Fact]
        public void ConvertToLetterGrade()
        {
            var result = Statistics.LetterNumberGradeConvert(87.2);
            Assert.Equal("B", result);
        }

        [Fact]
        public void ConvertToNumberGrade()
        {
            var result = Statistics.LetterNumberGradeConvert("B");
            Assert.Equal(80.0, result);
        }


    }
}
