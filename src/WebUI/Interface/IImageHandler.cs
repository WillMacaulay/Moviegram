using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MoviegramApi.WebUI.Interface
{
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file);
    }
}

