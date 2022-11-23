using Admission.DB;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Admission.Manage.manageUniversity
{
    public class ManageUniversity : IManageUniversity
    {
        private readonly AppDbContext _dbContext;
        public ManageUniversity(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateNewUniversity(UniversityDTO university)
        {
            var _university = new University()
            {
                UniversityName = university.UniversityName,
                // Students = status.Students,
               AdminId=(Guid)university.AdminId,

            };
            this._dbContext.Universities.Add(_university);
            this._dbContext.SaveChanges();
            if (_university==null)
            {
                throw new Exception("Put University");
            }
            else if (_university.Students ==null)
            {
                try
                {

                    _dbContext.Students.Where(st => !st.IsDeleted)
                        .Select(uni => new University()
                        {
                          UniversityName  =uni.University.UniversityName,
                        }).ToList();
                }
                catch
                {

                    throw new Exception("Student Field is required");
                }
            }
        }

        public void DeleteUniversity(Guid id)
        {
            var _university = this._dbContext.Universities.FirstOrDefault(t => t.Id==id);
            if (_university !=null)
            {
                _university.IsDeleted=true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditUniversity(UniversityDTO university)
        {
            var _uni = this._dbContext.Universities.Find(university.Id);
            if (university.Id!= _uni.Id)
            {
                university.Id= _uni.Id;
            }
            if (university.UniversityName=="string")
            {
                throw new Exception("Please Enter University Name");
                if(string.IsNullOrEmpty(_uni.UniversityName))
                {
                    throw new Exception("enter university name");
                }
               
            }
            _uni.UniversityName=university.UniversityName;
            
            // _status.Students=status.Students;
            _uni.AdminId=(Guid)university.AdminId;
            _dbContext.Update(_uni);
            this._dbContext.SaveChanges();
        }
        // <Guid("978E222B-0B74-4056-8B75-C5F5AD986C4A")>
        public List<UniversityDTO> GetUniversity()
        {
            var _university = _dbContext.Universities.Where(gr => !gr.IsDeleted)
                 .Include(tr => tr.Students)
                 .Select(uni => new UniversityDTO()
                 {
                     Id=uni.Id,
                    UniversityName=uni.UniversityName,
                     AdminId=uni.AdminId,
                 }).ToList();
            return _university;
        }

        public List<UniversityDTO> GetUniversityById(Guid id)
        {
            var university = _dbContext.Universities.Where(gr => gr.Id==id)
              .Include(gr => gr.Students)
               .Select(tr => new UniversityDTO()
               {
                   Id=tr.Id,
                 UniversityName=tr.UniversityName,
                   AdminId=tr.AdminId,
                   //Students=tr.Students

               }).ToList();
            return university;
        }
    }
}
