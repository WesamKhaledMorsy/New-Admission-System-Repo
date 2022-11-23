using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel;
using Admission.Model.DomainModel;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Admission.Manage.manageStudent
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string? StudentName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? GraduationYear { get; set; }

        public Guid? StatusId { get; set; }
        [DefaultValue("Waiting for Interview")]
        public string? StatusName { get; set; }

        public Guid? UniversityId { get; set; }
        public string? UniversityName { get; set; }

        public int? GradeValue { get; set; }
        public Guid? GradeId { get; set; }
        public int? StudentGrade { get; set; }
        public DateTime? InterviewDate { get; set; }

        public Guid? AdminId { get; set; }

        public Guid? RoundId { get; set; }
        public string? RoundName { get; set; }

        public Guid? TrackId { get; set; }
        public string? TrackName { get; set; }

        public Guid? GenderId { get; set; }
        public string? GenderName { get; set; }

        public Guid? InterviewerId { get; set; }
        public string? InterviewerName { get; set; }
        public Guid? InterviewId { get; set; }
        public string? InterviewName { get; set; }

        //[JsonIgnore]
        //public List<Document>? Documents { get; set; }
        //public Guid? DocumentId { get; set; }
        //public string DocumentName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? StudentCertificate { get; set; }
        public string? UserName { get; set; }
        public Guid? UserId { get; set; }
    }
}
