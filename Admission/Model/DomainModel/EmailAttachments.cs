namespace Admission.Model.DomainModel
{
    public class EmailAttachments
    {
        public IFormFile? ImageFile { get; set; }
        public string? ToEmail   { get; set; }
        public SendGridEmail?Name { get; set; }
    }
}
