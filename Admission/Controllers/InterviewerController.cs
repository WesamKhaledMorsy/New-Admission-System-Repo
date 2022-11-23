using Admission.Manage.manageInterviewer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {

        public IManageInterviewer _manageInterviewer { get; set; }
        public InterviewerController(IManageInterviewer manageInterviewer)
        {
            _manageInterviewer=manageInterviewer;
        }


       [Authorize]
        [HttpPost, Route("CreateNewInterviewer")]
        public void CreateNewInterviewer(InterviewerDTO interviewer)
          => _manageInterviewer.CreateNewInterviewer(interviewer);

        [Authorize]
        [HttpPut, Route("EditInterviewer")]
        public void EditInterviewer(InterviewerDTO interviewer)
            => _manageInterviewer.EditInterviewer(interviewer);

        [Authorize]
        [HttpDelete, Route("DeleteInterviewer")]
        public void DeleteInterviewer(Guid id)
            => _manageInterviewer.DeleteInterviewer(id);



        [HttpGet, Route("GetInterviewers")]
        public List<InterviewerDTO> GetInterviewers()
            => _manageInterviewer.GetInterviewers();

        [HttpGet, Route("GetInterviewerById")]
        public List<InterviewerDTO> GetInterviewerById(Guid id)
            => _manageInterviewer.GetInterviewerById(id);
        [HttpGet, Route("GetInterviewerByName")]
        public List<InterviewerDTO> GetInterviewerByName(string name)
           => _manageInterviewer.GetInterviewerByName(name);

        [HttpGet, Route("GetInterviewersData")]
        public InterviewerFilterDTO GetInterviewersData(string? name)
          => _manageInterviewer.GetInterviewersData(name);

    }
}
