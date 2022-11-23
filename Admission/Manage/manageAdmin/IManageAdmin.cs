namespace Admission.Manage.manageAdmin
{
    public interface IManageAdmin
    {
        void CreateNewAdmin(AdminDTO admin);
        void DeleteAdmin(Guid id);
        void EditAdmin(AdminDTO admin);
        List<AdminDTO> GetAllAdmins(Guid id, string? name, int pageIndex, int pageSize);
        List<AdminDTO> GetAdminById(Guid id);
        List<AdminDTO> GetAdmins();

    }
}
