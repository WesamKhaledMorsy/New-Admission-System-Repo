using Admission.Manage.manageStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        public IManageStatus _manageStatus { get; set; }
        public StatusController(IManageStatus manageStatus)
        {
            _manageStatus=manageStatus;
        }
        [Authorize]
        [HttpPost, Route("CreateNewStatus")]
        public void CreateNewStatus(StatusDTO status)
          => _manageStatus.CreateNewStatus(status);

       [Authorize]
        [HttpPut, Route("EditStatus")]
        public void EditStatus(StatusDTO status)
            => _manageStatus.EditStatus(status);

       [Authorize]
        [HttpDelete, Route("DeleteStatus")]
        public void DeleteStatus(Guid id)
            => _manageStatus.DeleteStatus(id);



        [HttpGet, Route("GetStatus")]
        public List<StatusDTO> GetStatss()
            => _manageStatus.GetStatus();

        [HttpGet, Route("GetStatusById")]
        public List<StatusDTO> GetStatusById(Guid id)
            => _manageStatus.GetStatusById(id);
    }
}
