using Admission.Model.DomainModel;

namespace Admission.Services
{
    public interface IAuthService
    {
        Task<AuthModel> Register(Register register);
        Task<AuthModel> Login(Login login);
        Task<string> AddRole(AddRole addRole);
    }
}
