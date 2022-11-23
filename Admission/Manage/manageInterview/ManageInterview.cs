using Admission.DB;
using Admission.Manage.manageInterviewer;
using Admission.Manage.manageStudent;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace Admission.Manage.manageInterview
{
    
    public class ManageInterview : IManageInterview
    {
 
        private readonly AppDbContext _dbContext;
        public ManageInterview(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public void CreateNewInterview(InterviewDTO interview)
        {
            var _interview = new Interview();
            _interview.Id = Guid.NewGuid();
            _interview.InterviewName = interview.InterviewName;
            _interview.InterviewerId=interview.InterviewerId;
            _interview.Count=interview.Count;
            _interview.StartDate=interview.StartDate;
            _interview.EndDate=interview.EndDate;
            _interview.StartTime=interview.StartTime;
            _interview.EndTime=interview.EndTime;



          

            

            int days = (int)(interview.EndDate-interview.StartDate).TotalDays;
           
            double hours =(interview.EndTime-interview.StartTime).Value.Hours;
            double minutes =(interview.EndTime-interview.StartTime).Value.Minutes;
            List<Student> studs = _dbContext.Students
                .Where(st => !st.IsDeleted  && st.StatusId== new Guid("5977FFEC-F62F-4F3B-1032-08DABFF46F5C"))
                .ToList();
            var pageIndex = 0;
            var pageSize = interview.Count.Value;

            for (int i = 0; i < days; i++)
            {
                var students = _dbContext.Students
                .Where(st => !st.IsDeleted && st.StatusId == new Guid("5977FFEC-F62F-4F3B-1032-08DABFF46F5C"))
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
                if (i == 0)
                {
                    var startTime = interview.StartDate;
                    foreach (var stud in students)
                    {

                        stud.InterviewDate = interview.StartDate;
                        //stud.InterviewDate = startTime;
                        startTime.AddMinutes(15);
                       

                    }
                }
                else 
                {
                    foreach (var stud in students)
                    {
                        stud.InterviewDate = interview.StartDate.AddDays(i);

                    }
                }
                
            }


           // List<Student> studentInterviewDate = new List<Student>();
       
           // studentInterviewDate=studs;
           // int studIndex = 0 ;
           //studIndex+= (int)interview.Count;

           // if (studIndex<studentInterviewDate.Count)
           // {
           //     var interviewStartdate = interview.StartDate;
           //     var interviewDate = interviewStartdate;
           //     var lastDate = interview.EndTime.Value;
           //     bool done = false;
           //     //for (  int i = 0; i<(interview.EndDate-interviewStartdate).TotalDays+1; i++)
           //     //{
           //        var allStudents = _dbContext.Students.Where(stud => !stud.IsDeleted && stud.InterviewDate==null).ToList();
           //        studIndex += (int)interview.Count;

           //         for (studIndex = 0; studIndex<studentInterviewDate.Count; studIndex++)
           //         {
           //             if (studIndex < interview.Count)
           //             {
           //                 allStudents[studIndex].InterviewDate=interviewDate;
           //                 interviewDate=interviewDate.AddMinutes(15);
           //                 lastDate = interviewDate;
           //             }                       
           //         }
                     
           //                 lastDate = interview.StartDate.AddDays(1);
                        
           //         for (studIndex=(int)((int)studentInterviewDate.Count-interview.Count); 
           //                 studIndex<=studentInterviewDate.Count;
           //                 studIndex--)
           //         {

           //             if (studIndex <= interview.Count && studIndex >0)
           //             {
           //                 // var newInterviewDate = interviewStartdate.AddDays(1);
           //                 //var newInterviewDate = interviewStartdate;
           //                 allStudents[studIndex].InterviewDate = lastDate;
           //                 interviewDate = (DateTime)allStudents[studIndex].InterviewDate;
           //                 lastDate = interviewDate.AddMinutes(15);
           //                 if (lastDate == interview.EndTime.Value)
           //                 {
           //                     done = true;

           //                 }
                                                 
           //             }
           //             else 
           //             {
           //                 done = true;
           //             }
           //         }
           //        // var newInterviewDate = interviewStartdate.AddDays(1);
           //         //lastDate =    interviewDate;
           //         //lastDate = newInterviewDate;
           //     //}
           //        // interviewStartdate = interviewStartdate.AddDays(1);                
           // }


            #region trial
            //if (interview.StudentId==null || interview.StartDate==null || interview.EndDate==null)
            //{
            //    var studentsNumber = _dbContext.Students.Count<Student>();
            //    for(int i=0;i<studentsNumber;i++)
            //    {
            //        _dbContext.Interviews.Where(st => !st.IsDeleted)
            //            .Select(std => new InterviewDTO()
            //            {
            //                StartDate=std.StartDate,
            //                EndDate=std.StartDate.AddMinutes(20),
            //                StudentId=std.StudentId,
            //            }).ToList();

            //    }
            //    var studentid = _dbContext.Students.Where(st => !st.IsDeleted)
            //          .Select( std => new Student()
            //          {
            //              Id=std.Id,
            //             InterviewId=std.InterviewId,
            //          }).ToList();
            //        //_dbContext.Students.Where(st => !st.IsDeleted)
            //        //.Select(st => st.Id == interview.StudentId);
            //    foreach (var studId in studentid)
            //    {

            //           interview.StudentId=studId.InterviewId;
            //         _interview.StudentId=interview.StudentId;

            //    }


            //}
            //else
            //{
            //    var studentsNumber = _dbContext.Students.Count<Student>();
            //    for (int i = 0; i<studentsNumber; i++)
            //    {
            //        _dbContext.Interviews.Where(st => !st.IsDeleted)
            //            .Select(std => new InterviewDTO()
            //            {
            //                StartDate=std.StartDate,
            //                EndDate=std.StartDate.AddHours(1),
            //                StudentId=std.StudentId,
            //            }).ToList();
            //    }
            //    _dbContext.Students.Where(st => !st.IsDeleted)
            //        .Select(st => st.Id == interview.StudentId);

            //    _interview.StudentId=interview.StudentId;

            //}
            ////_interview.StudentId=(Guid)interview.StudentId;
            #endregion
            _interview.AdminId= interview.AdminId;      
            this._dbContext.Interviews.Add(_interview);
            this._dbContext.SaveChanges();

            if (_interview==null)
            {
                throw new Exception("Put Interview");
            }
            else if (_interview.Student ==null)
            {
                try
                {

                    _dbContext.Students.Where(st => !st.IsDeleted)
                        .Select(__interview => new InterviewDTO()
                        {
                            //StudentId=interview.StudentId,
                           InterviewName=interview.InterviewName,
                        }).ToList();
                }
                catch
                {

                    throw new Exception("Student Field is required");
                }
            }

        }


        /*
         {
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "interviewName": "Web Interview22",
  "startDate": "2022-11-12T09:00:00Z",
  "endDate": "2022-11-14T22:00:00Z",
  "adminId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "startTime": "2022-11-12T09:00:00Z",
  "endTime": "2022-11-14T22:00:00Z",
  "interviewerId": "6d2e334b-b37e-46f7-8d0b-494640c1cb3d",
  "count": 5
}

         
         */
        public void DeleteInterview(Guid id)
        {
            var _interview = this._dbContext.Interviews.FirstOrDefault(t => t.Id==id);
            if (_interview !=null)
            {
                _interview.IsDeleted=true;
                this._dbContext.SaveChanges();
            }
        }
        public void EditInterview(InterviewDTO interview)
        {
            var _inter = this._dbContext.Interviews.Find(interview.Id); ;
            _inter.InterviewName=interview.InterviewName;
            _inter.StartDate=interview.StartDate;
            _inter.EndDate=interview.EndDate;
            //_inter.AdminId=interview.AdminId;
            this._dbContext.SaveChanges();
        }

        public List<InterviewDTO> GetInterviewById(Guid id)
        {
            var interview = _dbContext.Interviews.Where(gr => gr.Id==id)
                 .Include(gr => gr.Student)
                  .Select(inter => new InterviewDTO()
                  {
                      Id=inter.Id,
                      InterviewName=inter.InterviewName,
                      InterviewerId=inter.Id,
                      //StudentId=inter.Student.Id,
                     // StudentName=inter.Student.StudentName,
                      StartDate=inter.StartDate,
                      EndDate=inter.EndDate,

                      AdminId=inter.AdminId,

                  }).ToList();
            return interview;
        }

        public List<InterviewDTO> GetInterviews()
        {
            var interview = _dbContext.Interviews.Where(gr => !gr.IsDeleted)
                  .Include(tr => tr.Student)
                  .Select(inter => new InterviewDTO()
                  {
                      Id=inter.Id,
                      InterviewName=inter.InterviewName,
                      InterviewerId=inter.Id,
                      //StudentId=inter.Student.Id,
                     // StudentName=inter.Student.StudentName,
                      StartDate=inter.StartDate,
                      EndDate=inter.EndDate,

                      AdminId=inter.AdminId,
                  }).ToList();
            return interview;
        }

        public InterviewFilterDTO GetInterviewsData()
        {
            var dto = new InterviewFilterDTO();
            dto.Students = _dbContext.Students.Where(st => !st.IsDeleted)
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
            dto.Interviewers =_dbContext.Interviewers.Where(iinV => !iinV.IsDeleted)
                .Select(inv => new InterviewerDTO()
                {
                    Id= inv.Id,
                    StartDate=inv.StartDate,
                    EndDate = inv.EndDate,
                    InterviewerName=inv.InterviewerName,
                    //StudentId=inv.StudentId,
                    //InterviewName=inv.InterviewName,
                    //InterviewerId=inv.InterviewerId,
                    AdminId=inv.AdminId,
                }).ToList();

            return dto;
        }
    }
}
