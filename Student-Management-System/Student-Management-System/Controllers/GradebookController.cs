using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradebookController : ControllerBase
    {

        #region Fields
        private readonly ITeacherService _teacherService;
        #endregion

        #region Controller
        public GradebookController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        #endregion

        #region
        [HttpGet]
        public IActionResult GetGradebook()
        {
            return Ok(_teacherService.GetGradebook());
        }

        [HttpPost]
        public IActionResult AddGradebook(AddGradebookDTO gradebook)
        {
            return Ok(_teacherService.AddGradebook(gradebook));
        }

        [HttpPut]
        public IActionResult UpdateGradebook(UpdateGradebookDTO gradebook)
        {
            return Ok(_teacherService.UpdateGradebook(gradebook));
        }

        #endregion
    }
}
