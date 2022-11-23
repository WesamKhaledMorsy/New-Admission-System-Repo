using Admission.DB;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Admission.Manage.manageGender
{
    public class ManageGender : IManageGender
    {
        private readonly AppDbContext _dbContext;
        public ManageGender(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateNewGender(GenderDTO gender)
        {
            var _gender = new Gender()
            {
                GenderType = gender.GenderType,               
                AdminId=(Guid)gender.AdminId
            };
            this._dbContext.Genders.Add(_gender);
            this._dbContext.SaveChanges();
            if (_gender==null)
            {
                throw new Exception("Put Gender");
            }
            else if (_gender.Students ==null)
            {
                _dbContext.Students.Where(st => !st.IsDeleted)
                    .Select(stu => new GenderDTO()
                    {
                        GenderType=stu.Gender.GenderType
                    }).ToList();
               // throw new Exception("Student Field is required");
            }
        }

        public void DeleteGender(Guid id)
        {
            var _gender = this._dbContext.Genders.FirstOrDefault(t => t.Id==id);
            if (_gender !=null)
            {
                _gender.IsDeleted=true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditGender(GenderDTO gender)
        {
            var _gender = this._dbContext.Genders.Find(gender.Id);
            if (gender.Id == null)
            {
                throw new Exception("Id is required");
                gender.Id= _gender.Id;
            }
            if (gender.GenderType=="string")
            {
                throw new Exception("Please Enter Gender Type");
            }
            if (string.IsNullOrEmpty(_gender.GenderType))
            {
                throw new Exception("enter Gender Type");
            }
            _gender.GenderType=gender.GenderType;
           
            _gender.AdminId=(Guid)gender.AdminId;
            this._dbContext.SaveChanges();
        }

        public List<GenderDTO> GetGenderById(Guid id)
        {
            var gender = _dbContext.Genders.Where(gr => gr.Id==id)
               .Include(gr => gr.Students)
                .Select(tr => new GenderDTO()
                {
                    Id=tr.Id,
                    GenderType=tr.GenderType,
                    AdminId=tr.AdminId,
                   // Students=tr.Students

                }).ToList();
            return gender;
        }

        public List<GenderDTO> GetGenders()
        {
            var _gender = _dbContext.Genders.Where(gr => !gr.IsDeleted)
                .Include(tr => tr.Students)
                .Select(gender => new GenderDTO()
                {
                    Id=gender.Id,
                    GenderType=gender.GenderType,
                    AdminId=gender.AdminId,
                    
                }).ToList();
            return _gender;
        }
    }
}
