using Admission.DB;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Admission.Manage.manageDocument
{
    public class ManageDocument : IManageDocument
    {
        private readonly AppDbContext _dbContext;
        public ManageDocument(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreateNewDocument()
        {
            throw new NotImplementedException();
        }

        public object CreateNewDocument(DocumentDTO docDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocument(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditDocument(DocumentDTO document)
        {
            throw new NotImplementedException();
        }

        public List<DocumentDTO> GetDocument()
        {
            throw new NotImplementedException();
        }

        public List<DocumentDTO> GetDocumentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UploadDocument(DocumentDTO document)
        {
            throw new NotImplementedException();
        }

        public string UploadFiles(List<IFormFile>? files, int id)
        {
            throw new NotImplementedException();
        }
    }
}
