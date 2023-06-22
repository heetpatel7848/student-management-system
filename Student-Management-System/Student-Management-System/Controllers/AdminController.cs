using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Services.DTO.AddDTO;
using Student_Management_System.Services.DTO.UpdateDTO;
using Student_Management_System.Services.Interafce;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region Fields
        private readonly IAdminService _adminService;
        #endregion

        #region Controller
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetAdmin()
        {
            return Ok(_adminService.GetAdmin());
        }

        [HttpPost]
        public IActionResult AddAdmin(AddAdminDTO admin)
        {
            return Ok(_adminService.AddAdmin(admin));
        }

        [HttpGet("paginated")]
        public IActionResult GetAdminPaginated(int page, int limit)
        {
            return Ok(_adminService.GetAdminPaginated(page, limit));
        }

        [HttpGet("id")]
        public IActionResult GetAdminById(int id)
        {
            return Ok(_adminService.GetAdminById(id));
        }

        [HttpPut]
        public IActionResult UpdateAdmin(UpdateAdminDTO admin)
        {
            return Ok(_adminService.UpdateAdmin(admin));
        }

        [HttpDelete]
        public IActionResult DeleteAdmin(int id)
        {
            return Ok(_adminService.DeleteAdmin(id));
        }


        #endregion
    }
}
