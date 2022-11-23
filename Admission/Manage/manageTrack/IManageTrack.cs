namespace Admission.Manage.manageTrack
{
    public interface IManageTrack
    {
        void CreateNewTrack(TrackDTO track);
        void DeleteTrack(Guid id);
        void EditTrack(TrackDTO track);
        List<TrackDTO> GetAllTracks(Guid ?id, string? name, DateTime? startDate, DateTime? endDate,
            Guid? roundId,
            Guid? adminId, int pageIndex, int pageSize);
        List<TrackDTO> GetTrackById(Guid id);
        List<TrackDTO> GetTracks();
        public TrackFilterDTO GetAllTrackData();
    }
}
