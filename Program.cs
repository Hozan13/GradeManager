using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    internal class Program
    {
        static List<string> courses = new List<string>();
        static List<int> grades = new List<int>();

        static void AddCourse()
        {
            Console.WriteLine("Enter course name: ");
            string course = Console.ReadLine();
            while (String.IsNullOrEmpty(course))
            {
                Console.WriteLine("Course name can not be empty. Please enter a course name: ");
                course = Console.ReadLine(); 
            }

            Console.WriteLine("Enter grade (0 - 100): ");
            int grade;
            while (!int.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid input. Please enter a numeric grade between 0 and 100: ");
            }
            courses.Add(course);
            grades.Add(grade);
            Console.WriteLine("Course " + (course) + " with grade " + (grade) + " added successfully!");
        }

        static void ListGrades()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No grades available.");
                return;
            }

            Console.WriteLine("--- All Grades ---");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine( (i+1) + "." + courses[i] + ":" + grades[i] );
            }
        }

        static void CalculateAverage()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("No grades to calculate.");
                return;
            }

            double average = 0;
            foreach (int grade in grades)
            {
                average += grade;
            }
            
            average /= grades.Count;
            Console.WriteLine("The average grade is: " + average.ToString("F2"));
            
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--- Grade Manager ---");
                Console.WriteLine("1. Add Course and Grade");
                Console.WriteLine("2. List All Grades");
                Console.WriteLine("3. Calculate Average");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddCourse();
                }
                else if (choice == "2")
                {
                    ListGrades();
                }
                else if (choice == "3")
                {
                    CalculateAverage();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Exiting... Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
                Console.WriteLine();
            }
        }
    }
}
