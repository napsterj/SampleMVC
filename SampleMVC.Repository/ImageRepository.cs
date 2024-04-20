using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SampleMVC.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly Account account;
        private Cloudinary cloudinary;
        public ImageRepository()
        {
            account = new Account(
                   Environment.GetEnvironmentVariable("CloudName"),
                   Environment.GetEnvironmentVariable("ApiKey"),
                   Environment.GetEnvironmentVariable("ApiSecret"));
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            cloudinary = new Cloudinary(account);

            var uploadResult = await cloudinary.UploadAsync(new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            });

            cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(100).Height(150)
                                   .Crop("fill"))
                                   .BuildUrl(file.FileName);

            if (uploadResult is not null && uploadResult.Status == HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();
            }

            return string.Empty;
        }
    }
}
