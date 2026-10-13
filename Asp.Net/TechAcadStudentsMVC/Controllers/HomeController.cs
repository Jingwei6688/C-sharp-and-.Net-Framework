using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechAcadStudentsMVC.Models;

namespace TechAcadStudentsMVC.Controllers
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

        public IActionResult Privacy()
        {
            ViewData["School"] = "Tech Academy";
            return View();
        }

        public IActionResult Instructors(int id)
        {
            ViewBag.Id = id;
            Instructor ins = new Instructor()
            {
                id = 1001,
                firstName = "Jason",
                lastName = "Lee"
            };
            return View(ins);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
