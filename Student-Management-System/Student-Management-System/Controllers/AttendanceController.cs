using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;
using Student_Management_System.Services.Services;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        #endregion

        #region Controller
        public AttendanceController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        #endregion

        #region
        [HttpGet]
        public IActionResult GetAttendance()
        {
            return Ok(_teacherService.GetAttendance());
        }

        [HttpPost]
        public IActionResult AddAttendance(AddAttendanceDTO attendance)
        {
            return Ok(_teacherService.AddAttendance(attendance));
        }

        [HttpPut]
        public IActionResult UpdateAttendance(UpdateAttendanceDTO attendance)
        {
            return Ok(_teacherService.UpdateAttendance(attendance));
        }

        #endregion
    }
}
