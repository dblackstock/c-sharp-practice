using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace GradeBook
{

    public interface IBook
    {
        void AddGrade(double grade);
        string[] ReadExistingGrades();
        // Statistics GetStatistics();
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

        public static bool IsGradeValid(string grade)
        {
            Regex gradeRegex = new Regex(@"^[ABCDF]$");
            var match = gradeRegex.Match(grade);
            return match.Success;
        }
        public abstract string[] ReadExistingGrades();

        // public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {

        private List<double> grades;
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

        public override void AddGrade(string grade)
        {
            if (IsGradeValid(grade))
            {
                var numberGrade = Statistics.LetterNumberGradeConvert(grade);
                AddGrade(numberGrade);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Valid grades are A,B,C,D,F.");
            }
        }

        public override event GradeAddedDelegate GradeAdded;
        public override string[] ReadExistingGrades() // In memory books have no capacity for reading in pre-existing grades
        { return new string[0]; }
    }
}