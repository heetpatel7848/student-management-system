using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        #endregion

        #region Controller
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetTeachers()
        {
            return Ok(_teacherService.GetTeacher());
        }

        [HttpPost]
        public IActionResult AddTeachers(AddTeacherDTO teacher)
        {
            return Ok(_teacherService.AddTeacher(teacher));
        }

        [HttpGet("paginated")]
        public IActionResult GetTeachersPaginated(int page, int limit)
        {
            return Ok(_teacherService.GetTeacherPaginated(page, limit));
        }

        [HttpGet("id")]
        public IActionResult GetteacherById(int id)
        {
            return Ok(_teacherService.GetTeacherById(id));
        }

        [HttpPut]
        public IActionResult Updateteacher(UpdateTeacherDTO teacher)
        {
            return Ok(_teacherService.UpdateTeacher(teacher));
        }

        [HttpDelete]
        public IActionResult DeleteTeacher(int id)
        {
            return Ok(_teacherService.DeleteTeacher(id));
        }


        #endregion
    }
}
