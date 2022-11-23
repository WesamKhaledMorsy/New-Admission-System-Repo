namespace Admission.Model.DomainModel
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string? AdminName { get; set; }
        public bool IsDeleted { get; set; }


        #region Relations
        public List<Student>? Student { get; set; }
        public List<Document> Documents { get; set; }
        public List<Grade> Grades { get; set; }
        public List<University> Universities { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Interviewer>? Interviewer { get; set; }
        public List<Interview>? Interviews { get; set; }
        public List<Round>? Round { get; set; }
        public List<Track>? Track { get; set; }
        #endregion

    }
}
