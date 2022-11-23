using Admission.Model.DomainModel;
using Admission.Manage.manageInterview;
using Admission.Manage.manageStudent;

namespace Admission.Manage.manageInterviewer
{
    public class InterviewerFilterDTO
    {
        public InterviewerFilterDTO()
        {
            Students = new List<StudentDTO>();
            Interviews = new List<InterviewDTO>();
        }
       public List<StudentDTO> Students { get; set; }
        public List<InterviewDTO> Interviews { get; set; }
    }
}
