using Admission.DB;
using Admission.Manage.manageRound;
using Admission.Manage.manageStudent;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Admission.Manage.manageTrack
{
    public class ManageTrack : IManageTrack
    {
        private readonly AppDbContext _dbContext;
        public ManageTrack(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateNewTrack(TrackDTO track)
        {
            var _track = new Track();

            _track.TrackName = track.TrackName;
            track.StartDate = track.StartDate;
            _track.EndDate = track.EndDate;
            _track.AdminId = (Guid)track.AdminId;
             _track.   RoundId = track.RoundId;
            //_track.TrackImage=
            //var Selectedfile = _dbContext.Tracks.FirstOrDefault(p => p.Id == track.Id);
            //var url = Selectedfile.TrackImage;
            //foreach (var file in files)
            //{

            //    var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Resources\\");
            //    bool basePathExists = System.IO.Directory.Exists(basePath);
            //    if (!basePathExists) Directory.CreateDirectory(basePath);
            //    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            //    var filePath = Path.Combine(basePath, file.FileName);
            //    var extension = Path.GetExtension(file.FileName);
            //    url = filePath;
            //    if (!System.IO.File.Exists(filePath))
            //    {
            //        using (var stream = new FileStream(filePath, FileMode.Create))
            //        {
            //            file.CopyTo(stream);

            //        }
            //        Selectedfile.TrackImage = @"./Resources/" + fileName + extension;

            //    }
            //}

            this._dbContext.Tracks.Add(_track);
            this._dbContext.SaveChanges();
            if (track == null)
            {
                throw new Exception("Put Track");
            }
        }

        public void DeleteTrack(Guid id)
        {
            var _track = this._dbContext.Tracks.FirstOrDefault(t => t.Id==id);
            if (_track != null)
            {
                _track.IsDeleted =true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditTrack(TrackDTO track)
        {
            var _track = this._dbContext.Tracks.Find(track.Id);
            _track.TrackName = track.TrackName;
            _track.StartDate = track.StartDate;
            _track.EndDate = track.EndDate;
            _track.RoundId=track.RoundId;
            this._dbContext.SaveChanges();
        }

        public List<TrackDTO> GetAllTracks(Guid ?id, string? name, DateTime? startDate, DateTime? endDate,
                    Guid? roundId, Guid? adminId, int pageIndex, int pageSize)
        {
            var _track = _dbContext.Tracks.Where(tr => !tr.IsDeleted

            && (name ==null|| tr.TrackName.Contains(name))&&
               (startDate==null ||tr.StartDate >= startDate)&&
               (endDate ==null ||tr.EndDate <= endDate)&&
               (roundId==null || tr.RoundId == roundId)&&
               (adminId ==null || tr.AdminId == adminId))
                .Include(s => s.Student)
            .Skip(pageSize*(pageIndex-1)).Take(pageSize)
            .Select(Track => new TrackDTO()
            {
                Id=Track.Id,
                TrackName=Track.TrackName,
                StartDate =Track.StartDate,
                EndDate =Track.EndDate,
                RoundId=Track.RoundId,
               RoundName= Track.Round.RoundName,
                AdminId=Track.AdminId,
                Students=Track.Student
            }).ToList();
            return _track;
        }
        public TrackFilterDTO GetAllTrackData()
        {
            var dto = new TrackFilterDTO(); 
            dto.Students =_dbContext.Students.Where(st => !st.IsDeleted)
                .Select(std => new StudentDTO()
                {
                    Id=std.Id,
                    StudentName=std.StudentName,
                    RoundId=std.RoundId,
                    GraduationYear = std.GraduationYear,
                    Email=std.Email,
                    PhoneNumber= std.PhoneNumber,

                }).ToList();

            dto.Rounds =_dbContext.Rounds.Where(r => !r.IsDeleted)
                .Select(rd => new RoundDTO()
                {
                    Id=rd.Id,
                    RoundName = rd.RoundName,
                    StartDate=rd.StartDate,
                    EndDate = rd.EndDate,
                    AdminId =rd.AdminId,
                }).ToList();
            return dto;
        }


        public List<TrackDTO> GetTrackById(Guid id)
        {
            var track = this._dbContext.Tracks.Where(t => t.Id==id)
                .Include(s => s.Student)
                .Select(tr => new TrackDTO()
                {
                    Id=tr.Id,
                    TrackName = tr.TrackName,
                    StartDate=tr.StartDate,
                    EndDate=tr.EndDate,
                    AdminId=tr.AdminId,
                    RoundId=tr.RoundId,
                    Students=tr.Student,
                    RoundName= tr.Round.RoundName,
                    

                }).ToList();
            return track;
        }

        public List<TrackDTO> GetTracks()
        {
            var _track = _dbContext.Tracks.Where(tr => !tr.IsDeleted)
             .Include(s => s.Student)
                  .Select(trk => new TrackDTO()
                  {
                      Id=trk.Id,
                      TrackName = trk.TrackName,
                      StartDate=trk.StartDate,
                      EndDate=trk.EndDate,
                      RoundName=trk.Round.RoundName,
                      RoundId=trk.RoundId,
                      Students=trk.Student,
                      TrackImage=trk.TrackImage,
                      AdminId=trk.AdminId,
                  }).ToList();
            return _track;
        }
    }
}

