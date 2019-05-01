using Microsoft.AspNetCore.Mvc;
using NugetAnalyzer.BLL.Interfaces;
using NugetAnalyzer.BLL.Models;

namespace NugetAnalyzer.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult UserGitHubLogin(Profile profile)
        {
            Profile userProfile = userService.GetProfileByGitHubId(profile.GitHubId);
            if (userProfile != null)
            {
                return RedirectToAction("Profile", userProfile);
            }
            return RedirectToAction("UserCreationForm", profile);
        }

        [HttpGet]
        public IActionResult UserCreationForm(Profile profile)
        {
            return View(profile);
        }

        [HttpPost]
        public IActionResult CreateUser(Profile profile)
        {
            userService.CreateUserAsync(profile);

            var userProfile = userService.GetProfileByGitHubId(profile.GitHubId);
            return View("Profile");
        }
    }
}