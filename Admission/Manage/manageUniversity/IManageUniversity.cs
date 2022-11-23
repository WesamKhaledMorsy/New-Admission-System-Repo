namespace Admission.Manage.manageUniversity
{
    public interface IManageUniversity
    {
        void CreateNewUniversity(UniversityDTO university);
        void DeleteUniversity(Guid id);
        void EditUniversity(UniversityDTO university);
        List<UniversityDTO> GetUniversityById(Guid id);
        List<UniversityDTO> GetUniversity();
    }
}
