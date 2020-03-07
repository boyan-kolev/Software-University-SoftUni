using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWebApp.Filters;
using MyFirstWebApp.Models;
using MyFirstWebApp.Services;
using MyFirstWebApp.ViewModels.Home;

namespace MyFirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPositionService positionService;

        public HomeController(ILogger<HomeController> logger, IPositionService positionService)
        {
            _logger = logger;
            this.positionService = positionService;
        }


        public IActionResult TestFile()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUploud(FileUploadInputModel input)
        {
            var filePath = "testFile.txt";
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await input.someFile.CopyToAsync(fileStream);
            }

            return this.Redirect("/");
        }

        public IActionResult DownloadFile()
        {
            return this.PhysicalFile(@"D:\ReceiptBook.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ReceiptBook");
        }

        public IActionResult Test()
        {
            var model = new TestInputModel()
            {
                Positions = this.positionService.GetAll()
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Test(TestInputModel input)
        {
            if (ModelState.IsValid == false)
            {
                input.Positions = this.positionService.GetAll();

                return this.View(input);
            }

            return this.Redirect("/");
        }

        [TypeFilter(typeof(AddHeaderActionFilterAttribute))]
        public IActionResult Index()
        {
            return View();
        }

        [ResultFilter]
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
