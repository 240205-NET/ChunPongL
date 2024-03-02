using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Fields
        private readonly IRepository _repo;
        private readonly ILogger<StudentController> _logger;

        // Constructor
        public StudentController(IRepository repo, ILogger<StudentController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        // Methods
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudentsAsync()
        {
            IEnumerable<Student> students;
            try
            {
                students = await _repo.GetAllStudentsAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return students.ToList();
        }

        // GET api/<StudentController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByIdAsync(int id)
        {
            Student student;
            try
            {
                student = await _repo.GetStudentByIdAsync(id);
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult> PostNewStudentAsync([FromBody] Student value)
        {
            Student newstudent = value;
            try
            {
                await _repo.EnterNewStudentAsync(newstudent);
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }

        // PUT api/<StudentController>/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
        }

        // DELETE api/<StudentController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudetByIdAsync(int id)
        {
            try
            {
                await _repo.DeleteStudentByIdAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
    }
}
