using Admission.Manage.manageInterview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        public IManageInterview _manageInterview { get; set; }
        public InterviewController(IManageInterview manageInterview)
        {
            _manageInterview=manageInterview;
        }


        //[Authorize]
        [HttpPost, Route("CreateNewInterview")]
        public void CreateNewInterview(InterviewDTO interview)
          => _manageInterview.CreateNewInterview(interview);

        [Authorize]
        [HttpPut, Route("EditInterview")]
        public void EditInterview(InterviewDTO interview)
            => _manageInterview.EditInterview(interview);

        [Authorize]
        [HttpDelete, Route("DeleteInterview")]
        public void DeleteInterview(Guid id)
            => _manageInterview.DeleteInterview(id);



        [HttpGet, Route("GetInterviews")]
        public List<InterviewDTO> GetInterviews()
            => _manageInterview.GetInterviews();

        [HttpGet, Route("GetInterviewById")]
        public List<InterviewDTO> GetInterviewById(Guid id)
            => _manageInterview.GetInterviewById(id);

        [HttpGet, Route("GetInterviewsData")]
        public InterviewFilterDTO GetInterviewsData()
             => _manageInterview.GetInterviewsData();
    }
}
