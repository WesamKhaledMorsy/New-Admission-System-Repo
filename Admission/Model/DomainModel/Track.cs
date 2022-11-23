namespace Admission.Model.DomainModel
{
    public class Track
    {
        public Guid Id { get; set; }
        public string? TrackName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TrackImage { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations
        //With Students
        public List<Student>? Student { get; set; }

        //With Round
        public Guid RoundId { get; set; }
        public Round? Round { get; set; }

        //withAdmin
        public Guid AdminId { get; set; }
        public Admin? Admin { get; set; }
        #endregion
    }
}
