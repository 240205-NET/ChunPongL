using School.Logic;

namespace School.Data
{
    public interface IRepository
    {
        // we only list the Method signatures, no behaviors of fields
        public Task<IEnumerable<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task EnterNewStudentAsync(Student student);

        public Task DeleteStudentByIdAsync(int id);
        //public string MichaelsGetTeachersInfo();
        //public void NabinsAddStudent();
    }
}