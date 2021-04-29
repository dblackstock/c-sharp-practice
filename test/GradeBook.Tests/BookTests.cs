using System;
using Xunit;
using GradeBook;
using System.Collections.Generic;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void AddsNewNumberGrade()
        {
            //arrange
            var testBook = new GradeBook.InMemoryBook("test name");

            //act
            testBook.AddGrade(8);

            //assert
            Assert.Equal(8, testBook.Grades[0]);
        }
        [Fact]
        public void AddsNewLetterGrade()
        {
            //arrange
            var testBook = new GradeBook.InMemoryBook("test name");

            //act
            testBook.AddGrade("B");

            //assert
            Assert.Equal(80, testBook.Grades[0]);
        }
        [Theory]
        [InlineData("A", true)]
        [InlineData("a", false)]
        [InlineData("AB", false)]
        [InlineData("65", false)]
        [InlineData("101", false)]
        public void CheckValidLetterGrades(string letterGrade, bool expectedValidity)
        {
            var actualValidity = Book.IsGradeValid(letterGrade);
            Assert.Equal(expectedValidity, actualValidity);
        }
    }
}
