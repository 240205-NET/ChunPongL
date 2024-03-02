using System;

namespace School.App
{
    class Student : Person 
    {
            // Students : child of Person
        // schedule
        // Grades
        // GPA

        // Field
        public double gpa {get;set;} = 0.0;
        // Constructor
        public Student(string name,string email,string address1, string address2, string city,string state,string zipcode)
        {
            this.name = name;
            this.email = email;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
        }
        // Methods
    }
}