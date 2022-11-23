using Admission.DB;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Admission.Manage.manageRound
{
    public class ManageRound : IManageRound
    {
        private readonly AppDbContext _dbContext;
        public ManageRound(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreateNewRound(RoundDTO round)
        {
            var _round = new Round()
            {
                //Id = round.Id,
                RoundName = round.RoundName,
                StartAdmission = round.StartAdmission,
                EndAdmission = round.EndAdmission,
                StartDate = round.StartDate,
                EndDate = round.EndDate,      
                AdminId=round.AdminId,
            };
            this._dbContext.Rounds.Add(_round);
            this._dbContext.SaveChanges();
        }

        public void DeleteRound(Guid id)
        {
            var _round = this._dbContext.Rounds.FirstOrDefault(t => t.Id==id);
            var _student = this._dbContext.Students.Where(st => !st.IsDeleted && st.RoundId==id).ToList();
            var _track = this._dbContext.Tracks.Where(st => !st.IsDeleted && st.RoundId==id).ToList();
            if (_round != null || _student !=null|| _track !=null)
            {
                _round.IsDeleted =true;
                for(int i = 0; i < _student.Count; i++)
                {
                      _student[i].IsDeleted=true;
                }
                for (int i = 0; i < _track.Count; i++)
                {
                    _track[i].IsDeleted=true;
                }

                this._dbContext.SaveChanges();
            }
        }

        public void EditRound(RoundDTO round)
        {
            var _round = this._dbContext.Rounds.Find(round.Id);
            _round.RoundName=round.RoundName;
            _round.StartAdmission=round.StartAdmission;
            _round.EndAdmission=round.EndAdmission;
            _round.StartDate=round.StartDate;
            _round.EndDate=round.EndDate;
            this._dbContext.SaveChanges();
        }

        public List<RoundDTO> GetAllRounds(Guid? id, string? name, DateTime? startDate, DateTime? endDate,
            DateTime? startAdmission, DateTime? endAdmission,Guid ?adminId, int pageIndex, int pageSize)
        {
            var _round= _dbContext.Rounds.Where(ro=>!ro.IsDeleted&&
            (id ==null || ro.Id ==id)&&
                  (name ==null|| ro.RoundName.Contains(name))&&
                 (startDate==null ||ro.StartDate >= startDate)&&
                  (endDate ==null ||ro.EndDate <= endDate)&&
                (startAdmission==null ||ro.StartAdmission >= startAdmission)
                &&
                 (endAdmission ==null ||ro.EndAdmission <= endAdmission)
                 ).Include(s => s.Student)
              .Skip(pageSize*(pageIndex-1)).Take(pageSize)
                  .Select(round => new RoundDTO()
                  {
                      Id= round.Id,
                      RoundName= round.RoundName,
                      StartDate= round.StartDate,
                      EndDate= round.EndDate,
                      StartAdmission= round.StartAdmission,
                      EndAdmission= round.EndAdmission,
                      AdminId= round.AdminId,
                      Students=round.Student,
                      Tracks=round.Track
                  }).ToList();
       
            return _round;
        }

        public List<RoundDTO> GetRoundById(Guid id)
        {
            var round = this._dbContext.Rounds.Where(t => t.Id==id)
               .Include(s => s.Track)
               .Select(round => new RoundDTO()
               {
                   Id = round.Id,
                   RoundName= round.RoundName,
                   StartAdmission = round.StartAdmission,
                   EndAdmission=round.EndAdmission,
                   StartDate = round.StartDate,
                   EndDate = round.EndDate,
                   Tracks=round.Track,
                   Students=round.Student,
                   AdminId=round.AdminId
               }).ToList();
                if (_dbContext.Rounds.Where(x => x.Id==id) != null)
                {
                    return round;
                }
                else { throw new Exception("There is no Round With this Id"); }
        }

        public List<RoundDTO> GetRounds()
        {
            var _round = _dbContext.Rounds.Where(tr => !tr.IsDeleted)
                              .Select(round => new RoundDTO()
                              {
                                  Id=round.Id,
                                  RoundName=round.RoundName,
                                  StartDate=round.StartDate,
                                  EndDate= round.EndDate,
                                  StartAdmission = round.StartAdmission,
                                  EndAdmission= round.EndAdmission,
                                  AdminId=round.AdminId,
                              }).ToList();
            return _round;
        }
    }
}
