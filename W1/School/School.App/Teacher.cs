using System;

namespace School.App
{
    class Teacher : Person
    {
        //Field
        public int office {get;set;}
        public double salary {get;set;}

        public string subject{get;set;}

        //Constructors
        public Teacher( int office, double salary, string subject, string name,string email,string address1, string address2, string city,string state,string zipcode)
        {
           this.office = office;
           this.salary = salary;
           this.subject = subject;
           this.name = name;
           this.email = email;
           this.address1 = address1;
           this.address2 = address2;
           this.city = city;
           this.state = state;
           this.zipcode = zipcode;
        }
        //Methods

                    // Teachers : child of Person
                // Office #
                // Salary
                // Subject

    }
}
