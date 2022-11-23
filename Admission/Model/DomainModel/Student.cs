using Admission.DB;

namespace Admission.Model.DomainModel
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? StudentName { get; set; }
        public string?  PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? GraduationYear { get; set; }
        public int? StudentGrade { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string? ProfilePicture { get; set; }
        public string? StudentCertificate { get; set; }
        public bool IsDeleted { get; set; }

        #region relations
        public Guid? GenderId { get; set; }
        public Gender? Gender { get; set; }

        public Guid? UniversityId { get; set; }
        public University? University { get; set; }

        public Guid? StatusId { get; set; }
        public Status? Status { get; set; }

        public Guid? GradeId { get; set; }
        public Grade? Grade { get; set; }

        public List<Document>? Documents { get; set; }


        public Guid? TrackId { get; set; }
        public Track? Track { get; set; }

        public Guid? RoundId { get; set; }
        public Round? Round { get; set; }

        public Guid? AdminId { get; set; }
        public Admin? Admin { get; set; }

        public Guid?InterviewerId { get; set; }
        public Interviewer? Interviewer { get; set; }

        public Guid? InterviewId { get; set; }
        public List<Interview>? Interview { get; set; }

        public string? UserName { get; set; }
        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; }


        #endregion
    }
}
