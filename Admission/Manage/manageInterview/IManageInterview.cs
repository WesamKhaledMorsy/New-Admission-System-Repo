namespace Admission.Manage.manageInterview
{
    public interface IManageInterview
    {
        void CreateNewInterview(InterviewDTO interview);
        void DeleteInterview(Guid id);
        void EditInterview(InterviewDTO interview);
        List<InterviewDTO> GetInterviewById (Guid id);
        List<InterviewDTO> GetInterviews();
        public InterviewFilterDTO GetInterviewsData();
    }
}
