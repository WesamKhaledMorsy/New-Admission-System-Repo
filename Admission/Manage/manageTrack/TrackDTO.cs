using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageTrack
{
    public class TrackDTO
    {
        public Guid Id { get; set; }
        public string? TrackName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid? AdminId { get; set; }
        public Guid RoundId { get; set; }
        public string? RoundName { get; set; }
        public string? TrackImage { get; set; }

        //[JsonIgnore]
        public List<Student>? Students { get; set; }
    }
}
