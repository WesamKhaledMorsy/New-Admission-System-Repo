using System.ComponentModel.DataAnnotations;

namespace Admission.Model.DomainModel
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? ClientURI { get; set; }

    }
}
