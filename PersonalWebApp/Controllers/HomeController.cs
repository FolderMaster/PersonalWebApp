using Microsoft.AspNetCore.Mvc;

namespace PersonalWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}