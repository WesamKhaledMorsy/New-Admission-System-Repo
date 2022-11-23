using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageGender
{
    public class GenderDTO
    {
        public Guid Id { get; set; }
        public string? GenderType { get; set; }

        public Guid? AdminId { get; set; }
        //[JsonIgnore]
        //public List<Student> Students { get; set; }
        //public Guid? StudentId { get; set; }
    }
}
