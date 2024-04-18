using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SampleMVC.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;        
        public string UploadedPhotoUrl { get; set; } = string.Empty;
    }
}
