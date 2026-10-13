using Microsoft.AspNetCore.Mvc;

namespace TechAcadStudentsMVC.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Student"] = "Jason";
            return View();
        }
    }
}
