using School.Logic;

namespace School.Data
{
    public interface IRepository
    {
        // we only list the Method signatures, no behaviors of fields
        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public string MichaelsGetTeachersInfo();
        public void NabinsAddStudent();
    }
}