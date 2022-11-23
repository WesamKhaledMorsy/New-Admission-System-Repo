namespace Admission.Model.DomainModel
{
    public class Status
    {
        public Guid Id { get; set; }
        public string? StatusName { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations
        //with Student
        public List<Student> Students { get; set; }
        //withAdmin
        public Guid AdminId { get; set; }
        public Admin? Admin { get; set; }
        #endregion
    }
}

