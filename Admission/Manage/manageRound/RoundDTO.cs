using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageRound
{
    public class RoundDTO
    {
        public Guid Id { get; set; }
        public string? RoundName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartAdmission { get; set; }
        public DateTime EndAdmission { get; set; }
        public Guid AdminId { get; set; }
        //[JsonIgnore]
        public List<Student>? Students { get; set; }
       // [JsonIgnore]
        public List<Track>? Tracks { get; set; }
    }
}
