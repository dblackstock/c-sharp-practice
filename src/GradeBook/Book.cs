using System.Text.RegularExpressions;

namespace GradeBook
{

    public interface IBook
    {
        void AddGrade(double grade);
        string[] ReadExistingGrades();
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

        public static bool IsGradeValid(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract string[] ReadExistingGrades();
    }
}