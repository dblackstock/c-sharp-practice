using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char Letter;

        public void ShowStatistics()
        {
            Console.WriteLine($"The average grade is {Average:N1}");
            Console.WriteLine($"The highest grade is {High}");
            Console.WriteLine($"The lowest grade is {Low}");
            Console.WriteLine($"The letter grade is {Letter}");
        }

        // create a constructor to initialise the fields
        // create a method to pass a new grade to the class, at which point it:
        // - replaces High or Low with it if needed
        // - adds it to a Total field
        // - increments a NumberOfGrades field by 1
        // Within ShowStatistics, include the logic to calculate the average and the letter grade

    }
}