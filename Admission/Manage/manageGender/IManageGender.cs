namespace Admission.Manage.manageGender
{
    public interface IManageGender
    {
        void CreateNewGender(GenderDTO gender);
        void DeleteGender(Guid id);
        void EditGender(GenderDTO gender);
        //List<GenderDTO> GetAllGenders(Guid? id, int? value,
        //    Guid? adminId, int pageIndex, int pageSize);
        List<GenderDTO> GetGenderById(Guid id);
        List<GenderDTO> GetGenders();
    }
}
