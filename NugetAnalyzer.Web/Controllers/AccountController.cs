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
        [HttpGet]
        public IActionResult UserCreationForm(Profile profile)
        {
            return View(profile);
        }

        [HttpPost]
        public IActionResult CreateUser(Profile profile)
        {
            userService.CreateUserAsync(profile);
           
            return View("Profile");
        }
    }
}