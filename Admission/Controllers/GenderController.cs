using Admission.Manage.manageGender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        public IManageGender _manageGender { get; set; }
        public GenderController(IManageGender manageGender)
        {
            _manageGender=manageGender;
        }

       [Authorize]
        [HttpPost, Route("CreateNewGender")]
        public void CreateNewGender(GenderDTO gender)
           => _manageGender.CreateNewGender(gender);

       [Authorize]
        [HttpPut, Route("EditGender")]
        public void EditGender(GenderDTO gender)
            => _manageGender.EditGender(gender);

       [Authorize]
        [HttpDelete, Route("DeleteGender")]
        public void DeleteGender(Guid id) => _manageGender.DeleteGender(id);




        [HttpGet, Route("GetGenders")]
        public List<GenderDTO> GetGenders()
            => _manageGender.GetGenders();

        [HttpGet, Route("GetGenderById")]
        public List<GenderDTO> GetGenderById(Guid id)
            => _manageGender.GetGenderById(id);
    }
}
