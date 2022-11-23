namespace Admission.Manage.manageInterviewer
{
    public interface IManageInterviewer
    {
        void CreateNewInterviewer(InterviewerDTO interviewer);
        void DeleteInterviewer(Guid id);
        void EditInterviewer(InterviewerDTO interviewer);
        List<InterviewerDTO> GetInterviewerById(Guid id);
        List<InterviewerDTO> GetInterviewers();
        public InterviewerFilterDTO GetInterviewersData(string? name);
        public List<InterviewerDTO> GetInterviewerByName(string? name);
    }
}
