using Admission.DB;
using Admission.Manage.manageAdmin;
using Admission.Manage.manageGender;
using Admission.Manage.manageGrade;
using Admission.Manage.manageInterview;
using Admission.Manage.manageInterviewer;
using Admission.Manage.manageStudent;
using Admission.Manage.manageUniversity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public IManageGender _manageAdmin { get; set; }

        public IManageStudent _manageStudent { get; set; }
        public IManageGender _manageGender { get; set; }
        public IManageGrade _manageGrade { get; set; }
        public IManageUniversity _manageUniversity { get; set; }
        public IManageInterview _manageInterview { get; set; }
        public IManageInterviewer _manageInterviewer { get; set; }
        public DashboardController(IManageGender manageAdmin, AppDbContext dbContext)
        {
            _manageAdmin=manageAdmin;
        }

        [HttpGet,Route("StudentNumber")]
        public void StudentNumber()
        {
           var studentNumber =_manageStudent.GetStudents().Count;
        }

        // <Guid("54361529-D78B-4C78-AC96-3000F81860AF")>
    }
}
