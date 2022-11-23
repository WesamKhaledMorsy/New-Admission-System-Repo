namespace Admission.Model.DomainModel
{
    public class Interviewer
    {
        public Guid Id { get; set; }
        public string? InterviewerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }


        #region Relations

        public List<Student>? Student { get; set; }
        public List<Interview>? InterviewId { get; set; }

        //withAdmin
        public Guid AdminId { get; set; }
        public Admin? Admin { get; set; }
        #endregion
    }
}
