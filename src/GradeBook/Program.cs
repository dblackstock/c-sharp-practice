using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new DiskBook("Grade book for Davey");
            // Book book = new InMemoryBook("Grade book for Davey");
            book.GradeAdded += OnGradeAdded; // subscribing to the event

            var statistics = new Statistics();
            var existingGrades = book.ReadExistingGrades();
            statistics.AddGradeArrayToStatistics(existingGrades);
            EnterGrades(book, statistics);

            statistics.ShowStatistics();
        }

        private static void EnterGrades(Book book, Statistics statistics)
        {
            var done = false;
            do
            {
                Console.WriteLine("Enter a grade between 0 and 100, or a letter grade. Stop entering grades by entering q.");
                var input = Console.ReadLine();
                double numberInput;
                char letterInput;
                if (double.TryParse(input, out numberInput)) //input is a number grade
                {
                    try
                    {
                        book.AddGrade(numberInput);
                        statistics.AddGradeToStatistics(numberInput);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (char.TryParse(input, out letterInput) && letterInput != 'q') // input is a letter grade
                {
                    try
                    {
                        book.AddGrade(input);
                        var numberGrade = Statistics.LetterNumberGradeConvert(input);
                        statistics.AddGradeToStatistics(numberGrade);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (char.TryParse(input, out letterInput) && letterInput == 'q') // input is quit
                {
                    Console.WriteLine("Returning the grade statistics...");
                    done = true;
                }
                else // input is not valid
                {
                    Console.WriteLine("Invalid code, please try again.");
                }
            } while (!done);
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade was added.");

        }
    }

}
