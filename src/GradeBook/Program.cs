using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Grade book for Davey");

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
                        book.AddGrade(letterInput);
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


            var result = book.GetStatistics();
            result.ShowStatistics();
        }
    }


}
