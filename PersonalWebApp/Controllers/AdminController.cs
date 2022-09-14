using Microsoft.AspNetCore.Mvc;
using PersonalWebApp.Models.Users;

namespace PersonalWebApp.Controllers
{
    public class AdminController : Controller
    {
        private UserDbContext _userDbContext;

        public AdminController(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(UserDisplay.DisplayAll(_userDbContext));
        }
    }
}
