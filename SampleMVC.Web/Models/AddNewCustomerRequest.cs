using Microsoft.AspNetCore.Mvc.Rendering;
using SampleMVC.Web.Constants;

namespace SampleMVC.Web.Models
{
    public class AddNewCustomerRequest
    {        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<SelectListItem> Genders { get; set; } = 
                                             new List<SelectListItem>() 
                                             { 
                                                            new SelectListItem { Text = CommonConstants.MALE, Value = "Male" },
                                                            new SelectListItem { Text = CommonConstants.FEMALE, Value = "Female" },
                                                            new SelectListItem { Text = CommonConstants.OTHER, Value = "Other" },
                                             };
        public string SelectedGender { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public string UploadedPhotoUrl { get; set; }
    }
}
