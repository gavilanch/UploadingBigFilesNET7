using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UploadingBigFiles.Models;

namespace UploadingBigFiles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[RequestSizeLimit(512 * 1024 * 1024)]
        public IActionResult Index(IFormFile file)
        {
            var fileSizeInMBs = file.Length / (1024.0 * 1024);
            return View(fileSizeInMBs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}