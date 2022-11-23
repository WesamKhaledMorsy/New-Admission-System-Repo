using Admission.Manage.manageRound;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        public IManageRound _manageRound { get; set; }
        public RoundController(IManageRound manageRound)
        {
            _manageRound=manageRound;
        }
       [Authorize]
        [HttpPost, Route("CreateNewRound")]
        public void CreateNewRound(RoundDTO round)
            => _manageRound.CreateNewRound(round);

        //[Authorize]
        [HttpDelete, Route("DeleteRound")]
        public void DeleteRound(Guid id)
            => _manageRound.DeleteRound(id);

       [Authorize]
        [HttpPut, Route("EditRound")]
        public void EditRound(RoundDTO round)
            => _manageRound.EditRound(round);

        [HttpGet, Route("GetAllRounds")]
        public List<RoundDTO> GetAllRounds(Guid? id, string? name, DateTime? startDate,
            DateTime? endDate, DateTime? startAdmission, DateTime? endAdmission,Guid? adminId, int pageIndex, int pageSize)
            => _manageRound.GetAllRounds(id, name,  startDate, endDate ,startAdmission, endAdmission, adminId, pageIndex, pageSize);

        [HttpGet, Route("GetRoundById")]
        public List<RoundDTO> GetRoundById(Guid id)
            => _manageRound.GetRoundById(id);

        [HttpGet, Route("GetRounds")]
        public List<RoundDTO> GetRounds()
            => _manageRound.GetRounds();
    }
}
