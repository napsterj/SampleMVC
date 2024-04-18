using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Service
{
    public interface IImageService
    {
        Task<string> Upload(IFormFile formFile);
    }
}
