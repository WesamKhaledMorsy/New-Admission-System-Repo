using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageInterview
{
    public class InterviewDTO
    {
        public Guid Id { get; set; }
        public string? InterviewName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? AdminId { get; set; }
        [JsonIgnore]
        public List <Student>? Students { get; set; }
       // public Guid? StudentId { get; set; }
        //public string? StudentName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? InterviewerId { get; set; }

        public int? Count { get; set; }

    }
}