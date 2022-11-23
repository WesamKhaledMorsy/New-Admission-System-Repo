

using Admission.Manage.manageUniversity;
using Admission.Manage.manageGender;
using Admission.Manage.manageStatus;
using Admission.Manage.manageDocument;
using Admission.Manage.manageTrack;
using Admission.Manage.manageRound;
using Admission.Manage.manageInterview;
using Admission.Manage.manageInterviewer;

namespace Admission.Manage.manageStudent
{
    public class StudentFilterDTO
    {
        public StudentFilterDTO()
        {
           // Grades=new List<GradeDTO>();
            Universities= new List<UniversityDTO>();
            Genders=new List<GenderDTO>();
            Statuses=new List<StatusDTO>();
            Documents=new List<DocumentDTO>();
            Tracks=new List<TrackDTO>();
            Rounds=new List<RoundDTO>();
            Interviews =new List<InterviewDTO>();
            Interviewers =new List<InterviewerDTO>();

        }
       // public List<GradeDTO> Grades { get; set; }
        public List<UniversityDTO> Universities { get; set; }
        public List<GenderDTO> Genders { get; set; }
        public List<StatusDTO> Statuses { get; set; }
        public List<DocumentDTO> Documents { get; set; }
        public List<TrackDTO> Tracks { get; set; }
        public List<RoundDTO> Rounds { get; set; }
        public List<InterviewDTO> Interviews { get; set; }
        public List<InterviewerDTO> Interviewers { get; set; }
    }
}
