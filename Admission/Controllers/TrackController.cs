using Admission.Manage.manageTrack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        public IManageTrack _manageTrack { get; set; }
        public TrackController(IManageTrack manageTrack)
        {
            _manageTrack=manageTrack;
        }

       // [Authorize]
        [HttpPost, Route("CreateNewTrack")]
        public void CreateNewTrack(TrackDTO track)
            => _manageTrack.CreateNewTrack(track);

        [Authorize]
        [HttpPut, Route("EditTrack")]
        public void EditTrack(TrackDTO track)
            => _manageTrack.EditTrack(track);

       [Authorize]
        [HttpDelete, Route("DeleteTrack")]
        public void DeleteTrack(Guid id) => _manageTrack.DeleteTrack(id);


        [Authorize]
        [HttpGet, Route("GetAllTracks")]

        public List<TrackDTO> GetAllTracks(Guid ?id, string? name, DateTime? startDate, DateTime? endDate, Guid? roundId, Guid? adminId, int pageIndex, int pageSize)
            => _manageTrack.GetAllTracks(id, name, startDate, endDate, roundId, adminId, pageIndex, pageSize);



        [HttpGet, Route("GetTracks")]
        public List<TrackDTO> GetTracks()
            => _manageTrack.GetTracks();

        [HttpGet, Route("GetTrackById")]
        public List<TrackDTO> GetTrackById(Guid id)
            => _manageTrack.GetTrackById(id);

        [HttpGet, Route("GetAllTrackData")]
        public TrackFilterDTO GetAllTrackData()
            => _manageTrack.GetAllTrackData();
    }
}
