using Admission.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationUser _applicationUser;
        private readonly AppDbContext _dbContext;
        public UsersController(
           ApplicationUser applicationUser,
           AppDbContext dbContext)
        {
           
            _applicationUser=applicationUser;
            _dbContext = dbContext;
        }

        [HttpGet, Route("GetUsers")]
        public List<ApplicationUser> GetUsers()
        {
            var users = _dbContext.Users.Where(us => us.Email !=null).ToList();
            return users;
        }
    }
}
