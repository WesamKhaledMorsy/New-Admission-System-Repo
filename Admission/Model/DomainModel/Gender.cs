namespace Admission.Model.DomainModel
{
    public class Gender
    {
        public Guid Id { get; set; }
        public string? GenderType { get; set; }
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
