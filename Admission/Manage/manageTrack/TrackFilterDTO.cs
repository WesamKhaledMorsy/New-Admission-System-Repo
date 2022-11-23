using Admission.Manage.manageRound;
using Admission.Manage.manageStudent;

namespace Admission.Manage.manageTrack
{
    public class TrackFilterDTO
    {
        public TrackFilterDTO()
        {
            Students= new List<StudentDTO>();
            Rounds = new List<RoundDTO>();
        }
        public List<StudentDTO> Students { get; set; }
        public List<RoundDTO> Rounds { get; set; }
    }
}
