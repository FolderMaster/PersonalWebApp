using Microsoft.AspNetCore.Mvc;

namespace PersonalWebApp.Controllers
{
    public class StatusCodesController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            return View(statusCode);
        }
    }
}
