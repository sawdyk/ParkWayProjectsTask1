using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkWayProjectsTask1.Repository.Configuration.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Controllers
{
    public class UploadConfigurationController : Controller
    {
        private readonly IUploadConfigurationRepo _uploadConfigurationRepo;

        public UploadConfigurationController(IUploadConfigurationRepo uploadConfigurationRepo)
        {
            _uploadConfigurationRepo = uploadConfigurationRepo;
        }

        // GET: UploadConfigurationController
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        // POST: UploadConfigurationController/
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile configurationFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var result = await _uploadConfigurationRepo.uploadConfigurationFileAsync(configurationFile);
                ViewData["message"] = result.Message;

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
