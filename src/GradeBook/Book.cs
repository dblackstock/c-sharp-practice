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
            this.name = name;
        }

        public Book(List<double> grades)
        {
            this.grades = grades;
        }

        public List<double> Grades
        {
            get => grades;
            set => grades = value;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
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

            return result;
        }
    }
}