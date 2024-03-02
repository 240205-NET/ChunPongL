using System;
namespace School.App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("School Starting...");
            try
            {
                School mySchool = new School();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("School Ending...");
            // Persons : Abstract class
                // Name
                // Email
                // Address

            // Students : child of Person
                // schedule
                // Grades
                // GPA

            // Teachers : child of Person
                // Office #
                // Salary
                // Subject

            // Courses : Parent Class
                // Courses ID
                // Name
                // Department
                // Requirements
                // Creadit Hours

            // Classes : Child of Course
                // Location
                // Schedule
                // Instructor
                // Roster
                // Capacity
                // Section
        }
    }
}
