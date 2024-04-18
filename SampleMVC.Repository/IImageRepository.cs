using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Repository
{
    public interface IImageRepository
    {
        Task<string> UploadImage(IFormFile formFile);
    }
}
