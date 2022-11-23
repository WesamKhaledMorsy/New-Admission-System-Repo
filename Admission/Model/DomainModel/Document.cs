using System.Text.Json.Serialization;

namespace Admission.Model.DomainModel
{
    public class Document
    {

        public Guid Id { get; set; }
        public string? DocumentName { get; set; }
        public bool IsDeleted { get; set; }
        public string? filePath { get; set; }

        #region Relations
        //with Student
        [JsonIgnore]
        public List<Student> Students { get; set; }
        public Guid? StudentId { get; set; }
        //withAdmin
        public Guid AdminId { get; set; }
        public Admin? Admin { get; set; }
        #endregion
    }
}
