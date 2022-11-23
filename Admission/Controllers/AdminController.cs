using Admission.Manage.manageAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IManageAdmin _manageAdmin { get; set; }
        public AdminController(IManageAdmin manageAdmin)
        {
            _manageAdmin=manageAdmin;
        }

        [HttpPost, Route("CreateNewAdmin")]
        public void CreateNewAdmin(AdminDTO admin)
            => _manageAdmin.CreateNewAdmin(admin);
        [HttpDelete, Route("DeleteAdmin")]
        public void DeleteAdmin(Guid id)
            => _manageAdmin.DeleteAdmin(id);
        [HttpPut, Route("EditAdmin")]
        public void EditAdmin(AdminDTO admin)
            => _manageAdmin.EditAdmin(admin);

        [HttpGet, Route("GetAllAdmins")]
        public List<AdminDTO> GetAllAdmins(Guid id, string? name, int pageIndex, int pageSize)
            => _manageAdmin.GetAllAdmins(id, name, pageIndex, pageSize);

        [HttpGet, Route("GetAdminById")]
        public List<AdminDTO> GetAdminById(Guid id)
            => _manageAdmin.GetAdminById(id);

        [HttpGet, Route("GetAdmins")]
        public List<AdminDTO> GetAdmins()
            => _manageAdmin.GetAdmins();
    }
}
