namespace Admission.Model.DomainModel
{
    public class Grade
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations
        //with Student
        public List<Student>? Students { get; set; }

        //public Guid? StudentId { get; set; }
        //public Student? Student { get; set; }
        //withAdmin
        public Guid AdminId { get; set; }
        public Admin? Admin { get; set; }
        #endregion
    }
}
