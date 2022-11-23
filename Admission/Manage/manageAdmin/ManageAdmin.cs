using Admission.DB;
using Admission.Model.DomainModel;

namespace Admission.Manage.manageAdmin
{
    public class ManageAdmin : IManageAdmin
    {
        private readonly AppDbContext _dbContext;
        public ManageAdmin(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateNewAdmin(AdminDTO admin)
        {
            var _admin = new Admin()
            {
                Id = admin.Id,
                AdminName=admin.AdminName,

            };
            this._dbContext.Admins.Add(_admin);
            this._dbContext.SaveChanges();
        }

        public void DeleteAdmin(Guid id)
        {
            var _admin = this._dbContext.Admins.FirstOrDefault(t => t.Id==id);
            if (_admin != null)
            {
                _admin.IsDeleted =true;
                this._dbContext.SaveChanges();
            }
        }

        public void EditAdmin(AdminDTO admin)
        {
            var _admin = this._dbContext.Admins.Find(admin.Id);

            _admin.AdminName=admin.AdminName;
            this._dbContext.SaveChanges();
        }

        public List<AdminDTO> GetAdminById(Guid id)
        {
            var _admin = this._dbContext.Admins.Where(t => t.Id==id)
                   .Select(admin => new AdminDTO()
                   {
                       Id= admin.Id,
                       AdminName = admin.AdminName,

                   }).ToList();
            return _admin;
        }

        public List<AdminDTO> GetAdmins()
        {

            var _admin = _dbContext.Admins.Where(tr => !tr.IsDeleted)
                             .Select(admin => new AdminDTO()
                             {
                                 Id= admin.Id,
                                 AdminName = admin.AdminName,

                             }).ToList();
            return _admin;
        }

        public List<AdminDTO> GetAllAdmins(Guid id, string? name, int pageIndex, int pageSize)
        {
            var _admin = _dbContext.Admins.Where(tr => !tr.IsDeleted

          && (name ==null|| tr.AdminName.Contains(name))
             )
          .Skip(pageSize*(pageIndex-1)).Take(pageSize)
          .Select(admin => new AdminDTO()
          {
              Id= admin.Id,
              AdminName = admin.AdminName,

          }).ToList();
            return _admin;
        }
    }
}
