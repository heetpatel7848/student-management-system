using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Controller
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(_studentService.GetStudent());
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentDTO student)
        {
            return Ok(_studentService.AddStudent(student));
        }

        [HttpGet("paginated")]
        public IActionResult GetStudentPaginated(int page, int limit)
        {
            return Ok(_studentService.GetStudentPaginated(page, limit));
        }

        [HttpGet("id")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(_studentService.GetStudentById(id));
        }

        [HttpPut]
        public IActionResult UpdateStudent(UpdateStudentDTO student)
        {
            return Ok(_studentService.UpdateStudent(student));
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            return Ok(_studentService.DeleteStudent(id));
        }


        #endregion
    }
}
