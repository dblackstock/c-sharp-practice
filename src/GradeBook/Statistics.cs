using System;

namespace GradeBook
{
    public class Statistics
    {

        public Statistics()
        {
            Average = 0;
            High = double.MinValue;
            Low = double.MaxValue;
            Total = 0;
            Count = 0;
        }

        public double Average { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public string Letter { get; set; }
        public double Total { get; set; }
        public int Count { get; set; }

        public void AddGradeToStatistics(double grade) // Updates the statistics with the new grade
        {
            High = Math.Max(grade, High);
            Low = Math.Min(grade, Low);
            Total += grade;
            Count++;
            Average = Total / Count;

            Letter = LetterNumberGradeConvert(Average);

        }

        // loop to take an array of pre-saved results and them add them all to the statistics
        public void AddGradeArrayToStatistics(string[] grades)
        {
            double numberGrade;
            foreach (var grade in grades)
            {
                if (double.TryParse(grade, out numberGrade))
                {
                    AddGradeToStatistics(numberGrade);
                }
                else if (Book.IsGradeValid(grade))
                {
                    numberGrade = LetterNumberGradeConvert(grade);
                    AddGradeToStatistics(numberGrade);
                }

            }
        }

        public static string LetterNumberGradeConvert(double number)
        {
            switch (number)
            {
                case var d when d >= 90.0:
                    return "A";
                case var d when d >= 80.0:
                    return "B";
                case var d when d >= 70.0:
                    return "C";
                case var d when d >= 60.0:
                    return "D";
                default:
                    return "F";
            }
        }

        public static double LetterNumberGradeConvert(string letter)
        {
            switch (letter)
            {
                case var d when d == "A":
                    return 90.0;
                case var d when d == "B":
                    return 80.0;
                case var d when d == "C":
                    return 70.0;
                case var d when d == "D":
                    return 60.0;
                default:
                    return 0.0;
            }
        }

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