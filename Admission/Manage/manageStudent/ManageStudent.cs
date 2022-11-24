using Admission.DB;
using Admission.Manage.manageDocument;
using Admission.Manage.manageGender;
using Admission.Manage.manageGrade;
using Admission.Manage.manageInterview;
using Admission.Manage.manageInterviewer;
using Admission.Manage.manageRound;
using Admission.Manage.manageStatus;
using Admission.Manage.manageTrack;
using Admission.Manage.manageUniversity;
using Admission.Model.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Admission.Manage.manageStudent
{
    public class ManageStudent : IManageStudent
    {
        private readonly AppDbContext _dbContext;
        public ManageStudent(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public void CreateNewStudent(StudentDTO student)
        {
           
            var _student = new Student();
            _student.Id=Guid.NewGuid();
            _student.StudentName=student.StudentName;
            _student.PhoneNumber=student.PhoneNumber;
            //_student.Email=student.Email;
            _student.StudentGrade = student.StudentGrade;
            _student.GraduationYear=student.GraduationYear;
            _student.GenderId=student.GenderId;
            if (student.GenderId==null)
            {
                _dbContext.Genders.Where(gr => !gr.IsDeleted)
                    .Select(gen => new GenderDTO()
                    {
                        Id= gen.Id,
                        GenderType=gen.GenderType,
                    }).ToList();
            }

            _student.UniversityId=student.UniversityId;
            if (student.UniversityId==null)
            {
                _dbContext.Universities.Where(un => !un.IsDeleted)
                    .Select(uni => new UniversityDTO()
                    {
                        Id= uni.Id,
                        UniversityName=uni.UniversityName,
                    }).ToList();
            }

            //_student.Documents=student.Documents;
            _student.StatusId=student.StatusId;
            if (student.StatusId==null)
            {
                _student.StatusId=new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7");
                //var statuses = _dbContext.Statuses.Where(status => !status.IsDeleted).ToList();
                //foreach (var status in statuses)
                //{
                //    if(status.StatusName.Contains("Waiting for Interview"))
                //    {
                //        student.StatusId = status.Id;
                //        _student.StatusId=student.StatusId;
                //    }
                //}
            }

           
            _student.TrackId=student.TrackId;
            if (student.TrackId==null)
            {
                _dbContext.Tracks.Where(trak => !trak.IsDeleted)
                    .Select(trak => new TrackDTO()
                    {
                        Id = trak.Id,
                        TrackName=trak.TrackName,
                    }).ToList();
            }
            _student.RoundId=student.RoundId;

            if (student.RoundId==null)
            {
                _dbContext.Rounds.Where(roun => !roun.IsDeleted)
                    .Select(roun => new RoundDTO()
                    {
                        Id = roun.Id,
                        RoundName=roun.RoundName,
                    }).ToList();
            }

            _student.UserName=student.UserName;
            _student.UserId=student.UserId;
            _student.AdminId=student.AdminId;
            this._dbContext.Students.Add(_student);
            this._dbContext.SaveChanges();
        }

        
        public void UploadDocuments(DocumentDTO studentDOC)
        {
            var _document = new Document();


                _document.Id=studentDOC.Id;
            _document.DocumentName=studentDOC.DocumentName;
            _document.StudentId=studentDOC.StudentId;
            if(studentDOC.StudentId==null)
            {
                _dbContext.Documents.Where(st => !st.IsDeleted)
                    .Select(doc => new DocumentDTO()
                    {
                        Id=doc.Id,  
                        DocumentName=doc.DocumentName,
                        StudentId=doc.StudentId,
                        AdminId=doc.AdminId
                      
                    }).ToList();
            }
            _document.Students=studentDOC.Students;
            if (studentDOC.Students==null)
            {
                _dbContext.Students.Where(st => !st.IsDeleted)
                    .Select(doc => new DocumentDTO()
                    {
                        StudentId=doc.Id,
                        
                        AdminId=doc.AdminId

                    }).ToList();
            }
           
            _document.AdminId=(Guid)studentDOC.AdminId;
            
            
            this._dbContext.Documents.Add(_document);
            this._dbContext.SaveChanges();
        }



        /// <summary>
        /// /////////////
        /// </summary>
        /// <param name="id"></param>
        public void DeleteStudent(Guid id)
        {
            var _student = this._dbContext.Students.FirstOrDefault(t => t.Id==id);
            if (_student != null)
            {
               _student.IsDeleted =true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditStudent(StudentDTO student)
        {
            var _student = _dbContext.Students.Find(student.Id);
      
            _student.StudentName=student.StudentName;
            //_student.UserId=student.UserId;
            //_student.UserName=student.UserName;
            _student.PhoneNumber=student.PhoneNumber;
            //_student.Status.StatusName=student.StatusName;
            //_student.GradeId=student.GradeId;
            // _student.Grade.Value=(int)student.GradeValue;
                var statuses = _dbContext.Statuses.Where(status => !status.IsDeleted).ToList();
            _student.StudentGrade = student.StudentGrade;
            if (_student.InterviewDate<DateTime.Now)
            {                               
               foreach (var status in statuses)
               {
                   if (status.StatusName.Contains("Missed"))
                   {
                        _student.StatusId = status.Id;
                        student.StatusId=_student.StatusId;
                   }
               }
            }else if (_student.StudentGrade<50)
            {
                foreach (var status in statuses)
                {
                    if (status.StatusName.Contains("Rejected"))
                    {
                        _student.StatusId = status.Id;
                        student.StatusId=_student.StatusId;
                    }
                }
            }else if (_student.StudentGrade>50)
            {
                foreach (var status in statuses)
                {
                    if (status.StatusName.Contains("Accepted"))
                    {
                        _student.StatusId = status.Id;
                        student.StatusId=_student.StatusId;
                    }
                }
            }
            //_student.StatusId=student.StatusId;
            _student.GraduationYear=student.GraduationYear;
            _student.GenderId=student.GenderId;
            // _student.Gender.GenderType=student.GenderName;
            _student.InterviewId=student.InterviewId;
            _student.InterviewerId=student.InterviewerId;
            //  _student.Interviewer.InterviewerName=student.InterviewerName;
            // _student.Email=student.Email;
            _student.TrackId=student.TrackId;
            // _student.Track.TrackName=student.TrackName;
            _student.RoundId=student.RoundId;
            // _student.Round.RoundName=student.RoundName;
            _student.UniversityId=student.UniversityId;
            // _student.University.UniversityName=student.UniversityName;


            _dbContext.SaveChanges();
        }


        public List<StudentDTO> GetAllStudents(string? name, string? email,
            Guid? statusId, int pageIndex, int pageSize)
        {
            var _student =_dbContext.Students.Where(st=>!st.IsDeleted &&
            
            (name==null|| st.StudentName.Contains(name))&&
            (email==null || st.Email.Contains(email))&&
            (statusId==null || st.StatusId== statusId)
           ).Skip(pageSize*(pageIndex-1)).Take(pageSize)
           .Include(st => st.Documents)
            .Select(student => new StudentDTO()
             {
                Id=student.Id,
                StudentName=student.StudentName,
                PhoneNumber=student.PhoneNumber,
                Email=student.Email,
                GraduationYear=student.GraduationYear,
                UniversityId=student.UniversityId,
                UniversityName=student.University.UniversityName,
                //GradeId=student.GradeId,
                //GradeValue=student.Grade.Value,
                StudentGrade=student.StudentGrade,
                GenderName=student.Gender.GenderType,
                GenderId=student.GenderId,
                StatusId=student.StatusId,
                StatusName=student.Status.StatusName,
                RoundId=student.RoundId,
                RoundName=student.Round.RoundName,
                TrackId=student.TrackId,
                TrackName=student.Track.TrackName,
                InterviewerId=student.InterviewerId,
                InterviewerName=student.Interviewer.InterviewerName,
                InterviewId=student.InterviewId,
                //InterviewName=student.Interview.FirstOrDefault().InterviewName,
                //Documents=student.Documents,
                UserId=student.UserId,
                UserName=student.UserName,
                ProfilePicture=student.ProfilePicture,
                StudentCertificate=student.StudentCertificate,
                InterviewDate=student.InterviewDate,
                AdminId=student.AdminId
                //Documents=student.Documents,
            }).ToList();
            var statuses = _dbContext.Statuses.Where(status => !status.IsDeleted).ToList();
            foreach (var stud in _student)
            {
                if (stud.InterviewDate<DateTime.Now)
                {
                    foreach (var status in statuses)
                    {
                        if (status.StatusName.Contains("Missed"))
                        {
                            stud.StatusId = status.Id;
                            stud.StatusName=status.StatusName;
                        }
                    }

                }
            }
                return _student;
        }

        public List<StudentDTO> GetStudentById(Guid id)
        {
            var student = _dbContext.Students.Where(st => st.Id==id)
                .Include(st => st.Documents)
                .Select(student => new StudentDTO()
                {
                    Id=student.Id,
                    StudentName=student.StudentName,
                    PhoneNumber=student.PhoneNumber,
                    Email=student.Email,

                    GraduationYear=student.GraduationYear,
                    UniversityId=student.UniversityId,
                    UniversityName=student.University.UniversityName,
                    //GradeId=student.GradeId,
                    //GradeValue=student.Grade.Value,
                    StudentGrade=student.StudentGrade,
                    GenderName=student.Gender.GenderType,
                    GenderId=student.GenderId,
                    StatusId=student.StatusId,
                    StatusName=student.Status.StatusName.ToLower(),
                    RoundId=student.RoundId,
                    RoundName=student.Round.RoundName,
                    TrackId=student.TrackId,
                    TrackName=student.Track.TrackName,
                    InterviewerId=student.InterviewerId,
                    InterviewerName=student.Interviewer.InterviewerName,
                    //Documents=student.Documents, //
                    InterviewId=student.InterviewId,
                    InterviewName=student.Interview.FirstOrDefault().InterviewName,
                    //UserId=student.UserId,
                    UserName=student.UserName,
                    ProfilePicture=student.ProfilePicture,  
                    //StudentCertificate=student.StudentCertificate,
                    InterviewDate=student.InterviewDate,
                    AdminId=student.AdminId
                }).ToList();
            var statuses = _dbContext.Statuses.Where(status => !status.IsDeleted).ToList();
            foreach (var stud in student)
            {
                if (stud.InterviewDate<DateTime.Now)
                {
                    foreach (var status in statuses)
                    {
                        if (status.StatusName.Contains("Missed"))
                        {
                            stud.StatusId = status.Id;
                            stud.StatusName=status.StatusName;
                            for(int i=0; i<student.Count; i++)
                            {
                                student[i].StatusId=stud.StatusId;
                                student[i].StatusName=stud.StatusName;
                            }
                        }
                    }

                }
            }

            if (_dbContext.Students.Where(x => x.Id==id) != null)
            {
                return student ;
            }
            else { throw new Exception("There is no student with this Id"); }
         
        }

        public List<StudentDTO> GetStudentByUserName(string userName)
        {
            var student = _dbContext.Students.Where(st => st.UserName == userName)
                .Include(st => st.Documents)
                .Select(student => new StudentDTO()
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    PhoneNumber = student.PhoneNumber,
                    Email = student.Email,

                    GraduationYear = student.GraduationYear,
                    UniversityId = student.UniversityId,
                    UniversityName = student.University.UniversityName,
                    //GradeId=student.GradeId,
                    //GradeValue=student.Grade.Value,
                    StudentGrade = student.StudentGrade,
                    GenderName = student.Gender.GenderType,
                    GenderId = student.GenderId,
                    StatusId = student.StatusId,
                    StatusName = student.Status.StatusName.ToLower(),
                    RoundId = student.RoundId,
                    RoundName = student.Round.RoundName,
                    TrackId = student.TrackId,
                    TrackName = student.Track.TrackName,
                    InterviewerId = student.InterviewerId,
                    InterviewerName = student.Interviewer.InterviewerName,
                    //Documents=student.Documents, //
                    InterviewId = student.InterviewId,
                    InterviewName = student.Interview.FirstOrDefault().InterviewName,
                    UserId=student.UserId,
                    UserName = student.UserName,
                    ProfilePicture=student.ProfilePicture,
                    StudentCertificate= student.StudentCertificate,
                    InterviewDate=student.InterviewDate,
                    AdminId = student.AdminId
                }).ToList();
            if (_dbContext.Students.Where(x => x.UserName == userName) != null)
            {
                return student;
            }
            else { throw new Exception("There is no student with this Id"); }
        }

        public StudentFilterDTO GetAllStudentData()
        {
            var dto = new StudentFilterDTO();
            dto.Tracks= _dbContext.Tracks.Where(tr => !tr.IsDeleted)
                .Select(tr => new TrackDTO()
                {
                    Id = tr.Id,
                    TrackName=tr.TrackName,
                    RoundName=tr.Round.RoundName,
                    StartDate=tr.StartDate,
                    EndDate=tr.EndDate,
                    AdminId = tr.AdminId
                }).ToList();

            dto.Statuses= this._dbContext.Statuses.Where(st=>!st.IsDeleted)
                .Select( st => new StatusDTO()
                {
                    Id=st.Id,
                    StatusName=st.StatusName
                    
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

            dto.Universities=_dbContext.Universities.Where(un => !un.IsDeleted)
                .Select(uni => new UniversityDTO()
                {
                    Id=uni.Id,
                    UniversityName=uni.UniversityName,
                    
                }).ToList();

            //dto.Grades= _dbContext.Grades.Where(gr=>!gr.IsDeleted)
            //    .Select( grad => new GradeDTO()
            //    {
            //        Id=grad.Id,
            //        Value=grad.Value,

            //    }).ToList();
            dto.Genders=_dbContext.Genders.Where(gr => !gr.IsDeleted)
                .Select(grad => new GenderDTO()
                {
                    Id=grad.Id,
                    GenderType=grad.GenderType,

                }).ToList();
            dto.Documents=_dbContext.Documents.Where(doc => !doc.IsDeleted)
                .Select(doc => new DocumentDTO()
                {
                    Id = doc.Id,
                    DocumentName=doc.DocumentName,
                    AdminId=doc.AdminId,
                    StudentId=doc.StudentId
                  
                }).ToList();
            dto.Interviews=_dbContext.Interviews.Where(inter => !inter.IsDeleted)
                .Select(inter => new InterviewDTO()
                {
                    Id=inter.Id,
                    InterviewName=inter.InterviewName,
                    StartDate=inter.StartDate,
                    EndDate=inter.EndDate,
                    //StudentId=inter.StudentId
                }).ToList();
            dto.Interviewers=_dbContext.Interviewers.Where(inter => !inter.IsDeleted)
              .Select(inter => new InterviewerDTO()
              {
                  Id=inter.Id,
                  InterviewerName=inter.InterviewerName,
                  StartDate=inter.StartDate,
                  EndDate=inter.EndDate,
                 
                  Students=inter.Student,
                  AdminId=inter.AdminId,
              }).ToList();

          
            #region Try Union
            /*//******/
            //var combinedResults= 
            //    _dbContext.Rounds.Where(r => !r.IsDeleted)
            //    .Select(r=>new
            //    {
            //        Name="Round Name",
            //        RoundId=r.Id,
            //        RoundName=r.RoundName,
            //        TracksNumber=r.Track.Count,
            //        StudentNumber=r.Student.Count 
            //    }).Union(
            //    _dbContext.Tracks.Where(t=>!t.IsDeleted)
            //    .Select(t=> new
            //    {
            //        TrackId=t.Id,
            //        StartDate=t.StartDate,
            //        EndDate=t.EndDate,

            //    })
            //    )
            //    .ToList();
            //////////************/////////////////////
            ///
            #endregion

            return dto;

        }

        public List<Student> GetStudentsAccepted()
        {
            var studentAccepted = _dbContext.Students.Where(st => !st.IsDeleted
                  && st.StatusId==new Guid("72ad3bfd-143d-4a1c-fda2-08dab747359c"))
              .ToList();

            return studentAccepted;
        }
       public List<Student> GetStudentsRejected()
        {
            var studentRejected = _dbContext.Students.Where(st => !st.IsDeleted
                && st.StatusId==new Guid("5cdcc685-6480-42da-bd7d-08dab748097d"))
            .ToList();

            return studentRejected;
        }

        public List<StudentDTO> GetStudents()
        {
            var _student = _dbContext.Students.Where(st => !st.IsDeleted)
                .Include(st=> st.Documents)
                 .Select(student => new StudentDTO()
                 {
                     Id=student.Id,
                     StudentName=student.StudentName,
                     PhoneNumber=student.PhoneNumber,
                     Email=student.Email,
                     GraduationYear=student.GraduationYear,
                     UniversityId=student.UniversityId,
                     UniversityName=student.University.UniversityName,
                     //GradeId=student.GradeId,
                     //GradeValue=student.Grade.Value,
                     StudentGrade=student.StudentGrade, 
                     GenderName=student.Gender.GenderType,
                     GenderId=student.GenderId,
                     StatusId=student.StatusId,
                     StatusName=student.Status.StatusName,
                     RoundId=student.RoundId,
                     RoundName=student.Round.RoundName,
                     TrackId=student.TrackId,
                     TrackName=student.Track.TrackName,
                     InterviewerId=student.InterviewerId,
                     InterviewerName=student.Interviewer.InterviewerName,
                     InterviewId=student.InterviewId,
                     //InterviewName=student.Interview.FirstOrDefault().InterviewName,
                     //Documents=student.Documents,
                     UserId=student.UserId,                  
                     UserName=student.UserName,
                     ProfilePicture=student.ProfilePicture,
                     StudentCertificate=student.StudentCertificate,
                     InterviewDate=student.InterviewDate,
                     AdminId=student.AdminId
                 }).ToList();

            var statuses = _dbContext.Statuses.Where(status => !status.IsDeleted).ToList();
            foreach (var stud in _student)
            {
                if (stud.InterviewDate<DateTime.Now)
                {
                    stud.StatusId=new Guid("269730a0-210f-4a68-6a20-08dab7463022");
                    //foreach (var status in statuses)
                    //{
                    //    if (status.StatusName.Contains("Missed"))
                    //    {
                    //        stud.StatusId = status.Id;
                    //        stud.StatusName=status.StatusName;
                    //    }
                    //}

                }
                //var statuses = _dbContext.Statuses.Where(status => !status.IsDeleted).ToList();
                //foreach (var status in statuses)
                //{
                //    if (status.StatusName.Contains("Waiting for Interview"))
                //    {
                //        student.StatusId = status.Id;
                //        _student.StatusId=student.StatusId;
                //    }
                //}
            }
            return _student;
        }

        public List<StudentDTO> GetStudentByUserId(Guid id)
        {
            var student = _dbContext.Students.Where(st => st.UserId==id)
                .Include(st => st.Documents)
                .Select(student => new StudentDTO()
                {
                    Id=student.Id,
                    StudentName=student.StudentName,
                    PhoneNumber=student.PhoneNumber,
                    Email=student.User.Email,

                    GraduationYear=student.GraduationYear,
                    UniversityId=student.UniversityId,
                    UniversityName=student.University.UniversityName,
                    //GradeId=student.GradeId,
                    //GradeValue=student.Grade.Value,
                    StudentGrade=student.StudentGrade,
                    GenderName=student.Gender.GenderType,
                    GenderId=student.GenderId,
                    StatusId=student.StatusId,
                    StatusName=student.Status.StatusName.ToLower(),
                    RoundId=student.RoundId,
                    RoundName=student.Round.RoundName,
                    TrackId=student.TrackId,
                    TrackName=student.Track.TrackName,
                    InterviewerId=student.InterviewerId,
                    InterviewerName=student.Interviewer.InterviewerName,
                    //Documents=student.Documents, //
                    InterviewId=student.InterviewId,
                    InterviewName=student.Interview.FirstOrDefault().InterviewName,
                    UserId=student.UserId,
                    UserName=student.UserName,
                    ProfilePicture=student.ProfilePicture,
                    StudentCertificate=student.StudentCertificate,
                    InterviewDate=student.InterviewDate,
                    AdminId=student.AdminId
                }).ToList();
            if (_dbContext.Students.Where(x => x.Id==id) != null)
            {
                return student;
            }
            else { throw new Exception("There is no student with this Id"); }
        }

        public List<StudentDTO> GetStudentByInterviewerId(Guid? id)
        {
            var student = _dbContext.Students.Where(st => st.InterviewerId==id)
                .Include(st => st.Documents)
                .Select(student => new StudentDTO()
                {
                    Id=student.Id,
                    StudentName=student.StudentName,
                    PhoneNumber=student.PhoneNumber,
                    Email=student.User.Email,

                    GraduationYear=student.GraduationYear,
                    UniversityId=student.UniversityId,
                    UniversityName=student.University.UniversityName,
                    //GradeId=student.GradeId,
                    //GradeValue=student.Grade.Value,
                    StudentGrade=student.StudentGrade,
                    GenderName=student.Gender.GenderType,
                    GenderId=student.GenderId,
                    StatusId=student.StatusId,
                    StatusName=student.Status.StatusName.ToLower(),
                    RoundId=student.RoundId,
                    RoundName=student.Round.RoundName,
                    TrackId=student.TrackId,
                    TrackName=student.Track.TrackName,
                    InterviewerId=student.InterviewerId,
                    InterviewerName=student.Interviewer.InterviewerName,
                    //Documents=student.Documents, //
                    InterviewId=student.InterviewId,
                    InterviewName=student.Interview.FirstOrDefault().InterviewName,
                    UserId=student.UserId,
                    UserName=student.UserName,
                    ProfilePicture=student.ProfilePicture,
                    StudentCertificate=student.StudentCertificate,
                    InterviewDate=student.InterviewDate,
                    AdminId=student.AdminId
                }).ToList();
            if (_dbContext.Students.Where(x => x.Id==id) != null)
            {
                return student;
            }
            else { throw new Exception("There is no student with this Id"); }
        }
    }
}
