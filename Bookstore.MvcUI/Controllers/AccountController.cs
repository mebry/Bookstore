using AutoMapper;
using Bookstore.Application.Common.Behaviours;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Shared.Identity;
using Bookstore.MvcUI.Models;
using Bookstore.MvcUI.ViewModels.Incoming;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
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
    }
}
