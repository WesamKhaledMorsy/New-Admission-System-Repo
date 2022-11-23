namespace Admission.Manage.manageUniversity
{
    public class UniversityDTO
    {
        public Guid Id { get; set; }
        public string? UniversityName { get; set; }

        public Guid? AdminId { get; set; }
    }
}
