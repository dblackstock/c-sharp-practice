using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;

        public void ShowStatistics()
        {
            Console.WriteLine($"The average grade is {Average:N1}");
            Console.WriteLine($"The highest grade is {High}");
            Console.WriteLine($"The lowest grade is {Low}");
        }

    }
}