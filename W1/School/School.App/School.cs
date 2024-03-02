using System;

namespace School.App
{
    class School
    {
        //Field
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        Student newGuy = new Student("Arhur","no@no.com","This is", "","Wash" ,"DC","12345");
        Teacher newTeacher = new Teacher(100,10000.00,"Eng","Lai","no@no.com","This is", "","Wash" ,"DC","12345");
        //Constructor
        public School()
        {

        }
        //Methods
        public Student getStudent()
        {
            return newGuy;
        }
    }
}