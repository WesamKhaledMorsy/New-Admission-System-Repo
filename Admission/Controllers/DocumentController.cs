using Admission.DB;
using Admission.Manage.manageDocument;
using Admission.Model.DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
 
        public IManageDocument _manageDocument{ get; set; }
        public DocumentController(IManageDocument manageDocument, AppDbContext dbContext)
        {
            _manageDocument=manageDocument;
            this._dbContext = dbContext;
        }


        [HttpPost, Route("CreateNewDocument")]
        public void CreateNewDocument()
        {
            var files = Request.Form.Files.ToList();

            var mydoc = JObject.Parse(Request.Form["doc"]);
            var studentId = mydoc.Root["StudentId"];


            var student_Id =mydoc.SelectToken("StudentId");

            var docDto = new DocumentDTO()
            {
              StudentId=(Guid?)student_Id,
            };

            var docid = _manageDocument.CreateNewDocument(docDto);

            _manageDocument.UploadFiles(files, (int)docid);

        }


        [HttpPost, Route("UploadFiles")]
  
        public string UploadFiles(List<IFormFile>? files, Guid? id)
        {
            var Selectedfile = _dbContext.Documents.FirstOrDefault(p => p.Id == id);
            var url = Selectedfile.filePath;
            foreach (var file in files)
            {

                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Resources\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                url = filePath;
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                    Selectedfile.filePath = @"./Resources/" + fileName + extension;

                }
            }
            _dbContext.SaveChanges();

            return "File Successfully Uploaded";
        }
    }
}
