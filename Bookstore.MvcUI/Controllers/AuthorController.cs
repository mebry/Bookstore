using AutoMapper;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Domain.Dtos;
using Bookstore.MvcUI.Models.Outgoing;
using Bookstore.MvcUI.ViewModels.Incoming;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bookstore.MvcUI.Models;
using Bookstore.Application.Shared.Identity;

namespace Bookstore.MvcUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAsync();

            var mappedAuthors = _mapper.Map<IEnumerable<AuthorForDisplay>>(authors.Data);

            return View(mappedAuthors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Create(AuthorForCreation author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            var mappedAuthor = _mapper.Map<AuthorDto>(author);

            var result = await _authorService.CreateAsync(mappedAuthor);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                return View("Error", new ErrorViewModel { Controller = "Author", Description = result.Description });
            }

            return View("Success", "Author");
        }

        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _authorService.GetByIdAsync(id);

            if (actorDetails.StatusCode != Domain.Enums.StatusCode.OK)
                return View("Error", new ErrorViewModel { Controller = "Author", Description = actorDetails.Description });

            var mappedAuthor = _mapper.Map<AuthorForUpdate>(actorDetails.Data);
            return View(mappedAuthor);
        }

        [HttpPost]
        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Edit(int id, AuthorForUpdate author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            if (id != author.Id)
                return View("Error", new ErrorViewModel { Controller = "Author", Description = "The update error is related to IDs." });

            var mappedAuthor = _mapper.Map<AuthorDto>(author);

            var result = await _authorService.UpdateAsync(mappedAuthor);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
                return View("Error", new ErrorViewModel { Controller = "Author", Description = result.Description });

            return View("Success", "Author");
        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _authorService.GetByIdAsync(id);

            if (actorDetails.Data is null)
                return View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Author",
                        Description = "Author with this id wasn't found"
                    });

            var mappedAuthor = _mapper.Map<AuthorForDisplay>(actorDetails.Data);

            return View(mappedAuthor);
        }

        [Authorize(Roles = AvailableRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _authorService.GetByIdAsync(id);

            if (actorDetails.Data is null)
                return View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Author",
                        Description = "Author with this id wasn't found"
                    });

            var mappedAuthor = _mapper.Map<AuthorForDisplay>(actorDetails.Data);
            return View(mappedAuthor);
        }
        [Authorize(Roles = AvailableRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _authorService.GetByIdAsync(id);

            if (actorDetails.Data is null)
                return View("Error",
                    new ErrorViewModel
                    {
                        Controller = "Author",
                        Description = "Author with this id wasn't found"
                    });

            await _authorService.DeleteAsync(id);

            return View("Success", "Author");
        }

        public async Task<IActionResult> Search(string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                return PartialView("_AuthorList", new List<AuthorForDisplay>());
            }

            var result = await _authorService.SearchByNameAsync(authorName);

            if (result.StatusCode != Domain.Enums.StatusCode.OK)
            {
                View("Error",
                   new ErrorViewModel
                   {
                       Controller = "Author",
                       Description = result.Description
                   });
            }
            var mappedAuthors = _mapper.Map<IEnumerable<AuthorForDisplay>>(result.Data);

            return PartialView("_AuthorList", mappedAuthors);
        }

        public async Task<IActionResult> ShowAllWithPartialView()
        {
            var authors = await _authorService.GetAllAsync();

            var mappedAuthors = _mapper.Map<IEnumerable<AuthorForDisplay>>(authors.Data);

            return PartialView("_AuthorList", mappedAuthors);
        }
    }
}
