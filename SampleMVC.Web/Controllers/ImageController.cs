using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Principal;
using SampleMVC.Service;

namespace SampleMVC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly Account account = null;
        private readonly IImageService _imageService;
        private Cloudinary cloudinary;
        public ImageController(IImageService imageService) 
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile fileToUpload)
        {
            string uploadImageUrl = await _imageService.Upload(fileToUpload);

            if (uploadImageUrl == null)
            {
                return Problem("Some error has occured", null, (int)HttpStatusCode.InternalServerError, null, null);
            }

            return new JsonResult(new { url = uploadImageUrl }) ;
            
        }
    }
}
