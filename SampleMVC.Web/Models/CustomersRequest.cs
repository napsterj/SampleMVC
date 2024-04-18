namespace SampleMVC.Web.Models
{
    public class CustomersRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string Gender { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string UploadedPhotoUrl { get; set; } = string.Empty;
    }
}
