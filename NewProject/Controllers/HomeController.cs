using Microsoft.AspNetCore.Mvc;

namespace NewProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
