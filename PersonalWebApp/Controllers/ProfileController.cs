using Microsoft.AspNetCore.Mvc;

using PersonalWebApp.Models.Profiles;
using PersonalWebApp.Models.Users;

namespace PersonalWebApp.Controllers
{
    public class ProfileController : Controller
    {
        private UserDbContext _userDb;
        
        private ProfileDbContext _profileDb;

        public ProfileController(UserDbContext userDb, ProfileDbContext profileDb)
        {
            _userDb = userDb;
            _profileDb = profileDb;
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
            await ProfileEditor.Edit(await UserDisplay.Display(User.Identity.Name, _userDb), editor, _profileDb);
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