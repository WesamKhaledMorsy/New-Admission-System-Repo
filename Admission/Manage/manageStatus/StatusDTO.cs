using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageStatus
{
    public class StatusDTO
    {
        public Guid Id { get; set; }
        public string? StatusName { get; set; }

        public Guid? AdminId { get; set; }

        //[JsonIgnore]
        //public List<Student> Students { get; set; }
       // public Guid? StudentId { get; set; }
    }
}
