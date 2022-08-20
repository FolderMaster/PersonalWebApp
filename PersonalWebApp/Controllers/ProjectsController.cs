using Microsoft.AspNetCore.Mvc;

namespace PersonalWebApp.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
