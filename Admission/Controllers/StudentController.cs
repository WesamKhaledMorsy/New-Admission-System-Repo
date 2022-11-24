using Admission.DB;
using Admission.Manage.manageDocument;
using Admission.Manage.manageStudent;
using Admission.Model.DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IManageStudent _manageStudent { get; set; }
        private readonly AppDbContext _dbContext;
        public StudentController(IManageStudent manageStudent ,AppDbContext dbContext)
        {
           _manageStudent=manageStudent;
            _dbContext=dbContext;
        }
        [Authorize]
        [HttpPost, Route("CreateNewStudent")]
        public void CreateNewStudent(StudentDTO student)
            => _manageStudent.CreateNewStudent(student);

        [Authorize]
        [HttpPost,Route("UploadDocuments")]
        public void UploadDocuments(DocumentDTO studentDOC)
            => _manageStudent.UploadDocuments(studentDOC);

       [Authorize]
        [HttpDelete, Route("DeleteStudent")]
        public void DeleteStudent(Guid id)
            => _manageStudent.DeleteStudent(id);

        [Authorize]
        [HttpPut, Route("EditStudent")]
        public void EditStudent(StudentDTO student)
            => _manageStudent.EditStudent(student);
       

        [HttpGet, Route("GetAllStudents")]
        public List<StudentDTO> GetAllStudents( string? name, string? email, Guid? statusId,
            int pageIndex, int pageSize)
            => _manageStudent.GetAllStudents(name,email,statusId, pageIndex, pageSize);

        [HttpGet, Route("GetStudentById")]
        public List<StudentDTO> GetStudentById(Guid id)
            => _manageStudent.GetStudentById(id);


        [HttpGet,Route("GetStudentByUserName")]
        public List<StudentDTO> GetStudentByUserName(string userName)

            => _manageStudent.GetStudentByUserName(userName);

        [HttpGet, Route("GetStudentByUserId")]
        public List<StudentDTO> GetStudentByUserId(Guid id)
           => _manageStudent.GetStudentByUserId(id);

        [HttpGet, Route("GetStudents")]
        public List<StudentDTO> GetStudents()
            => _manageStudent.GetStudents();

        [HttpGet,Route("GetAllStudentData")]
        public StudentFilterDTO GetAllStudentData()
            => _manageStudent.GetAllStudentData();

        [HttpGet,Route("GetStudentsWaitingForInterview")]
       public List<Student> GetStudentsWaitingForInterview()
            => _manageStudent.GetStudentsWaitingForInterview();

        [HttpGet,Route("GetStudentsAccepted")]
        public List<Student> GetStudentsAccepted()
            => _manageStudent.GetStudentsAccepted();


        [HttpGet,Route("GetStudentsRejected")]
        public List<Student> GetStudentsRejected()
            => _manageStudent.GetStudentsRejected();


        [HttpGet, Route("StudentNumber")]
        public int StudentNumber()
        {
           var studentNumber = _dbContext.Students.Where(st=>!st.IsDeleted).ToList().Count;
            return studentNumber;
        }

        [Authorize]
        [HttpPost, Route("UploadStudentPhoto")]

        public string UploadStudentPhoto(List<IFormFile>? files,Guid? id)
        {
           // this.GetStudentById((Guid)id);

            var Selectedfile = _dbContext.Students.FirstOrDefault(p => p.Id == id);
            var url = Selectedfile.ProfilePicture;
            foreach (var file in files)
            {

                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Resources\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var ProfilePicture = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                url = ProfilePicture;
                if (!System.IO.File.Exists(ProfilePicture))
                {
                    using (var stream = new FileStream(ProfilePicture, FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                    Selectedfile.ProfilePicture = @"./Resources/" + fileName + extension;

                }
            }
            _dbContext.SaveChanges();

            return "File Successfully Uploaded";
        }

        
        [HttpPost, Route("UploadStudentCertificate")]

        public string UploadStudentCertificate(List<IFormFile>? files, Guid? id)
        {
            // this.GetStudentById((Guid)id);

            var Selectedfile = _dbContext.Students.FirstOrDefault(p => p.Id == id);
            var url = Selectedfile.StudentCertificate;
            foreach (var file in files)
            {

                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\UploadedFiles\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var StudentCertificate = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                url = StudentCertificate;
                if (!System.IO.File.Exists(StudentCertificate))
                {
                    using (var stream = new FileStream(StudentCertificate, FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                    Selectedfile.StudentCertificate = @"./UploadedFiles/" + fileName + extension;

                }
            }
            _dbContext.SaveChanges();

            return "File Successfully Uploaded";
        }

        [HttpGet,Route("GetStudentByInterviewerId")]
        public List<StudentDTO> GetStudentByInterviewerId(Guid? id)
            => _manageStudent.GetStudentByInterviewerId(id);
    }
}
