using System;
using Xunit;
using GradeBook;
using System.Collections.Generic;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void AddGrade()
        {
            //arrange
            var testBook = new GradeBook.Book("test name");

            //act
            testBook.AddGrade(8);

            //assert
            Assert.Equal(8, testBook.Grades[0]);
        }

        [Theory]
        [InlineData(38.2, 19.4, 33.9, 30.5)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1.111, 2.222, 3.333, 2.222)]
        public void GradeAverage(double val1, double val2, double val3, double expectedAverage)
        {
            //arrange
            var testBook = new GradeBook.Book(new List<double>() { val1, val2, val3 });

            //act
            var result = testBook.GradeAverage();

            //assert
            Assert.Equal(expectedAverage, result);
        }

        [Theory]
        [InlineData(1, 2, 3, 3)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(45.3, 93.1, 84.2, 93.1)]
        public void GradeHigh(double val1, double val2, double val3, double expectedHigh)
        {
            var testBook = new GradeBook.Book(new List<double>() { val1, val2, val3 });
            var result = testBook.HighestGrade();
            Assert.Equal(expectedHigh, result);
        }
    }
}
