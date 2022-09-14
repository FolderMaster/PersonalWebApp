using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using PersonalWebApp.Models.Users;
using PersonalWebApp.Models.Profiles;

namespace PersonalWebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserDbContext _userDb;

        private ProfileDbContext _profileDb;

        public AccountController(UserDbContext userDb, ProfileDbContext profileDb)
        {
            _userDb = userDb;
            _profileDb = profileDb;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.RefererUrl = Request.Headers["Referer"].ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration register, string refererUrl)
        {
            User? user = await UserRegistration.Register(register, _userDb);
            if(user == null)
            {
                return View(register);
            }
            else
            {
                await CreateProfile(user);
                if(refererUrl == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(refererUrl);
                }
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.RefererUrl = Request.Headers["Referer"].ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLogin login, string refererUrl)
        {
            User? user = await UserLogin.SignIn(login, _userDb);
            if(user == null)
            {
                return View(login);
            }
            else
            {
                await Authenticate(user);
                if (refererUrl == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(refererUrl);
                }
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            string refererUrl = Request.Headers["Referer"].ToString();
            if (refererUrl == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(refererUrl);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            User? user = await GetUser(User.Identity.Name);
            if(user == null)
            {
                return Unauthorized();
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditor editor)
        {
            User? user = await UserEditor.Edit(await GetUser(User.Identity.Name), editor, _userDb);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                return View(user);
            }
        }

        public async Task<User?> GetUser(string name)
        {
            return await UserDisplay.Display(name, _userDb);
        }

        public async Task CreateProfile(User user)
        {
            await ProfileCreator.Create(user, _profileDb);
        }

        private async Task Authenticate(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
                ClaimsPrincipal(new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.
                DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType)));
        }
    }
}
