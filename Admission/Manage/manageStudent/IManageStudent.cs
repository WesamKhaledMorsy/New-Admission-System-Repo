using Admission.Manage.manageDocument;
using Admission.Model.DomainModel;

namespace Admission.Manage.manageStudent
{
    public interface IManageStudent
    {
        void CreateNewStudent(StudentDTO student);
        void UploadDocuments(DocumentDTO studentDOC);
        void DeleteStudent(Guid id);
        void EditStudent(StudentDTO student);
        List<StudentDTO> GetAllStudents( string? name,string? email, Guid? statusId,
             int pageIndex, int pageSize);
        List<StudentDTO> GetStudentById(Guid id);
        List<StudentDTO> GetStudentByUserName(string userName);
        List<StudentDTO> GetStudentByUserId(Guid id);
        List<StudentDTO> GetStudents();
        public StudentFilterDTO GetAllStudentData();
         List<StudentDTO> GetStudentByInterviewerId(Guid? id);
        List<Model.DomainModel.Student> GetStudentsAccepted();
        List<Model.DomainModel.Student> GetStudentsRejected();
        List<Student> GetStudentsWaitingForInterview();

    }
}
