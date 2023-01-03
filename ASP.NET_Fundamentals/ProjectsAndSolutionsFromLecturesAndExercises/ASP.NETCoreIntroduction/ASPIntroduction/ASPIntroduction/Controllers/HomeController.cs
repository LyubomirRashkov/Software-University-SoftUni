using ASPIntroduction.Contracts;
using ASPIntroduction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPIntroduction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ITestService testService;

        public HomeController(
            ILogger<HomeController> logger,
            ITestService testService)
        {
            _logger = logger;
            this.testService = testService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(TestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string product = this.testService.GetProduct(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Test()
        {
            var model = new TestModel();

            return View("TestNew", model);
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