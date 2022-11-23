using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageDocument
{
    public class DocumentDTO
    {
        public Guid Id { get; set; }
        public string DocumentName { get; set; }
        public Guid? AdminId { get; set; }
        public string ? filePath { get; set; }
        [JsonIgnore]
        public List<Student>? Students { get; set; }
        //public Student? Student { get; set; }
        public Guid? StudentId { get; set; }
      
    }
}
