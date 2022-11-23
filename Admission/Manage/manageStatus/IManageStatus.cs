namespace Admission.Manage.manageStatus
{
    public interface IManageStatus
    {
        void CreateNewStatus(StatusDTO status);
        void DeleteStatus(Guid id);
        void EditStatus(StatusDTO status);
        //List<GradeDTO> GetAllGrades(Guid? id, int? value,
        //    Guid? adminId, int pageIndex, int pageSize);
        List<StatusDTO> GetStatusById(Guid id);
        List<StatusDTO> GetStatus();
    }
}
