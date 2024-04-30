using Microsoft.AspNetCore.Mvc.Rendering;
using SampleMVC.Web.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleMVC.Web.Models
{
    public class AddNewCustomerRequest
    {        
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [DisplayName("Genders")]
        public List<SelectListItem> Genders { get; set; } = 
                                             new List<SelectListItem>() 
                                             { 
                                                            new SelectListItem { Text = CommonConstants.MALE, Value = "Male" },
                                                            new SelectListItem { Text = CommonConstants.FEMALE, Value = "Female" },
                                                            new SelectListItem { Text = CommonConstants.OTHER, Value = "Other" },
                                             };
        public string SelectedGender { get; set; }

        private string _upLoadedPhotoUrl;
        
        public string UploadedPhotoUrl 
        {
            get { return _upLoadedPhotoUrl; } 
            set { _upLoadedPhotoUrl = value; }
        }
        
        [DisplayName("Profile Picture")]
        public IFormFile? ProfilePicture { get; set; }
    }
}
