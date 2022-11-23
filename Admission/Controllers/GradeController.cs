using Admission.Manage.manageGrade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        public IManageGrade _manageGrade { get; set; }
        public GradeController(IManageGrade manageGrade)
        {
            _manageGrade=manageGrade;
        }
       // [Authorize]
        [HttpPost, Route("CreateNewGrade")]
        public void CreateNewGrade(GradeDTO grade)
           => _manageGrade.CreateNewGrade(grade);

        //[Authorize]
        [HttpPut, Route("EditGrade")]
        public void EditGrade(GradeDTO grade)
            => _manageGrade.EditGrade(grade);

        //[Authorize]
        [HttpDelete, Route("DeleteGrade")]
        public void DeleteGrade(Guid id) => _manageGrade.DeleteGrade(id);


        
        [HttpGet, Route("GetAllGrades")]

        public List<GradeDTO> GetAllGrades(Guid? id, int? value, Guid? adminId, int pageIndex, int pageSize)
            => _manageGrade.GetAllGrades(id, value, adminId, pageIndex, pageSize);



        [HttpGet, Route("GetGrades")]
        public List<GradeDTO> GetGrades()
            => _manageGrade.GetGrades();

        [HttpGet, Route("GetGradeById")]
        public List<GradeDTO> GetGradeById(Guid id)
            => _manageGrade.GetGradeById(id);


    }
}
