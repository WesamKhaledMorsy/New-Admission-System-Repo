namespace Admission.Model.DomainModel
{
    public class Interview
    {
        public Guid Id { get; set; }
        public string? InterviewName { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool IsDeleted { get; set; }

        #region Relations
        //with Interviewer
        public Guid? InterviewerId { get; set; }
        public Interviewer? Interviewer { get; set; }

        //with Student
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }

        public int? Count { get; set; }
        //withAdmin
        public Guid? AdminId { get; set; }
        public Admin? Admin { get; set; }
        #endregion
    }
}

