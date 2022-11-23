namespace Admission.Manage.manageGrade
{
    public interface IManageGrade
    {
        void CreateNewGrade(GradeDTO grade);
        void DeleteGrade(Guid id);
        void EditGrade(GradeDTO grade);
        List<GradeDTO> GetAllGrades(Guid? id, int? value,
            Guid? adminId, int pageIndex, int pageSize);
        List<GradeDTO> GetGradeById(Guid id);
        List<GradeDTO> GetGrades();
      
    }
}
