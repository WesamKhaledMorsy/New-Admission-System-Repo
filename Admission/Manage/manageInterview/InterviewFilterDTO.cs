using Admission.Manage.manageInterviewer;
using Admission.Manage.manageStudent;

namespace Admission.Manage.manageInterview
{
    public class InterviewFilterDTO
    {
        public InterviewFilterDTO()
        {
            Students = new List<StudentDTO>();
            Interviewers = new List<InterviewerDTO>();
        }
        public List<StudentDTO> Students { get; set; }
        public List<InterviewerDTO> Interviewers { get; set; }
    }
}
