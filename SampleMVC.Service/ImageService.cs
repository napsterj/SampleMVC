using Microsoft.AspNetCore.Http;
using SampleMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public Task<string> Upload(IFormFile formFile)
        {
            return _imageRepository.UploadImage(formFile);
        }
    }
}
