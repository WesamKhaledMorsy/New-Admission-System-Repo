namespace Admission.Manage.manageDocument
{
    public interface IManageDocument
    {

       
        void DeleteDocument(Guid id);
        void EditDocument(DocumentDTO document);
        List<DocumentDTO> GetDocumentById(Guid id);
        List<DocumentDTO> GetDocument();
        void CreateNewDocument();
        string UploadFiles(List<IFormFile>? files, int id);
        object CreateNewDocument(DocumentDTO docDto);
    }
}
