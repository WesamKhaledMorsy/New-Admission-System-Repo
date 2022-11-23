using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageGrade
{
    public class GradeDTO
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public Guid? AdminId { get; set; }
        //[JsonIgnore]
        //public List<Student> Students { get; set; }
        //public Guid? StudentId { get; set; }
        //public string ? StudentName { get; set; }
    }
}
