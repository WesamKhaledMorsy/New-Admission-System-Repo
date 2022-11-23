using Admission.DB;
using Admission.Manage.manageInterview;
using Admission.Manage.manageStudent;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Admission.Manage.manageInterviewer
{
    public class ManageInterviewer : IManageInterviewer
    {
        private readonly AppDbContext _dbContext;
        public ManageInterviewer(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreateNewInterviewer(InterviewerDTO interviewer)
        {
            var _interviewer = new Interviewer();
            _interviewer.Id =Guid.NewGuid() ;
            _interviewer.InterviewerName = interviewer.InterviewerName;
            _interviewer.StartDate=interviewer.StartDate;
        /*    _interviewer.EndDate=interviewer.StartDate.AddHours(8).AddDays(5);*/
            _interviewer.EndDate=interviewer.EndDate;


            //if (interviewer.Students==null)
            //{
            //    _dbContext.Students.Where(st => !st.IsDeleted)
            //        .Select(interviewer => new InterviewerDTO()
            //        {
            //            InterviewerName=interviewer.Interviewer.InterviewerName,
            //            StartDate=interviewer.Interviewer.StartDate,
            //            EndDate=interviewer.Interviewer.EndDate,

            //        }.Id).ToString();
              

            //}
            _interviewer.AdminId=(Guid) interviewer.AdminId;
            if(interviewer.StartDate ==null || interviewer.EndDate ==null)
            {
                _interviewer.StartDate =interviewer.StartDate;
                _interviewer.EndDate=interviewer.EndDate;
            }

            this._dbContext.Interviewers.Add(_interviewer);
            this._dbContext.SaveChanges();
            if (_interviewer==null)
            {
                throw new Exception("Put Interviewer");
            }
            else if (_interviewer.Student ==null)
            {
                try
                {

                    _dbContext.Students.Where(st => !st.IsDeleted)
                        .Select(__interview => new InterviewerDTO()
                        {
                           // StudentId=interviewer.StudentId,
                            //Interviews=interviewer.Interviews,
                            InterviewerName=interviewer.InterviewerName,
                        }).ToList();
                    _dbContext.Interviews.Where(st => !st.IsDeleted)
                        .Select(_interview => new InterviewerDTO()
                        {
                            //Interviews=interviewer.Interviews,
                            StartDate=interviewer.StartDate,
                            EndDate=interviewer.EndDate,
                            //StudentId=interviewer.StudentId,
                        }).ToList();
                }
                catch
                {

                    throw new Exception("Student Field is required");
                }
            }
        }

        public void DeleteInterviewer(Guid id)
        {
           var _interviewer = this._dbContext.Interviewers.FirstOrDefault(t => t.Id==id);
            if (_interviewer !=null)
            {
                _interviewer.IsDeleted=true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditInterviewer(InterviewerDTO interviewer)
        {
            var _interviewer = this._dbContext.Interviewers.Find(interviewer.Id); ;
            _interviewer.InterviewerName=interviewer.InterviewerName;
            _interviewer.StartDate=interviewer.StartDate;
            _interviewer.EndDate=interviewer.EndDate;
            _interviewer.AdminId = (Guid)interviewer.AdminId;
            //_interviewer.InterviewId=interviewer.Interviews;
            this._dbContext.SaveChanges();
        }

        public List<InterviewerDTO> GetInterviewerById(Guid id)
        {
            var interviewer = _dbContext.Interviewers.Where(gr => gr.Id==id)
                 //.Include(gr => gr.Student)
                 //.Include(inter => inter.InterviewId)
                  .Select(inter => new InterviewerDTO()
                  {
                      Id=inter.Id,
                      InterviewerName=inter.InterviewerName,                  
                      StartDate=inter.StartDate,
                      EndDate=inter.EndDate,
                      //Interviews=inter.InterviewId,
                      Students=inter.Student,
                      AdminId=inter.AdminId,

                  }).ToList();
            return interviewer;
        }

        public List<InterviewerDTO> GetInterviewerByName(string name)
        {
            var interviewer = _dbContext.Interviewers.Where(gr => gr.InterviewerName==name)
                  //.Include(gr => gr.Student)
                  //.Include(inter => inter.InterviewId)
                  .Select(inter => new InterviewerDTO()
                  {
                      Id=inter.Id,
                      InterviewerName=inter.InterviewerName,
                      StartDate=inter.StartDate,
                      EndDate=inter.EndDate,
                      //Interviews=inter.InterviewId,
                      Students=inter.Student,
                      AdminId=inter.AdminId,

                  }).ToList();
            return interviewer;

        }
        public List<InterviewerDTO> GetInterviewers()
        {
            var interviewer = _dbContext.Interviewers.Where(gr => !gr.IsDeleted)
                 .Include(tr => tr.Student)
                 .Include(_tr => _tr.InterviewId)
                 .Select(inter => new InterviewerDTO()
                 {
                     Id=inter.Id,
                     InterviewerName=inter.InterviewerName,                  
                     StartDate=inter.StartDate,
                     EndDate=inter.EndDate,

                     AdminId=inter.AdminId,
                 }).ToList();
            return interviewer;
        }

        public InterviewerFilterDTO GetInterviewersData(string? name)
        {
            var dto = new InterviewerFilterDTO();
            dto.Students = _dbContext.Students.Where(st => !st.IsDeleted && st.Interviewer.InterviewerName==name)
                .Select(std => new StudentDTO()
                {
                    Id = std.Id,
                    StudentName = std.StudentName,
                    InterviewerId=std.InterviewerId,
                    UniversityName = std.University.UniversityName,
                    GraduationYear = std.GraduationYear,
                    GradeValue = std.Grade.Value,
                    Email= std.Email,
                    StatusName=std.Status.StatusName,
                    PhoneNumber=std.PhoneNumber,


                }).ToList();
            dto.Interviews =_dbContext.Interviews.Where(iinV => !iinV.IsDeleted && iinV.Interviewer.InterviewerName==name)
                .Select(inv => new InterviewDTO()
                {
                    Id= inv.Id,
                    StartDate=inv.StartDate,
                    EndDate = inv.EndDate,
                    //StudentId=inv.StudentId,
                    InterviewName=inv.InterviewName,
                    InterviewerId=inv.InterviewerId,
                    AdminId=inv.AdminId,
                }).ToList();

            return dto;
        }

    }
}
