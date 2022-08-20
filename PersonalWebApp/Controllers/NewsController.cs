using Microsoft.AspNetCore.Mvc;

namespace PersonalWebApp.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
