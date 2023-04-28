using AutoMapper;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Shared.Identity;
using Bookstore.MvcUI.Models;
using Bookstore.MvcUI.ViewModels.Incoming;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAccountService accountService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserForSignUp model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = _mapper.Map<ApplicationUser>(model);

            user.UserName = model.Email;

            var result = await _accountService.RegisterAsync(user, model.Password);

            if (result.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View("SuccessSignUp");

            }

            ModelState.AddModelError(string.Empty, result.Description);

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserForSignIn model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _accountService.LoginAsync(model.Email, model.Password);

            if (result.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Index", "Book");
                
            }

            ModelState.AddModelError(string.Empty, result.Description);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var result = await _accountService.LogoutAsync();

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Book",
                       Description = result.Description
                   });
            }

            return RedirectToAction("Index", "Book");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Map the user properties to the view model
            var model = new UserForUpdate
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UserForUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Update the user properties
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            // Update the user in the database
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Failed to update user");
                return View(model);
            }

            return View("Success", "Book");
        }
    }
}
