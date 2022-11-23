using Admission.Model.DomainModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageInterviewer
{
    public class InterviewerDTO
    {
        public Guid Id { get; set; }
        public string? InterviewerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid AdminId { get; set; }
       // public Guid? InterviewId { get; set; }
        /// <summary>
        // [JsonIgnore]
        /// </summary>
        //public List<Interview>? Interviews { get; set; }

       // public Guid? StudentId { get; set; }

        /// <summary>
         [JsonIgnore]
        /// </summary>
        public List<Student> ?Students { get; set; }
    }
}
