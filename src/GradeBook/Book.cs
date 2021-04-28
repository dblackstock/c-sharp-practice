using System.Collections.Generic;
using System;

namespace GradeBook
{

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade); // every class that inherits from this must have an AddGrade method of this signature
        public abstract void AddGrade(string grade);

        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {

        private List<double> grades;
        // public List<double> grades = new List<double>();
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public InMemoryBook(string name, List<double> grades) : base(name)
        {
            this.grades = grades;
        }

        public List<double> Grades
        {
            get => grades;
            set => grades = value;
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{nameof(grade)} must be between 0 and 100");
            }
        }

        public override void AddGrade(string letter)
        {
            switch (letter)
            {
                case "A":
                    AddGrade(90);
                    break;
                case "B":
                    AddGrade(80);
                    break;
                case "C":
                    AddGrade(70);
                    break;
                case "D":
                    AddGrade(60);
                    break;
                case "F":
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

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
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