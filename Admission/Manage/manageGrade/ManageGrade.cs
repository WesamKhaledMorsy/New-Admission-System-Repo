using Admission.DB;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Admission.Manage.manageGrade
{
    public class ManageGrade : IManageGrade
    {
        private readonly AppDbContext _dbContext;
        public ManageGrade(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateNewGrade(GradeDTO grade)
        {
            var _Grade = new Grade()
            {
                Value=grade.Value,
              
                AdminId=(Guid)grade.AdminId,
            
            };
            this._dbContext.Grades.Add(_Grade);
            this._dbContext.SaveChanges();
            if(_Grade==null)
            {
                throw new Exception("Put Grade");
            }else if(_Grade.Students ==null)
            {
                _dbContext.Students.Where(st => !st.IsDeleted)
                  .Select(stu => new GradeDTO()
                  {
                      Value=stu.Grade.Value
                  }).ToList();
                //throw new Exception("Student Field is required");
            }
           
        }

        public void DeleteGrade(Guid id)
        {
            var _grade = this._dbContext.Grades.FirstOrDefault(t => t.Id==id);
            if(_grade !=null)
            {
                _grade.IsDeleted=true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditGrade(GradeDTO grade)
        {
            var _grade = this._dbContext.Grades.Find(grade.Id); ;

          
              if (grade.Id == null)
                {
                throw new Exception("Id is required");
                 grade.Id= _grade.Id;
             }
            if (grade.Value==null)
            {
                throw new Exception("Please Enter Grade value");
            }
            if (_grade.Value == null)
            {
                _dbContext.Students.Where(gr => !gr.IsDeleted)
                    .Select(grad => new GradeDTO()
                    {
                        Value=grad.Grade.Value
                    }).ToList();
                //throw new Exception("enter grade value");
            }
            _grade.Value=grade.Value;
            _grade.AdminId=(Guid)grade.AdminId;
            //_grade.Students=grade.Students;
            this._dbContext.SaveChanges();
        }

        public List<GradeDTO> GetAllGrades(Guid? id, int? value, Guid? adminId, int pageIndex, int pageSize)
        {
            var _grade = _dbContext.Grades.Where(gr => !gr.IsDeleted &&
            (value==null || gr.Value==value))
            .Include(gr => gr.Students)
            .Skip(pageSize*(pageIndex-1)).Take(pageSize)
            .Select(grade => new GradeDTO()
            {
                Id = grade.Id,
                Value=grade.Value,
               // Students=grade.Students,
                AdminId=grade.AdminId
            }).ToList();
            return _grade;
        }

        public List<GradeDTO> GetGradeById(Guid id)
        {
            var grade = _dbContext.Grades.Where(gr => gr.Id==id)
               .Include(gr =>gr.Students)
                .Select(tr => new GradeDTO()
                {
                    Id=tr.Id,
                    Value=tr.Value,
                    AdminId=tr.AdminId,
                    //Students=tr.Students

                }).ToList();
            return grade;
        }

        public List<GradeDTO> GetGrades()
        {
            var _grade = _dbContext.Grades.Where(gr => !gr.IsDeleted)
                .Include(tr => tr.Students)
                .Select(grad => new GradeDTO()
                {
                    Id=grad.Id,
                    Value=grad.Value,
                    AdminId=grad.AdminId,
                }).ToList();
            return _grade;
        }
    }
}
