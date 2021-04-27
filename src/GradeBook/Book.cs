using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {

        private string name;
        private List<double> grades;
        // public List<double> grades = new List<double>();
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public Book(List<double> grades)
        {
            this.grades = grades;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<double> Grades
        {
            get => grades;
            set => grades = value;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{nameof(grade)} must be between 0 and 100");
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Valid grades are A,B,C,D,F.");
            }
        }

        public double GradeAverage()
        {
            double gradeAverage = 0;
            foreach (double element in grades)
            {
                gradeAverage += element;
            }
            return gradeAverage /= grades.Count;
        }

        public double HighestGrade()
        {
            double highestGrade = double.MinValue;
            foreach (double element in grades)
            {
                highestGrade = Math.Max(element, highestGrade);
            }
            return highestGrade;
        }
        public double LowestGrade()
        {
            double lowestGrade = double.MaxValue;
            foreach (double element in grades)
            {
                lowestGrade = Math.Min(element, lowestGrade);
            }
            return lowestGrade;
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = GradeAverage();
            result.Low = LowestGrade();
            result.High = HighestGrade();

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }
    }
}