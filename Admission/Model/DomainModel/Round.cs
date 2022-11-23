namespace Admission.Model.DomainModel
{
    public class Round
    {
        public Guid Id { get; set; }
        public string? RoundName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartAdmission { get; set; }
        public DateTime EndAdmission { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations
        public List<Student>? Student { get; set; }
        public List<Track>? Track { get; set; }

        //withAdmin
        public Guid AdminId { get; set; }
        public Admin? Admin { get; set; }

        #endregion
    }
}
