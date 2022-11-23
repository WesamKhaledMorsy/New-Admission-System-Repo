using Admission.Manage.manageUniversity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        public IManageUniversity _manageUniversity { get; set; }
        public UniversityController(IManageUniversity manageUniversity)
        {
            _manageUniversity=manageUniversity;
        }

        [Authorize]
        [HttpPost, Route("CreateNewUniversity")]
        public void CreateNewUniversity(UniversityDTO university)
          => _manageUniversity.CreateNewUniversity(university);

        [Authorize]
        [HttpPut, Route("EditUniversity")]
        public void EditUniversity(UniversityDTO university)
            => _manageUniversity.EditUniversity(university);

       [Authorize]
        [HttpDelete, Route("DeleteUniversity")]
        public void DeleteUniversity(Guid id)
            => _manageUniversity.DeleteUniversity(id);



        [HttpGet, Route("GetUniversity")]
        public List<UniversityDTO> GetUniversity()
            => _manageUniversity.GetUniversity();

        [HttpGet, Route("GetUniversityById")]
        public List<UniversityDTO> GetUniversityById(Guid id)
            => _manageUniversity.GetUniversityById(id);

    }
}
