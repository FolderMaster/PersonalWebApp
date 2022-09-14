using Microsoft.AspNetCore.Mvc;
using PersonalWebApp.Models.Files;
using PersonalWebApp.Models.Profiles;
using PersonalWebApp.Models.Users;

namespace PersonalWebApp.Controllers
{
    public class ProfileController : Controller
    {
        private UserDbContext _userDb;

        private FileDbContext _fileDb;
        
        private ProfileDbContext _profileDb;

        private IWebHostEnvironment _webHostEnvironment;

        public ProfileController(UserDbContext userDb, FileDbContext fileDb, ProfileDbContext
            profileDb, IWebHostEnvironment webHostEnvironmentl)
        {
            _userDb = userDb;
            _fileDb = fileDb;
            _profileDb = profileDb;
            _webHostEnvironment = webHostEnvironmentl;

            FileDownloader.FileDb = _fileDb;
        }

        public async Task<IActionResult> Index(string name)
        {
            Profile? profile = await ProfileDisplay.Display(name, _profileDb, _userDb);
            if(profile == null)
            {
                return NotFound();
            }
            else
            {
                return View(profile);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            Profile? profile = await ProfileDisplay.Display(User.Identity.Name, _profileDb, _userDb);
            if(profile == null)
            {
                return Unauthorized();
            }
            else
            {
                return View(profile);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileEditor editor)
        {
            await ProfileEditor.Edit(await UserDisplay.Display(User.Identity.Name, _userDb), editor, _webHostEnvironment, _fileDb, _profileDb);
            Profile? profile = await ProfileDisplay.Display(User.Identity.Name, _profileDb, _userDb);
            if(profile == null)
            {
                return Unauthorized();
            }
            else
            {
                return View(profile);
            }
        }
    }
}