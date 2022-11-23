using Admission.DB;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Admission.Manage.manageStatus
{
    public class ManageStatus : IManageStatus
    {
        private readonly AppDbContext _dbContext;
        public ManageStatus(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateNewStatus(StatusDTO status)
        {
            var _status = new Status()
            {
               StatusName = status.StatusName,
               // Students = status.Students,
                AdminId=(Guid)status.AdminId,

            };
            this._dbContext.Statuses.Add(_status);
            this._dbContext.SaveChanges();
            if (_status==null)
            {
                throw new Exception("Put Status");
            }
            else if (_status.Students ==null)
            {
                try
                {

                _dbContext.Students.Where(st => !st.IsDeleted)
                    .Select(status => new Status()
                    {
                        StatusName=status.Status.StatusName,
                    }).ToList();
                }
                catch
                {

                throw new Exception("Student Field is required");
                }
            }
        }

        public void DeleteStatus(Guid id)
        {
            var _status = this._dbContext.Statuses.FirstOrDefault(t => t.Id==id);
            if (_status !=null)
            {
                _status.IsDeleted=true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditStatus(StatusDTO status)
        {
            var _status = this._dbContext.Statuses.Find(status.Id);
            if (status.Id == null)
            {
                throw new Exception("Id is required");
                status.Id= _status.Id;
            }
            if (status.StatusName=="string")
            {
                throw new Exception("Please Enter Status Name");
            }
             if (string.IsNullOrEmpty(_status.StatusName))
             {
                 throw new Exception("enter Status name");
             }
                _status.StatusName= status.StatusName;
           // _status.Students=status.Students;
            this._dbContext.SaveChanges();
        }

        public List<StatusDTO> GetStatusById(Guid id)
        {
            var status = _dbContext.Statuses.Where(gr => gr.Id==id)
              .Include(gr => gr.Students)
               .Select(tr => new StatusDTO()
               {
                   Id=tr.Id,
                   StatusName=tr.StatusName,
                   AdminId=tr.AdminId,
                    //Students=tr.Students

               }).ToList();
            return status;
        }

        public List<StatusDTO> GetStatus()
        {
            var _status = _dbContext.Statuses.Where(gr => !gr.IsDeleted)
                .Include(tr => tr.Students)
                .Select(grad => new StatusDTO()
                {
                    Id=grad.Id,
                    StatusName=grad.StatusName,
                    AdminId=grad.AdminId,
                }).ToList();
            return _status;
        }
    }
}
